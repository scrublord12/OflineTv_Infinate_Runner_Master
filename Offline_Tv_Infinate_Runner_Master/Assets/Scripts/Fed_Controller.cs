using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fed_Controller : MonoBehaviour {

    public float jumpForce;
    public float speed;

    public float jumpTime;
    float jumpTimeCounter;

    public bool isGrounded;

    public bool notOnMenu;

    bool startRunningLeft;
    bool startRunningRight;

    public LayerMask groundLayer;

    Animator myAnim;
    Collider2D myCollider;
    Rigidbody2D myRb;

    public Transform groundCheck;
    public float groundCheckRadius;

    public bool leakTouched;

    bool stoppedJumping;

    public bool alreadyDead;

    public GameObject[] LeakHitSounds;

    public GameObject[] FallSounds;

    public GameObject[] JumpSounds;

    bool alreadyDeadLeak;

    public GameObject levelManager;

    public Transform deathPoint;

    public bool inMenu;


    // Use this for initialization
    void Start () {

        myRb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnim = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        stoppedJumping = true;

        alreadyDead = false;


    }
	
	// Update is called once per frame
	void Update () {
        if (inMenu) {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            myAnim.SetFloat("speed", Mathf.Abs(myRb.velocity.x));
            myAnim.SetBool("isGrounded", isGrounded);
            myAnim.SetFloat("verticalSpeed", myRb.velocity.y);

            myRb.velocity = new Vector2(speed, myRb.velocity.y);


        }
        else {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            myAnim.SetFloat("speed", Mathf.Abs(myRb.velocity.x));
            myAnim.SetBool("isGrounded", isGrounded);
            myAnim.SetFloat("verticalSpeed", myRb.velocity.y);

            if (((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)) {

                myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
                //JumpSounds[Random.Range(0, JumpSounds.Length)].GetComponent<AudioSource>().Play();

                stoppedJumping = false;
            }




            if (Input.GetKeyDown(KeyCode.A)) {
                myRb.velocity = new Vector2(-speed, myRb.velocity.y);
                if (transform.localScale.x > 0)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
            else
             if (Input.GetKeyDown(KeyCode.D)) {
                myRb.velocity = new Vector2(speed, myRb.velocity.y);
                if (transform.localScale.x < 0)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }




            if ((((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping))) {

                if (jumpTimeCounter > 0) {
                    myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;

                }

            }

            if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))) {
                jumpTimeCounter = 0;
                stoppedJumping = true;
            }

            if (transform.position.y < deathPoint.position.y) {
                alreadyDead = true;
                Debug.Log("hi");
            }

            if (isGrounded) {
                jumpTimeCounter = jumpTime;
            }

            if (transform.position.y < deathPoint.position.y) {
                alreadyDead = true;
            }

            if (alreadyDead) {
                levelManager.GetComponent<fedLevelManager>().Died();
                alreadyDead = false;
            }
        }

    }
}
