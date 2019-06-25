using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playVideo : MonoBehaviour {

	private string movie = "animationDanishBlur.mp4";
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(streamVideo(movie));
	}
	private IEnumerator streamVideo(string video)
	{
		Handheld.PlayFullScreenMovie(video, Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.Fill);
		yield return new WaitForEndOfFrame();
		Debug.Log("The Video playback is now completed.");
		SceneManager.LoadScene(1,LoadSceneMode.Single);

	}
}