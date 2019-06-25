using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickMoverMouse : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, screenPoint.z));
	}

	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, 0, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

	void LateUpdate(){
		PlayerMovementClamping ();
	}

	void PlayerMovementClamping()
	{
		var viewpointCoord = Camera.main.WorldToViewportPoint(transform.position);
		viewpointCoord.x = Mathf.Clamp01(viewpointCoord.x);
		transform.position = Camera.main.ViewportToWorldPoint(viewpointCoord);
	}
}