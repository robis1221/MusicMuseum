using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiSwitch : MonoBehaviour {

	public RawImage pick;
	public RawImage cancel;
	private GameObject region;
	regionScript Regionscript;


	// Use this for initialization
	void Start () {
		region = GameObject.Find ("Guitar/Regions");
		Regionscript = region.GetComponent<regionScript> ();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Regionscript.switchCheck == true) {
			pick.enabled = false;
			cancel.enabled = true;
		} else {
			pick.enabled = true;
			cancel.enabled = false;
		}
	}




		
	
}
