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
			
			
		
			CrystalBar cb = (CrystalBar)LevelController.current.cb;
			if(SceneManager.GetActiveScene().name=="Level2"){
				popup.setCoins(PlayerStats.stat.getCoins2());
				PlayerStats.stat.endLevel2(true);
				PlayerStats.stat.allCrystalsSet(1, cb.collectedCrystals()==3);
				popup.setFruits(PlayerStats.stat.collectedFruits(), PlayerStats.stat.getMaxFruits());
			}
			else {
			popup.setCoins(PlayerStats.stat.getCoins());
			PlayerStats.stat.endLevel1(true);
			PlayerStats.stat.allCrystalsSet(0, cb.collectedCrystals()==3);
			popup.setFruits(PlayerStats.stat.collectedFruits(), PlayerStats.stat.getMaxFruits());
			}
			PlayerStats.stat.saveStatistics();
		}
		
}
}