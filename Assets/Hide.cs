using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponentInChildren<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
