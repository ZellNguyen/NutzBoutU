using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetHitByInsult : MonoBehaviour {

	GameObject[] gameOverObjects;

	GameObject tony;

	bool isAlmostDie;

	AudioSource getHitSound;
	public AudioClip getHitClip;

	// Use this for initialization
	void Start () {
		gameOverObjects = GameObject.FindGameObjectsWithTag ("GameOverShow");
		foreach (GameObject gameOverObject in gameOverObjects) {
			gameOverObject.SetActive (false);
		}
		tony = GameObject.Find ("Tony");

		isAlmostDie = false;

		getHitSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tony.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Tony_Down2"))
			isAlmostDie = true;
		else
			isAlmostDie = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Garbage") {
			Destroy (other.gameObject, 0.2f);
			getHitSound.clip = getHitClip;
			getHitSound.Play ();
			Invoke ("FallDown", 0.05f);
			if (isAlmostDie) {
				Invoke ("EndGame", 0.0f);
			}
		}
	}

	void EndGame(){
		foreach (GameObject gameOverObject in gameOverObjects) {
			gameOverObject.SetActive (true);
		}
		SceneManager.LoadScene ("FallingScene", LoadSceneMode.Single);
	}

	void FallDown(){
		tony.GetComponent<Animator> ().SetTrigger ("MoveDown");
	}
}
