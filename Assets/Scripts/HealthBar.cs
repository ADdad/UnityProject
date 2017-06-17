using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {


    GameObject grandChild;
    public GameObject loseScreenPrefab;
    public int chld = 0;
    public Sprite change;
    public Sprite hp;
    void Start(){
    	chld = transform.childCount;
    }

    public void die()
    {
    	chld--;

        grandChild = this.gameObject.transform.GetChild(chld).gameObject;
        grandChild.GetComponent<UI2DSprite>().sprite2D = change;
        if(chld<1){
            GameObject parent = UICamera.first.transform.parent.gameObject;

            GameObject obj = NGUITools.AddChild(parent, loseScreenPrefab);
        }

    }

    public void getLive()
    {       
        if(chld<3){
        

        grandChild = this.gameObject.transform.GetChild(chld).gameObject;
        grandChild.GetComponent<UI2DSprite>().sprite2D = hp;
        chld++;
    }
    }
}
