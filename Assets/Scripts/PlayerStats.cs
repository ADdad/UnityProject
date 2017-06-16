using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerStats : MonoBehaviour {

	bool[] all_crystals = null;
	bool level1 = false;
	bool level2 = false;
	int coins = 0;
	public bool[] fruits = null;
	public bool[] fruits2 = null;

	public static PlayerStats stat = new PlayerStats();


	public void setCoins(int coins){this.coins=coins;}
	public void addFruit(int id){fruits[id]=true;}
	public void setMaxFruits(int quantity){
		if(fruits==null)fruits = new bool[quantity];
		else if(quantity>fruits.Length)fruits = new bool[quantity];
	}
	public void endLevel1(bool isit){level1=isit;}
	public void allCrystalsSet(int level,bool isit){
		if(all_crystals==null)all_crystals=new bool[2];
		all_crystals[level]=isit;
	}
	public void addCoin(){coins++;}


	public int getCoins(){return coins;}
	public bool isLevelEnded(int n){
		if(n==1)return level1;
		else return level2;
	}
	public bool isLevel2Ended(){return level2;}
	public bool allCrystalsGet(int level){return all_crystals[level];}
	public int getMaxFruits(){return fruits.Length;}
	public int collectedFruits(){
		if(fruits==null)return 0;
		int col = 0;
		for(int i=0; i<fruits.Length; i++){if(fruits[i])col++;}
		return col;
	}

	/*class LevelStat {
		public bool all_crystal = false;
		public bool level1 = false;
		public bool level2 = false;
		public int coins = 0;
		public bool[] fruits = null;
	}*/




	public void saveStatistics(){
		LevelStat ls = new LevelStat();
		ls.all_crystal = PlayerStats.stat.all_crystals[0];
		ls.level1 = PlayerStats.stat.isLevelEnded(1);
		ls.level2 = PlayerStats.stat.isLevelEnded(2);
		ls.coins = PlayerStats.stat.getCoins();
		ls.fruits = PlayerStats.stat.fruits;
		string str = JsonUtility.ToJson(ls);
		PlayerPrefs.SetString("stats", str);
		PlayerPrefs.Save();
	}

	public void unloadStatistics(){
		string str = PlayerPrefs.GetString ("stats", null);
		LevelStat ls = JsonUtility.FromJson<LevelStat>(str);
		/*if(ls==null || PlayerStats.stat==null) {
		PlayerStats.stat = this;
	}*/
	if(ls!=null){
		PlayerStats.stat.allCrystalsSet(0, ls.all_crystal);
		PlayerStats.stat.endLevel1(ls.level1);
		PlayerStats.stat.setCoins(ls.coins);
		PlayerStats.stat.fruits = ls.fruits;
		}	
	}

	public void loadStatistics(){
		string str = PlayerPrefs.GetString ("stats", null);
		LevelStat ls = JsonUtility.FromJson<LevelStat>(str);
		if(ls!=null){
		this.allCrystalsSet(0, ls.all_crystal);
		this.endLevel1(ls.level1);
		this.setCoins(ls.coins);
		this.fruits = ls.fruits;
		}
		else{
			this.all_crystals = new bool[2];
			this.fruits = new bool[2];
		}
		stat = this;	
		Debug.Log("Load end");
	}


	
}
