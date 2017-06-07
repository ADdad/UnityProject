using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MyButton : MonoBehaviour {

    public UnityEvent signalOnClick = new UnityEvent();
    public void _onClick()
    {
        this.signalOnClick.Invoke();
        Debug.Log("MB1");
    }



    void Start()
    {
      signalOnClick.AddListener(this.onPlay);
    }
    void onPlay()
    {	
    	Debug.Log("MB");
        SceneManager.LoadScene("ChooseLevelScene");
    }
}

