using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCheck : MonoBehaviour {

	GameObject destroyer;

	// Use this for initialization
	void Start () {
		destroyer = GameObject.Find ("ARCamera/Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (destroyer);
	}
}
