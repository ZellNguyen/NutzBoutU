using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveGround : MonoBehaviour {

	// Moving step
	public float speed;
	GameObject character;
	public bool isMovable; 
	float moveDuration; 

	bool isTouching;
	Vector2 startTouchPoint;
	Vector2 endTouchPoint;
	float comfortZone = 50f;

	// Lock Camera 
	public bool isCameraLocked = false;

	// Stage Counter 
	public int stage = 0;

	public GameObject windows;
	public GameObject nuts;

	// Number of Enemies
	public int numberOfNeighborsHit = 0;
	private int numberOfNeighborsInScreen = 0;

	// Cut Scene Object
	public Image cutScene;
	public Button nextButton;

	// Background
	public GameObject Background;

	// Tutorial
	public GameObject tutorialsObject;
	public Image[] tutorials;

	// Camera 
	public Camera main;
	public AudioClip bossClip;

	// Use this for initialization
	void Start () {
		cutScene.enabled = false;
		nextButton.gameObject.SetActive (false);

		isMovable = true;
		character = GameObject.Find ("Tony");
		moveDuration = 0.6f;

		isTouching = false;
		PlotWrite (stage);

		// Tutorial 
		foreach (Image tutorial in tutorials) {
			tutorial.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			var touch = Input.touches [0];
			switch (touch.phase){
				case TouchPhase.Began: 
					isTouching = true;
					startTouchPoint = touch.position;
					break;

				case TouchPhase.Stationary:
					break;

				case TouchPhase.Ended: 
					endTouchPoint = touch.position;
					var verticalSwipeRange = endTouchPoint.y - startTouchPoint.y;
				if (verticalSwipeRange > comfortZone && character.transform.position.y == 5f && isMovable && isTouching && !isCameraLocked)
						StartCoroutine (moveUp ());
					isTouching = false;
					break;
			}
		}
		if (numberOfNeighborsHit == numberOfNeighborsInScreen) {
			isCameraLocked = false;
		}
	}

	IEnumerator moveUp(){
		// Clone Windows before final stage
		if (stage < 7) {
			var windows = GameObject.Find ("EndlessBG/BackGround/Windows_Array");
			windows.GetComponent<InstantiateWindow> ().Clone ();

			var floors = GameObject.Find ("EndlessBG/Floors");
			floors.GetComponent<InstantiateFloors> ().Clone ();

			var branches = GameObject.Find ("EndlessBG/Branches");
			branches.GetComponent<InstantiateBranches> ().Clone ();
		} else {
			Time.timeScale = 0;
			cutScene.gameObject.SetActive (true);
			cutScene.enabled = true;
			nextButton.gameObject.SetActive (true);

			main.GetComponent<AudioSource> ().clip = bossClip;
			main.GetComponent<AudioSource> ().Play ();

			var windows = GameObject.Find ("EndlessBG/BackGround/Windows_Array");
			windows.GetComponent<InstantiateWindow> ().SetUpForFinalStage ();

			var floors = GameObject.Find ("EndlessBG/Floors");
			floors.GetComponent<InstantiateFloors> ().SetUpForFinalStage ();

			var branches = GameObject.Find ("EndlessBG/Branches");
			branches.GetComponent<InstantiateBranches> ().SetUpForFinalStage ();
		}

		isMovable = false;
		Vector3 origin = transform.position;
		var tony = GameObject.Find ("Tony");
		Vector3 bgOrigin = Background.transform.position;
		//Debug.Log (origin - Vector3.up * speed);
		float t = 0;
		tony.GetComponent<Animator> ().CrossFade ("Tony_Down2", 0.6f);
		do{
			transform.position = Vector3.Lerp (origin, origin - Vector3.up * speed, t);
			Background.transform.position = Vector3.Lerp(bgOrigin, bgOrigin - Vector3.up, t);
			t += Time.deltaTime / moveDuration;
			yield return 0;
		}while(Vector3.Distance(origin, transform.position) < 10.0f);
			
		isMovable = true;
		stage++;

		numberOfNeighborsHit = 0;
		PlotWrite (stage);

		//Invoke ("RandomCall", 2f);
	}

	IEnumerator OpenWindow(int numbers, float delay, bool canInsult){
		for (int i=0; i< numbers; i++) {
			yield return new WaitForSeconds (delay);
			GameObject windows = GameObject.Find ("EndlessBG/BackGround/Windows_Array");

			if (canInsult) {
				windows.GetComponent<RandomlyOpen> ().RandomCallGenerally ();
			} else {
				windows.GetComponent<RandomlyOpen> ().RandomCallGarbage ();
			}

		}
	}

	void PlotWrite(int stage) {
		Debug.Log ("STAGE: " + stage);
		switch (stage) {
		case 0:
			nuts.SetActive (false);
			//StartCoroutine (tutorialsObject.GetComponent<Guide>().showTutorial (new Image[]{tutorials[0]}));
			break;
		case 1:
			//nuts.SetActive (true);
			//isCameraLocked = true;
			numberOfNeighborsInScreen = 1;
			//StartCoroutine (tutorialsObject.GetComponent<Guide>().showTutorial (new Image[]{tutorials[1]}));
			StartCoroutine(OpenWindow(numberOfNeighborsInScreen, 1, false));
			break;
		case 2:
			nuts.SetActive (true);
			isCameraLocked = true;
			numberOfNeighborsInScreen = 3;
			StartCoroutine(OpenWindow(numberOfNeighborsInScreen, 1, false));
			//StartCoroutine (tutorialsObject.GetComponent<Guide>().showTutorial (new Image[]{ tutorials [2], tutorials [3] }));
			break;
		case 3:
			nuts.SetActive (true);
			isCameraLocked = true;
			var noiseMeterFrozen = GameObject.Find ("NoiseMeterFrozen");
			noiseMeterFrozen.SetActive (false);
			numberOfNeighborsInScreen = 4;
			StartCoroutine (OpenWindow (numberOfNeighborsInScreen, 1, true));
			//StartCoroutine (tutorialsObject.GetComponent<Guide>().showTutorial (new Image[]{ tutorials [4] }));
			break;
		case 4:
			nuts.SetActive (true);
			isCameraLocked = true;
			numberOfNeighborsInScreen = 4;
			StartCoroutine (OpenWindow (numberOfNeighborsInScreen, 1, true));
			break;
		case 5:
			nuts.SetActive (true);
			isCameraLocked = true;
			numberOfNeighborsInScreen = 4;
			StartCoroutine (OpenWindow (numberOfNeighborsInScreen, 1, true));
			break;
		case 6: 
			nuts.SetActive (true);
			isCameraLocked = true;
			numberOfNeighborsInScreen = 4;
			StartCoroutine (OpenWindow (numberOfNeighborsInScreen, 1, true));
			break;
		case 7:
			nuts.SetActive (true);
			isCameraLocked = true;
			numberOfNeighborsInScreen = 4;
			StartCoroutine (OpenWindow (numberOfNeighborsInScreen, 1, true));
			//StartCoroutine (tutorialsObject.GetComponent<Guide>().showTutorial (new Image[]{ tutorials [5] }));
			break;
		case 8:
			nuts.SetActive (true);
			isCameraLocked = true;
			numberOfNeighborsInScreen = 4;
			//StartCoroutine (OpenWindow (numberOfNeighborsInScreen, 1, true));
			break;
		default:
			break;
		}
	}
}
