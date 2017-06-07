using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {


    GameObject grandChild;
    int chld = 0;
    public Sprite change;

    void Start(){
    	chld = transform.childCount;
    }

    public void die()
    {
    	chld--;

        grandChild = this.gameObject.transform.GetChild(chld).gameObject;
        grandChild.GetComponent<UI2DSprite>().sprite2D = change;
        if(chld<1){SceneManager.LoadScene ("ChooseLevelScene");}

    }
}
