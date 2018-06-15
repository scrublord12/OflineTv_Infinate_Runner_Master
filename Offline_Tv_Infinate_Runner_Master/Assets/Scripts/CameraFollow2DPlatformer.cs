using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatformer : MonoBehaviour {

    public Transform target; //camera is following this
    public float smoothing; //dampening efffect on the camera

    Vector3 offset;

    float lowY; //cant go below this point
    float lowX;

	void Start () {

        offset = transform.position - target.position;
        lowY = transform.position.y;
        lowX = transform.position.x;

	}

    private void FixedUpdate() {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if(transform.position.y < lowY) {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }

        if (transform.position.x < lowX) {
            transform.position = new Vector3(lowX, transform.position.y, transform.position.z);
        }

        if (transform.position.y > lowY) {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }


}
