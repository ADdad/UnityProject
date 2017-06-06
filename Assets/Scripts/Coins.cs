using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {

	public UILabel coinsLabel;

	static int coins_quantity = 0;
	protected override void OnRabbitHit (HeroRabbit rabit)
	{

		coins_quantity++;
		string coins = coins_quantity.ToString();
		int cLength = coins.Length;
		for(int i=0;i<4-cLength; i++){
			coins="0"+coins;
		}
		coinsLabel.text = coins;
		this.CollectedHide ();
	}
}
