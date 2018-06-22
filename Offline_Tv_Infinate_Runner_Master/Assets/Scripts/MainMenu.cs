using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public string playGameLevel;

    public Animator transition;


    public void playGame() {

        StartCoroutine("play");

    }

    private void Awake() {

        transition.SetTrigger("Down");
    }

    IEnumerator play() {

        transition.SetTrigger("Full");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(playGameLevel);


    }

    public void quitGame() {
        Application.Quit();
    }


}
