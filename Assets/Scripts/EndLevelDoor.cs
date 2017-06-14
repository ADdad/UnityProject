using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelDoor : MonoBehaviour {


	public GameObject winScreenPrefab;

void OnTriggerEnter2D(Collider2D collider){
	HeroRabbit rabit = collider.GetComponent<HeroRabbit>();

		if(rabit != null){
			GameObject parent = UICamera.first.transform.parent.gameObject;

			GameObject obj = NGUITools.AddChild(parent, winScreenPrefab);

			WinScreenPopUp popup = obj.GetComponent<WinScreenPopUp>();

			popup.setCoins(5);
			popup.setFruits(5, 11);

		}
		
}
}