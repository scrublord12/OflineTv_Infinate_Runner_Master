using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public string playGameLevel;


    public void playGame() {

        SceneManager.LoadScene(playGameLevel);

    }

    public void quitGame() {
        Application.Quit();
    }


}
