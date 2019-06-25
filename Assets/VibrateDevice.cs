using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateDevice : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void ButtonEvent () {

        Handheld.Vibrate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
