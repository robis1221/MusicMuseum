using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class pose_f : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour track;
	public Vector3 currentPosition;
	public Vector3 lastPosition;
	public float pos_delta, pos_delta_time, pos_delta_time_update, vol_delta_time, currentPosition_x, lastPosition_x, pos_delta_x;
	public AudioSource audioc;
	public bool played, pressed;

	public ParticleSystem particles1;
	public ParticleSystem particles2;


	void Start () {

		track = GetComponent<TrackableBehaviour>();
		if (track) {
			track.RegisterTrackableEventHandler (this);
		}
		pos_delta_time_update = 0;
		vol_delta_time = 0;
		audioc.Play ();
		audioc.volume = 0;
		audioc.pitch = 1;
	}

	// Update is called once per frame
	void Update () {
		// get current position
		currentPosition = transform.position;
		currentPosition_x = currentPosition.x;
		pos_delta_time = Time.frameCount;

		//pos_delta = Vector3.Distance (currentPosition, lastPosition);
		pos_delta_x = Mathf.Abs (currentPosition_x - lastPosition_x);
		if (Input.GetMouseButtonDown (0)) {
			pressed = true;
		} else if (Input.GetMouseButtonUp (0)) {
			pressed = false;
		}
		if (pos_delta_x > 0.5f && played == false && pressed == true) {
			//audioc.Play ();
			audioc.volume = Mathf.Lerp (audioc.volume, pos_delta_x / 2, 0.4f);
			//Debug.Log ("works");
			//audioc.pitch = Mathf.Lerp (audioc.pitch, Mathf.Clamp(pos_delta_x, 0.9f, 1.1f), 0.1f);
			played = true;

			particles1.Play ();
			particles2.Play ();
		} else {
			played = false;
		}


		if (pos_delta_x < 0.5f && pos_delta_time > vol_delta_time + 30) {

			audioc.volume = Mathf.Lerp (audioc.volume, 0, 0.8f);
			//audioc.pitch = Mathf.Lerp (audioc.pitch, 1, 0.2f);
			vol_delta_time = pos_delta_time;

			particles1.Stop ();
			particles2.Stop ();
		}

		//Debug.Log(" time dif " + pos_delta_time + " x dif " + pos_delta_x + " volume " + audioc.volume);

		if (pos_delta_time > pos_delta_time_update + 2) 
		{
			pos_delta_time_update = pos_delta_time;
			lastPosition = transform.position;
			lastPosition_x = lastPosition.x;

		}


	}

	public void OnTrackableStateChanged ( TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			audioc.Play ();
		} else {
			audioc.Stop ();

		}

	}

}
