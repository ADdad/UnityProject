using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController current;
	Vector3 startingPosition;
	public HealthBar hb;
	public CrystalBar cb;
	public int Level = 0;
	void Awake() {
		current = this;
	}


	public void setStartPosition(Vector3 pos){
		this.startingPosition = pos;
	}

	public void onRabbitDeath(HeroRabbit rabit){
		rabit.transform.position = this.startingPosition;
		hb.die();
	}
}
