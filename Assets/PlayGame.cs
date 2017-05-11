using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void LoadGame() {
		SceneManager.LoadScene ("FirstCutScene", LoadSceneMode.Additive);
	}
}
