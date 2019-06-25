using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_s : MonoBehaviour {

	public ParticleSystem particles1;
	public ParticleSystem particles2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log ("input works");
			particles1.Play ();
			particles2.Play ();
		} else if(Input.GetMouseButtonUp(0)) {
			particles1.Stop ();
			particles2.Stop ();
		}
}
}