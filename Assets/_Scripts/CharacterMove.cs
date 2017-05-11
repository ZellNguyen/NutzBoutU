using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	Animator ani;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D))
			ani.SetBool ("KeyRight", true);
		else if (Input.GetKey (KeyCode.A))
			ani.SetBool ("KeyLeft", true);
		else {
			ani.SetBool ("KeyRight", false);
			ani.SetBool ("KeyLeft", false);
		}


	}
}
