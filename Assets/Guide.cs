using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Guide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public IEnumerator showTutorial(Image[] tutorials){
		foreach (Image tutorial in tutorials) {
			tutorial.enabled = true;
			yield return new WaitForSeconds (2f);
			tutorial.enabled = false;
		}
	}
}
