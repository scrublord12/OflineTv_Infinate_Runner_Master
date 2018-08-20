using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFedLevel : MonoBehaviour {


    public Fed_Controller player;
    Vector3 lastPlayerPosition;
    float distanceToMove;

    Vector3 offset;

    float lowY;
    float lowX;
    public bool camMove;

    public float speedMultiplier;

    public float milestoneCount;

    public GameObject score;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Fed_Controller>();
        lastPlayerPosition = player.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        if(transform.position.y > milestoneCount) {

            speedMultiplier *= 1.2f;

            milestoneCount += milestoneCount;

        }
        
        if (player.transform.position.y > (lastPlayerPosition.y)) {

            camMove = true;

        }
  

        if (camMove) {
            transform.position = new Vector3(transform.position.x, (transform.position.y + speedMultiplier) , transform.position.z);
        }
        


    }
}
