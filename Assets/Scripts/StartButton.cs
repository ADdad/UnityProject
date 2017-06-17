using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	public static StartButton st;
	public MyButton playButton;
	public AudioClip music = null;
	AudioSource musicSource = null;
	void Start () {
		playButton.signalOnClick.AddListener(this.onPlay);
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = music;
		musicSource.loop = true;
		if(SoundManager.Instance.isMusicOn())musicSource.Play();
		st = this;
	}
	void onPlay() {
		PlayerPrefs.SetString("stats", null);
		PlayerPrefs.Save();
		SceneManager.LoadScene ("ChooseLevelScene");
	}

	public void onMusic(){
		if(SoundManager.Instance.isMusicOn())musicSource.Play();
	}

	public void offMusic(){
		musicSource.Stop();
	}

}
