using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gyroScript : MonoBehaviour {
	private bool gyroEnabled;
	private Gyroscope gyro;

	private Quaternion rot;

	float counterX, counterY, counterZ;
	string msg;

	// Use this for initialization
	public void Start () {
		gyroEnabled = EnableGyro ();

		counterX = 0.0f;
		counterY = 0.0f;
		counterZ = 0.0f;


	}

	private bool EnableGyro(){
		if (SystemInfo.supportsGyroscope) {
			gyro = Input.gyro;
			gyro.enabled = true;	
			rot = new Quaternion (0, 0, 1, 0);
			return true;
		}

		return false;
	}

	// Update is called once per frame
	private void Update () {
		
		if (gyroEnabled) {

			transform.rotation = gyro.attitude * rot;
			counterX = counterX + transform.rotation.x;
			counterY = counterY + transform.rotation.y;
			counterZ = counterZ + transform.rotation.z;
			msg = "supported";
			Debug.Log ("transform.rotation angles x: " + rot.x + " y: " + rot.y + " z: " + rot.z);


		} else {
			msg = "not supported";
		}
		
		
		
			
	}
}
