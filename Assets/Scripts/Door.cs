using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	public string sceneName = "Level1";

void OnTriggerEnter2D(Collider2D collider){
	HeroRabbit rabit = collider.GetComponent<HeroRabbit>();

		if(rabit != null){
			SceneManager.LoadScene (sceneName);
		}
		
}
}