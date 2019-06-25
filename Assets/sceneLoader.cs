using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneLoader : MonoBehaviour {

	public void loadScene(int level){
	SceneManager.LoadScene(level,LoadSceneMode.Additive);
		Debug.Log ("Loaded scene");
	}
}
