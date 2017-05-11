using UnityEngine;
using System.Collections;

public class InstantiateFloors : MonoBehaviour {

	public GameObject floor;
	public GameObject topFloor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clone() {
		GameObject floor0 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 7.5f, 0f), Quaternion.identity);
		GameObject floor1 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 10f, 0f), Quaternion.identity);
		GameObject floor2 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 12.5f, 0f), Quaternion.identity);
		GameObject floor3 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 15f, 0f), Quaternion.identity);
		//GameObject floor4 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 17.5f, 0f), Quaternion.identity);
		floor0.transform.parent = gameObject.transform;
		floor1.transform.parent = gameObject.transform;
		floor2.transform.parent = gameObject.transform;
		floor3.transform.parent = gameObject.transform;
		//floor4.transform.parent = gameObject.transform;
	}

	public void SetUpForFinalStage() {
		GameObject floor0 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 7.5f, 0f), Quaternion.identity);
		GameObject floor1 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 10f, 0f), Quaternion.identity);
		GameObject floor2 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 12.5f, 0f), Quaternion.identity);
		GameObject floor3 = (GameObject)Instantiate (floor, new Vector3 (2.25f, 15f, 0f), Quaternion.identity);
		//GameObject floor4 = (GameObject)Instantiate (topFloor, new Vector3 (2.25f, 17.5f, 0f), Quaternion.identity);
		floor0.transform.parent = gameObject.transform;
		floor1.transform.parent = gameObject.transform;
		floor2.transform.parent = gameObject.transform;
		floor3.transform.parent = gameObject.transform;
		//floor4.transform.parent = gameObject.transform;
	}
}
