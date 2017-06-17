using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : Collectable {

	public HealthBar lives;

	
	protected override void OnRabbitHit (HeroRabbit rabit)
	{

		lives.getLive();
		this.CollectedHide ();
	}
}
