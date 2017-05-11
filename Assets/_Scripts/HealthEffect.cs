using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthEffect : MonoBehaviour {
	public float noiseMeter;

	// Use this for initialization
	void Start () {
		noiseMeter = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (noiseMeter > 0.001) {
			noiseMeter -= 0.0005f;
		}
		if (noiseMeter >= 1f) {
			EndGame ();
		}
		transform.localScale = new Vector3 (0.5f, noiseMeter, 0.5f);
	}

	void EndGame() {
		SceneManager.LoadScene ("CopCaughtScene", LoadSceneMode.Single);
	}
}
