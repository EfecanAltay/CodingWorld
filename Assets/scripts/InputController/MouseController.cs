using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
	public Transform playerCameraTransform;
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		MouseControling ();
    }
	void MouseControling(){
		
		float Rx = Input.GetAxis("Mouse X");
		float Ry = Input.GetAxis("Mouse Y");
	


		playerCameraTransform.Rotate (new Vector3 (-Ry*10f, 0, 0));
		float angle = playerCameraTransform.localRotation.eulerAngles.x;
		Debug.Log (angle);
		if (angle > 180)
			angle = angle - 360;
	
		float x = Mathf.Clamp(angle, -90, 60);
		playerCameraTransform.localRotation = Quaternion.Euler (x,0, 0);

		transform.Rotate (new Vector3 (0,Rx*10f,0));

	}
}
