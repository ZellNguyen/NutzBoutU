using UnityEngine;
using System.Collections;

public class InstantiateBranches : MonoBehaviour {

	public GameObject branch1;
	public GameObject branch2;
	public GameObject branch3;
	public GameObject topBranch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clone() {
		Transform branch = transform.GetChild (transform.childCount-1);
		GameObject newBranch1 = (GameObject)Instantiate (branch1, new Vector3 (-2.8f, 7.5f, 0f), Quaternion.identity);
		GameObject newBranch2 = (GameObject)Instantiate (branch2, new Vector3 (-2.8f, 10f, 0f), Quaternion.identity);
		GameObject newBranch3 = (GameObject)Instantiate (branch3, new Vector3 (-2.8f, 12.5f, 0f), Quaternion.identity);
		GameObject newBranch4 = (GameObject)Instantiate (branch1, new Vector3 (-2.8f, 15f, 0f), Quaternion.identity);
		//GameObject newBranch5 = (GameObject)Instantiate (branch2, new Vector3 (-2.8f, 17.5f, 0f), Quaternion.identity);
		newBranch1.transform.parent = gameObject.transform;
		newBranch1.GetComponent<SpriteRenderer> ().sortingOrder = branch.GetComponent<SpriteRenderer> ().sortingOrder + 1;

		newBranch2.transform.parent = gameObject.transform;
		newBranch2.GetComponent<SpriteRenderer> ().sortingOrder = newBranch1.GetComponent<SpriteRenderer> ().sortingOrder + 1;

		newBranch3.transform.parent = gameObject.transform;
		newBranch3.GetComponent<SpriteRenderer> ().sortingOrder = newBranch2.GetComponent<SpriteRenderer> ().sortingOrder + 1;

		newBranch4.transform.parent = gameObject.transform;
		newBranch4.GetComponent<SpriteRenderer> ().sortingOrder = newBranch3.GetComponent<SpriteRenderer> ().sortingOrder + 1;
		//newBranch5.transform.parent = gameObject.transform;
	}

	public void SetUpForFinalStage() {
		Transform branch = transform.GetChild (transform.childCount-1);
		GameObject newBranch1 = (GameObject)Instantiate (branch1, new Vector3 (-2.8f, 7.5f, 0f), Quaternion.identity);
		GameObject newBranch2 = (GameObject)Instantiate (branch2, new Vector3 (-2.8f, 10f, 0f), Quaternion.identity);
		GameObject newBranch3 = (GameObject)Instantiate (branch3, new Vector3 (-2.8f, 12.5f, 0f), Quaternion.identity);
		GameObject newBranch4 = (GameObject)Instantiate (branch1, new Vector3 (-2.8f, 15f, 0f), Quaternion.identity);
		//GameObject newBranch5 = (GameObject)Instantiate (topBranch, new Vector3 (-2.8f, 17.5f, 0f), Quaternion.identity);
		newBranch1.transform.parent = gameObject.transform;
		newBranch1.GetComponent<SpriteRenderer> ().sortingOrder = branch.GetComponent<SpriteRenderer> ().sortingOrder + 1;

		newBranch2.transform.parent = gameObject.transform;
		newBranch2.GetComponent<SpriteRenderer> ().sortingOrder = newBranch1.GetComponent<SpriteRenderer> ().sortingOrder + 1;

		newBranch3.transform.parent = gameObject.transform;
		newBranch3.GetComponent<SpriteRenderer> ().sortingOrder = newBranch2.GetComponent<SpriteRenderer> ().sortingOrder + 1;

		newBranch4.transform.parent = gameObject.transform;
		newBranch4.GetComponent<SpriteRenderer> ().sortingOrder = newBranch3.GetComponent<SpriteRenderer> ().sortingOrder + 1;
		//newBranch5.transform.parent = gameObject.transform;
	}
}
