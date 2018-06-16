using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatformer : MonoBehaviour {

    public Player_Controller player;
    Vector3 lastPlayerPositionl;
    float distanceToMove;

    Vector3 offset;

    float lowY; //cant go below this point
    float lowX;

	void Start () {
        player = FindObjectOfType<Player_Controller>();
        lastPlayerPositionl = player.transform.position;

	}

    private void Update() {
        distanceToMove = player.transform.position.x - lastPlayerPositionl.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPositionl = player.transform.position;
    }




}
        
