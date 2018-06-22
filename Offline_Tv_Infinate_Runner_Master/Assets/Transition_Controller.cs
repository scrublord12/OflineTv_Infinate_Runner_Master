using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
