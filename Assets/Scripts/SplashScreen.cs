using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("NextScene",5f);
	}
	
	// Update is called once per frame
	void NextScene () {
		SceneManager.LoadScene("Proto");
	}
}
