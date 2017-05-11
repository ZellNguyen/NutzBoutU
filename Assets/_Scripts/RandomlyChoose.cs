using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomlyChoose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("RandomCall", 0f, 1.2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void RandomCall(){

		var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		var windows = GameObject.FindGameObjectsWithTag ("Window");

		var windowsOnScreen = new List<GameObject> ();

		foreach (var window in windows) {
			if (GeometryUtility.TestPlanesAABB (planes, window.GetComponent<Renderer> ().bounds))
				windowsOnScreen.Add (window);
		}

		for (;;) {
			var random = Random.Range (0, windowsOnScreen.Count);
			if (!windowsOnScreen [random].GetComponent<RandomlyOpen> ().isChosen) {
				windowsOnScreen [random].GetComponent<RandomlyOpen> ().Choose ();
				break;
			} 
		}
	}*/
}
