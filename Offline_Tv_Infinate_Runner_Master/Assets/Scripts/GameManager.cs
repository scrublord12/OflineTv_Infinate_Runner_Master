﻿using System.Collections;
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

    public Animator transition;

    private void Awake() {
        transition.SetTrigger("Down");
    }

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
        transition.SetTrigger("Full");
        yield return new WaitForSeconds(0.5f);
        DeathMenu.GetComponent<Animator>().SetBool("Died", false);
        player.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDeletionScript>();

        for(int i = 0; i < platformList.Length; i++) {

            Destroy(platformList[i].gameObject);
        }

        yield return new WaitForSeconds(0.5f);
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


    }

    public void Menu() {

        StartCoroutine("menu");

    }

    IEnumerator menu() {

        transition.SetTrigger("Up");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main_Menu");

    }
}
