using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {

	protected override void OnRabbitHit (HeroRabbit rabit)
	{
		if(!rabit.getGhost())this.CollectedHide();
		rabit.boomCatch();
	}
}