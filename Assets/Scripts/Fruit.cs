using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {

	public UILabel coinsLabel;

	public static int id = 0;
	static int fruits_quantity = 0;
	static int fruits_max = 0;
	static int lvl = LevelController.current.Level;
	int curr_id = 0;

	void Start(){
		/*if(LevelController.current.Level!=lvl){
			id=0;
			lvl = LevelController.current.Level;
		}
		string str = PlayerPrefs.GetString ("stats", null);
		if(str!=null){
		LevelStat ls = JsonUtility.FromJson<LevelStat>(str);
		if(lvl==1 && ls.fruits!=null){
			if(ls.fruits[curr_id])changeOpacity();
		}
		if(lvl==2  && ls.fruits2!=null){
			if(ls.fruits2[curr_id])changeOpacity();
		}
		}	
	*/	

		fruits_quantity = 0;
		curr_id = id;
		id++;
		fruits_max = id;
		PlayerStats.stat.setMaxFruits(id, lvl);
		coinsLabel.text = fruits_quantity+"/"+fruits_max;
		if(PlayerStats.stat.fruits[curr_id])changeOpacity();
	} 

	void changeOpacity(){
		this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f); 
	}
	
	protected override void OnRabbitHit (HeroRabbit rabit)
	{	
		
		PlayerStats.stat.addFruit(curr_id);
		fruits_quantity++;
		coinsLabel.text = fruits_quantity+"/"+fruits_max;
		this.CollectedHide();
	}
}
