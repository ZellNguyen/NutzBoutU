using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossAction : MonoBehaviour {

	public int stage = 0;

	Animator anim;
	float openDuration;
	float health;	

	public float attackFrequency = 0.5f;
	public bool isOpen = false;

	public Transform healthBar;

	// sound
	AudioSource bossSource;
	public AudioClip[] bossClips;
	public AudioClip bossGetHitClip;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		health = 5;
		healthBar = (Transform)transform.Find ("EnergyBarScale");

		Invoke ("OpenToAttack", 1f);

		bossSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.localScale = new Vector3 (health, 1, 1);
	}

	void ThrowGarbage () {
		GameObject garbageInstance;
		var instanceNames = new string[] {"Garbage-bottle", "Garbage-Can", "Garbage-appleCore", "Garbage-bag"};
		int index = Random.Range(0, 4);
		var instanceName = instanceNames [index];
		var garbage = (GameObject)Resources.Load ("Prefabs/" + instanceName, typeof(GameObject));

		garbageInstance = Instantiate (garbage, transform.position, Quaternion.identity) as GameObject;
		garbageInstance.transform.parent = GameObject.Find ("EndlessBG/BackGround/Garbages").transform;
	}

	void Insult() {
		GameObject insultInstance;
		var insult = GameObject.Find ("Insult");
		insultInstance = Instantiate (insult, new Vector3 (0, transform.position.y, 0), Quaternion.identity) as GameObject;
		insultInstance.transform.parent = GameObject.Find ("EndlessBG/BackGround/Insults").transform;

		// Trigger the sound
		int random = Random.Range(0, 4);
		bossSource.clip = bossClips [random];
		bossSource.Play ();

		var noiseBar = GameObject.Find ("NoiseMeterBarContainer");
		noiseBar.GetComponent<HealthEffect> ().noiseMeter += 0.1f;
		Destroy (insultInstance, 0.3f);
	}

	public void GetHit() {
		health -= 0.5f;
		bossSource.clip = bossGetHitClip;
		bossSource.Play ();
		Die ();
	}

	void Die() {
		if (health <= 0) {
			isOpen = false;
			anim.SetBool ("isOpen", false);
			SceneManager.LoadScene ("WinScene", LoadSceneMode.Single);
		}
	}

	void Attack() {
		var randomFloat = Random.value;
		var isThrowing = randomFloat > 0.3 ? true : false;

		if (isThrowing) {
			ThrowGarbage ();
		} else {
			Invoke ("Insult", 1);
		}
	}

	void OpenToAttack() {
		isOpen = true;
		anim.SetBool ("isOpen", true);
		InvokeRepeating ("Attack", 1f, attackFrequency);
	}
}