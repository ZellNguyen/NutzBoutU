using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	public static int score = 0;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Window" && (other.gameObject.GetComponent<NeighborsAction>().isOpenForInsult || other.gameObject.GetComponent<NeighborsAction>().isOpenForThrowing)) {
			other.gameObject.GetComponent<NeighborsAction> ().GetHit ();
			GameObject ground = GameObject.Find ("EndlessBG");
			ground.GetComponent<MoveGround> ().numberOfNeighborsHit++;
			Destroy (gameObject, 0.05f);
		}
		if (other.gameObject.tag == "Boss" && other.gameObject.GetComponent<BossAction> ().isOpen) {
			other.gameObject.GetComponent<BossAction> ().GetHit ();
			Destroy (gameObject, 0.05f);
		}
		if (other.gameObject.tag == "FinalWindow" && (other.gameObject.GetComponent<FinalNeighborsAction>().isOpenForInsult || other.gameObject.GetComponent<FinalNeighborsAction>().isOpenForThrowing)) {
			StartCoroutine(other.gameObject.GetComponent<FinalNeighborsAction> ().GetHit ());
			Destroy (gameObject, 0.05f);
		}
	}

}
