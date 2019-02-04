using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform cameraTransform ;
	Rigidbody rg;

	float forwardSpeed = 6f;
	float BackwardSpeed = 3f;

    void Awake()
    {
		rg = GetComponent<Rigidbody>();
    }
		
    void FixedUpdate()
    {
		MoveKeyboardControl();
    }
	public void MoveToRotation(Vector3 RotationVector ,float speed){
		rg.AddForce(RotationVector, ForceMode.Impulse);
		ClampVelocity(speed);
		//Debug.Log (GetSpeed ());
	}
	void MoveKeyboardControl(){

		Vector3 movingRotationVector = new Vector3();

		if (Input.anyKey) {
			
			float speed = BackwardSpeed;

			float v = Input.GetAxis("Vertical");    // İleri-Geri Yön değeri
			float h = Input.GetAxis("Horizontal");  // Sağ-Sol Yön değeri

			if (v > 0)
				speed = forwardSpeed; 
			if (Input.GetKey (KeyCode.LeftShift))
				speed = 15f;
			
			movingRotationVector = transform.forward * v + transform.right * h;
			//MoveToRotation (movingRotationVector * speed);
			MoveToRotation(movingRotationVector , speed);
			Debug.DrawRay(cameraTransform.position, movingRotationVector , Color.red);
		}
	}
	float GetVelocitySize(Vector3 velocity){
		return velocity.magnitude;
	}
	float GetSpeed(){
		float t = rg.velocity.x * rg.velocity.x  + rg.velocity.z * rg.velocity.z;
		return	Mathf.Pow (t , 1f/2f);
	}
	void ClampVelocity(float speed){
		rg.velocity = Vector3.ClampMagnitude (rg.velocity, speed);
	}
}
