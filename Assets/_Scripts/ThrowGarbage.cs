using UnityEngine;
using System.Collections;

public class ThrowGarbage : MonoBehaviour {

	public float speed;

	private GameObject tony;
	private Vector3 tonyPosition;

	private Vector3 moveVector; 
	private Vector3 origin;

	Plane[] planes;

	// Use this for initialization
	void Start () {
		tony = GameObject.Find ("Tony/Tony_Body");
		tonyPosition = tony.transform.position;

		origin = transform.position;

		var random = Random.value > 0.8 ? true : false;

		if (random)
			moveVector = (tonyPosition - origin) / Vector3.Distance (tonyPosition, origin);
		else
			moveVector = Vector3.left;

		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (moveVector * Time.deltaTime * speed);
	}
}
