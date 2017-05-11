using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void Replay() {
		SceneManager.LoadScene ("Main", LoadSceneMode.Single);
	}
}
