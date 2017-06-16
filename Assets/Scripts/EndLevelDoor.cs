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
			popup.setCoins(PlayerStats.stat.getCoins());
			popup.setFruits(PlayerStats.stat.collectedFruits(), PlayerStats.stat.getMaxFruits());
			/*popup.setCoins(PlayerStatistics.ps.coins);
			popup.setFruits(PlayerStatistics.ps.colectedFruits, PlayerStatistics.ps.fruits.Length);
			CrystalBar cb = (CrystalBar)LevelController.current.cb;
			PlayerStatistics.ps.all_crystals = (cb.collectedCrystals()==3);
			PlayerStatistics.ps.level1 = true;
			string str = JsonUtility.ToJson(PlayerStatistics.ps);
			PlayerPrefs.SetString("stats", str);
			PlayerPrefs.Save();*/
			CrystalBar cb = (CrystalBar)LevelController.current.cb;
			PlayerStats.stat.endLevel1(true);
			
			PlayerStats.stat.allCrystalsSet(0, cb.collectedCrystals()==3);
			PlayerStats.stat.saveStatistics();
		}
		
}
}