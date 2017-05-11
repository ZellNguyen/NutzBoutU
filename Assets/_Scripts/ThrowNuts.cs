using UnityEngine;
using System.Collections;

public class ThrowNuts : MonoBehaviour {

	float angle; 
	float upperBound;
	float lowerBound;
	float force; 

	float comfortZone;

	Vector2 startTouchPoint;
	Vector2 currentTouchPoint;

	public GameObject tonyBody;

	public Rigidbody2D nut;

	bool fireTrigger;

	public int angleStep;

	public int numberOfNuts;

	//Sound
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		angle = 0;
		upperBound = 60f;
		lowerBound = 0f;
		force = 500f;
		fireTrigger = false;

		comfortZone = 50f;

		numberOfNuts = 0;

		// Sound
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (angle);
		/*if (Input.GetKey (KeyCode.Space)) {
			angle++; 
			angle = Mathf.Clamp (angle, lowerBound, upperBound); 
			transform.rotation = Quaternion.Euler (0, 0, angle);
		} else if (Input.GetKeyUp (KeyCode.Space)){
			Throw ();
			angle = 0;
			transform.rotation = Quaternion.identity;
		}*/
	
		if (Input.touchCount > 0) {

			var touch = Input.touches [0];
  
			switch (touch.phase) {
			case TouchPhase.Began:
				startTouchPoint = touch.position;
				fireTrigger = true;
				break;

			case TouchPhase.Moved:
				currentTouchPoint = touch.position;

				var swipeRangeX = Mathf.Abs (currentTouchPoint.x - startTouchPoint.x);
				var swipeRangeY = Mathf.Abs (currentTouchPoint.y - startTouchPoint.y);

				if (swipeRangeX < comfortZone && swipeRangeY < comfortZone && fireTrigger) {
					angle += angleStep; 
					angle = Mathf.Clamp (angle, lowerBound, upperBound); 
					transform.rotation = Quaternion.Euler (0, 0, angle);
				} else
					fireTrigger = false;
				break;

			case TouchPhase.Stationary:
				if (fireTrigger) {
					angle += angleStep; 
					angle = Mathf.Clamp (angle, lowerBound, upperBound); 
					transform.rotation = Quaternion.Euler (0, 0, angle);
				} 
				break;

			case TouchPhase.Ended:
				if (fireTrigger && numberOfNuts > 0)
					Throw ();
				angle = 0;
				transform.rotation = Quaternion.identity;
				fireTrigger = false;
				break;

			case TouchPhase.Canceled:
				if (fireTrigger && numberOfNuts > 0)
					Throw ();
				angle = 0;
				transform.rotation = Quaternion.identity;
				fireTrigger = false;
				break;

			default:
				fireTrigger = false;
				break;
			}
			//Debug.Log (angle);
		}
	}
		
	void Throw (){
		Rigidbody2D nutInstance;

		float angleInRad = angle / 180 * Mathf.PI;

		float forceCoeff = angle * 3f;

		nutInstance = Instantiate (nut, tonyBody.transform.position, Quaternion.identity) as Rigidbody2D;
		nutInstance.AddForce ( new Vector2 ( Mathf.Cos(angleInRad), Mathf.Sin(angleInRad) ) * (force + forceCoeff));
		nutInstance.transform.parent = GameObject.Find ("Nuts").transform;

		audioSource.Play ();

		numberOfNuts--;
	}
}
