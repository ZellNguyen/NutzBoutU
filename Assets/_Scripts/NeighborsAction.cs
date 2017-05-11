using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class NeighborsAction : MonoBehaviour {

	public int stage = 0;

	public bool isOpenForThrowing; 
	public bool isOpenForInsult;
	Animator anim;
	float openDuration;

	public bool wasHit;

	public float attackFrequency = 0.75f;

	AudioSource neighborSFX;
	public AudioClip[] clips;
	public AudioClip hitClip;

	// Use this for initialization
	void Start () {
		isOpenForThrowing = false;
		isOpenForInsult = false;
		wasHit = false;
		anim = GetComponent<Animator> ();

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

		// Play the sound
		int random = Random.Range(0,8);
		neighborSFX.clip = clips [random];
		neighborSFX.Play();

		var noiseBar = GameObject.Find ("NoiseMeterBarContainer");
		noiseBar.GetComponent<HealthEffect> ().noiseMeter += 0.1f;
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
		InvokeRepeating ("Insult", 1f, attackFrequency);
	}

	public void GetHit() {
		neighborSFX.clip = hitClip;
		neighborSFX.Play ();
		isOpenForInsult = false;
		isOpenForThrowing = false;
		anim.SetBool ("isOpenToThrow", false);
		anim.SetBool ("isOpenToInsult", false);
		wasHit = true;
		CancelInvoke ("ThrowGarbage");
		CancelInvoke ("Insult");
	}

}
