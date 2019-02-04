using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Transform playerTransform ;
	void Start () {
		playerTransform = GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraTransform;
	}

	void Update () {
		Follow (playerTransform.position);
		Rotate (playerTransform.rotation);
	}
	void Follow(Vector3 pos){
		gameObject.transform.position = pos;
	}
	void Rotate(Quaternion quarternion){
		gameObject.transform.rotation = quarternion;
	}
}
