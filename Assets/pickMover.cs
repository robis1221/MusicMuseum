using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickMover : MonoBehaviour {
	private float speed;

	void Awake(){
		speed = Time.deltaTime;
	}

	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Move object across XY plane
			transform.Translate(touchDeltaPosition.x * speed, 0, 0);
		}
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