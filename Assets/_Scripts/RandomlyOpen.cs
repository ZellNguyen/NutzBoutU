using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomlyOpen : MonoBehaviour {

	public bool isChosen; 

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("RandomCall", 0f, 1f);
		//isChosen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RandomCallGarbage(){

		var windows = GameObject.FindGameObjectsWithTag ("Window");

		var windowsOnScreen = new List<GameObject> ();

		foreach (var window in windows) {
			if (!window.gameObject.GetComponent<NeighborsAction>().isOpenForThrowing 
				&& !window.gameObject.GetComponent<NeighborsAction>().wasHit && isInsideCamera(window))
				windowsOnScreen.Add (window);
		}

		//Debug.Log (random);
		var random = Random.Range (0, windowsOnScreen.Count);
		var windowInstance = windowsOnScreen[random].gameObject.GetComponent<NeighborsAction> ();
		windowInstance.OpenForThrowing ();

	}

	public void RandomCallGenerally() {
		var windows = GameObject.FindGameObjectsWithTag ("Window");

		var windowsOnScreen = new List<GameObject> ();

		foreach (var window in windows) {
			if (!window.gameObject.GetComponent<NeighborsAction>().isOpenForThrowing 
				&& !window.gameObject.GetComponent<NeighborsAction>().isOpenForInsult && !window.gameObject.GetComponent<NeighborsAction>().wasHit && isInsideCamera(window))
				windowsOnScreen.Add (window);
		}

		//Debug.Log (random);
		var random = Random.Range (0, windowsOnScreen.Count);
		var windowInstance = windowsOnScreen[random].gameObject.GetComponent<NeighborsAction> ();
		var randomBool = Random.value > 0.3 ? true : false;
		if (randomBool) {
			windowInstance.OpenForThrowing ();
		} else {
			windowInstance.OpenForInsult ();
		}
	}

	public bool isInsideCamera(GameObject obj) {
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		if (GeometryUtility.TestPlanesAABB(planes , obj.GetComponent<Collider2D>().bounds))
			return true;
		else
			return false;
	}

	/*public void Choose(){
		StartCoroutine (IChoose ());
	}

	IEnumerator IChoose(){
		isChosen = true;
		yield return new WaitForSeconds (3f);
		isChosen = false;
	}*/

}
