using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoBackFromSetting : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void Menu() {
		SceneManager.UnloadScene ("Setting");
	}
}
