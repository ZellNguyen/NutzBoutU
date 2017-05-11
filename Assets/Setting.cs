using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void GoToSetting() {
		SceneManager.LoadScene ("Setting", LoadSceneMode.Additive);
	}
}
