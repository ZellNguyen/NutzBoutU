using UnityEngine;
using System.Collections;
using Spine.Unity;

public class Climb : MonoBehaviour {

	public float step;

	float lowerBound;
	float upperBound;

	Animator anim;

	bool isTouching;

	Vector2 startTouchPoint;
	Vector2 endTouchPoint;

	float comfortZone; 

	public GameObject tony_Body;

	// Use this for initialization
	void Start () {
		lowerBound = -step * 2;
		upperBound = step * 2;
		anim = GetComponent<Animator> ();
		isTouching = false;
		comfortZone = 50f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {

			var touch = Input.touches [0];

			switch (touch.phase) {

				case TouchPhase.Began:
					isTouching = true;
					startTouchPoint = touch.position;
					break;

				case TouchPhase.Stationary:
					break;

				case TouchPhase.Ended:
					endTouchPoint = touch.position;
					var verticalSwipeRange = endTouchPoint.y - startTouchPoint.y;
					if (verticalSwipeRange < -comfortZone && transform.position.y > lowerBound && !anim.IsInTransition (0)) {
						//Debug.Log ("Climb");
						anim.SetTrigger ("MoveDown");
						StartCoroutine (climbAnimation ());
					} else if (verticalSwipeRange > comfortZone && transform.position.y < upperBound && !anim.IsInTransition (0)) {
						//Debug.Log ("Climb");
						anim.SetTrigger ("MoveUp");
						StartCoroutine (climbAnimation ());
					}
					isTouching = false;
					break;
				}
			}
	}

	IEnumerator climbAnimation() {
		tony_Body.GetComponent<SkeletonAnimation> ().state.SetAnimation (0, "animation", true);
		yield return new WaitForSeconds (0.2f);
		tony_Body.GetComponent<SkeletonAnimation> ().state.SetAnimation (0, "animation", false);
	}
		
}
