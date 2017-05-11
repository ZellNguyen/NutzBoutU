using UnityEngine;
using System.Collections;

public class FinalNeighborsAction : MonoBehaviour {

	public int stage = 0;

	public bool isOpenForThrowing; 
	public bool isOpenForInsult;
	Animator anim;
	float openDuration;

	public float attackFrequency = 0.75f;
	public bool wasHit = false;

	// Sound
	AudioSource neighborSFX;
	public AudioClip[] clips;
	public AudioClip hitClip;

	// Use this for initialization
	void Start () {
		isOpenForThrowing = false;
		isOpenForInsult = false;
		anim = GetComponent<Animator> ();

		var randomDelay = Random.Range (1f, 2f);
		Invoke ("RandomlyOpen", randomDelay);

		neighborSFX = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isOpenForThrowing) {
			anim.SetBool ("isOpenToThrow", true);
		} else {
			anim.SetBool ("isOpenToThrow", false);
		}

		if (isOpenForInsult) {
			anim.SetBool ("isOpenToInsult", true);
		} else {
			anim.SetBool ("isOpenToInsult", false);
		}
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

		int random = Random.Range (0, 8);
		neighborSFX.clip = clips [random];
		neighborSFX.Play ();

		var noiseBar = GameObject.Find ("NoiseMeterBarContainer");
		noiseBar.GetComponent<HealthEffect> ().noiseMeter += 0.05f;
		Destroy (insultInstance, 0.3f);
	}

	public void OpenForThrowing(){
		isOpenForThrowing = true;
		isOpenForInsult = false;
		InvokeRepeating ("ThrowGarbage", 0f, attackFrequency);
	}

	public void OpenForInsult(){
		isOpenForInsult = true;
		isOpenForThrowing = false;
		InvokeRepeating ("Insult", 2f, attackFrequency);
	}

	public IEnumerator GetHit() {
		wasHit = true;
		neighborSFX.clip = hitClip;
		neighborSFX.Play ();
		isOpenForInsult = false;
		isOpenForThrowing = false;
		anim.SetBool ("isOpenToThrow", false);
		anim.SetBool ("isOpenToInsult", false);
		CancelInvoke ("ThrowGarbage");
		CancelInvoke ("Insult");

		yield return new WaitForSeconds (1.5f);
		wasHit = false;
		RandomlyOpen ();
	}

	void RandomlyOpen(){
		var isThrowing = Random.value > 0.3 ? true : false;
		if (isThrowing) {
			OpenForThrowing ();
		}
		else {
			OpenForInsult ();
		}
	}

}
