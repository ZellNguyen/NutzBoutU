using UnityEngine;
using System.Collections;

public class InstantiateWindow : MonoBehaviour {

	Transform window;

	public GameObject windowBoss;
	public GameObject sarahWindow;
	public GameObject finalWindow;

	// Use this for initialization
	void Start () {
		window = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Clone(){
		Debug.Log ("CLONE");
		GameObject newWindow0 = (GameObject)Instantiate (window.gameObject, new Vector3 (2f, 7.5f, 0f), Quaternion.identity);
		GameObject newWindow1 = (GameObject)Instantiate (window.gameObject, new Vector3 (2f, 10f, 0f), Quaternion.identity);
		GameObject newWindow2 = (GameObject)Instantiate (window.gameObject, new Vector3 (2f, 12.5f, 0f), Quaternion.identity);
		GameObject newWindow3 = (GameObject)Instantiate (window.gameObject, new Vector3 (2f, 15f, 0f), Quaternion.identity);
		//GameObject newWindow4 = (GameObject)Instantiate (window.gameObject, new Vector3 (2f, 17.5f, 0f), Quaternion.identity);
		newWindow0.transform.parent = gameObject.transform;
		newWindow1.transform.parent = gameObject.transform;
		newWindow2.transform.parent = gameObject.transform;
		newWindow3.transform.parent = gameObject.transform;
		//newWindow4.transform.parent = gameObject.transform;
	}

	public void SetUpForFinalStage() {
		Debug.Log ("FINAL STAGE");
		GameObject newWindow0 = (GameObject)Instantiate (finalWindow.gameObject, new Vector3 (2f, 7.5f, 0f), Quaternion.identity);
		GameObject newWindow1 = (GameObject)Instantiate (finalWindow.gameObject, new Vector3 (2f, 10f, 0f), Quaternion.identity);
		GameObject newWindow2 = (GameObject)Instantiate (windowBoss, new Vector3 (2f, 12.5f, 0f), Quaternion.identity);
		GameObject newWindow3 = (GameObject)Instantiate (finalWindow.gameObject, new Vector3 (2f, 15f, 0f), Quaternion.identity);
		//GameObject newWindow4 = (GameObject)Instantiate (finalWindow, new Vector3 (0.5f, 17.2f, 0f), Quaternion.identity);
		newWindow0.transform.parent = gameObject.transform;
		newWindow1.transform.parent = gameObject.transform;
		newWindow2.transform.parent = gameObject.transform;
		newWindow3.transform.parent = gameObject.transform;
		//newWindow4.transform.parent = gameObject.transform;
	}
}
