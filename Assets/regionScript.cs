using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regionScript : MonoBehaviour {
	private Camera cam;
	private GameObject up;
	private GameObject down;
	public bool switchCheck;

	// Use this for initialization
	void Start () {
	cam = Camera.main;
	up = GameObject.FindGameObjectWithTag ("RegionUp");
	down = GameObject.FindGameObjectWithTag ("RegionDown");
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = cam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, cam.nearClipPlane));
			//cam.ScreenPointToRay (Input.mousePosition); //add the same if statements from triggered.cs
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == up.tag || hit.collider.tag == down.tag)
            {
                Transform objectHit = hit.transform;
                switchCheck = true;
                Debug.Log("outta bounds"); // change icon on pick to a stop sign.
            }
        }
        else
        {
            switchCheck = false;
        }
		//else have icon as guitar pick
	
}
}
