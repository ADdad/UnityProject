using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {

	public UILabel coinsLabel;

	static int fruits_quantity = 0;
	public int fruits_max = 11;
	protected override void OnRabbitHit (HeroRabbit rabit)
	{

		fruits_quantity++;
		coinsLabel.text = fruits_quantity+"/"+fruits_max;
		this.CollectedHide ();
	}
}
