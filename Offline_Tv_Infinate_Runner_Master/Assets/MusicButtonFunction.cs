using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButtonFunction : MonoBehaviour {

    GameObject musicController;

	// Use this for initialization
	void Start () {

        musicController = GameObject.FindGameObjectWithTag("MusicController");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
