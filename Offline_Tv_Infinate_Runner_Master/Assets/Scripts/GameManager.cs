using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    Vector3 platformStartPoint;

    public Player_Controller player;
    Vector3 playerStartPoint;

    PlatformDeletionScript[] platformList;

    float initialSpeed;
    float initialMilestone;

    public ScoreManager score;

    public GameObject DeathMenu;

	void Start () {

        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;

        initialSpeed = player.speed;
        initialMilestone= player.speed_Increase_Milestone;

	}
	
	void Update () {

    }

    public void restartGame() {
        StartCoroutine("RestartGameCo");
    }

    IEnumerator RestartGameCo(){
        DeathMenu.GetComponent<Animator>().SetBool("Died", false);
        player.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDeletionScript>();

        for(int i = 0; i < platformList.Length; i++) {

            Destroy(platformList[i].gameObject);
        }


        yield return new WaitForSeconds(0f);
        player.transform.position = playerStartPoint;
        platformGenerator.GetComponent<Platform_Generator>().lastPlatformX = platformStartPoint.x;
        platformGenerator.GetComponent<Platform_Generator>().lastPlatformY = platformStartPoint.y;
        platformGenerator.position = platformStartPoint;
        player.speed = initialSpeed;
        player.speed_Increase_Milestone = initialMilestone;
        score.scoreCount = 0;
        player.micTouched = false;
        DeathMenu.GetComponent<Animator>().SetBool("Died", false);

        player.alreadyDead = false;

        player.gameObject.SetActive(true);

    }

    public void Died() {

        score.scoreIncreasing = false;
        DeathMenu.GetComponent<Animator>().SetBool("Died", true);
        if (player.isGrounded) {

            //run lilly sad animation
            player.speed = 0;

        }


    }

    public void Menu() {
        SceneManager.LoadScene("Main_Menu");

    }
}
