﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool music;

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		


	}

    private void Awake() {
        
            DontDestroyOnLoad(this.gameObject);
        
    }

    void MusicController() {

        music = !music;

    }
}
