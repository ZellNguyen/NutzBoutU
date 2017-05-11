using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

	public void Menu() {
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
}
