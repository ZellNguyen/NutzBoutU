using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnloadCutScene : MonoBehaviour {

	public Image cutScene;

	// Use this for initialization
	void Start () {
	
	}
	
	public void Next() {
		Time.timeScale = 1;
		cutScene.enabled = false;
		gameObject.SetActive (false);
	}
}
