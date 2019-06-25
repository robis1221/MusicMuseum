using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTrack : MonoBehaviour {
	public float z;


	// Use this for initialization
	void Awake () {
		transform.position = new Vector3 (Screen.width/2, Screen.height/2, z);


	}
	
	// Update is called once per frame
	void Update () {
		transform.parent = Camera.main.transform;
	}
}
