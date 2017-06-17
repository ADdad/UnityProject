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
		if(LevelController.current.Level!=lvl){
			id=0;
			lvl = LevelController.current.Level;
		}
		fruits_quantity = 0;
		curr_id = id;
		id++;
		fruits_max = id;
		PlayerStats.stat.setMaxFruits(id);
		coinsLabel.text = fruits_quantity+"/"+fruits_max;
	}
	
	protected override void OnRabbitHit (HeroRabbit rabit)
	{	
		
		PlayerStats.stat.addFruit(curr_id);
		fruits_quantity++;
		coinsLabel.text = fruits_quantity+"/"+fruits_max;
		this.CollectedHide();
	}
}
