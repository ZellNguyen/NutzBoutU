using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectNuts: MonoBehaviour {
	public Text nutsNumberText;
	public GameObject nutz;

	AudioSource source;
	public AudioClip collectNutSFX;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Nuts") {
			// Trigger Sound
			source.clip = collectNutSFX;
			source.Play ();

			var nutPosition = other.transform.position;
			Debug.Log ("EATEN");
			Destroy(other.gameObject, 0.2f);
			GameObject aimBar = GameObject.Find ("Tony/Aim_Bar");
			aimBar.GetComponent<ThrowNuts> ().numberOfNuts++;
			var nutsNumber = aimBar.GetComponent<ThrowNuts> ().numberOfNuts;
			nutsNumberText.text = nutsNumber.ToString ("D2");  
			StartCoroutine(respawn(nutPosition, 6f));
		}
	}
		
	IEnumerator respawn(Vector3 atPosition, float delayTime) {
		yield return new WaitForSeconds (delayTime);
		var nut = (GameObject)Instantiate (nutz, atPosition, Quaternion.identity);
		nut.transform.parent = GameObject.Find ("NutsOnTree").transform;
	}
}
