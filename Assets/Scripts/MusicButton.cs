using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicButton : MonoBehaviour {

	public MyButton playButton;
	public Sprite oned;
	public Sprite off;

	void Start () {
		playButton.signalOnClick.AddListener(this.onPlay);
		if(SoundManager.Instance.isMusicOn())this.GetComponent<UI2DSprite>().sprite2D = oned;
		else this.GetComponent<UI2DSprite>().sprite2D = off;
	}
	void onPlay() {
		SoundManager.Instance.setMusicOn(!SoundManager.Instance.isMusicOn());
		if(SoundManager.Instance.isMusicOn()){
			this.GetComponent<UI2DSprite>().sprite2D = oned;
			if(SceneManager.GetActiveScene().name=="MainMenu")StartButton.st.onMusic();
			else HeroRabbit.lastRabbit.onMusic();
		}
		else {
			this.GetComponent<UI2DSprite>().sprite2D = off;
			if(SceneManager.GetActiveScene().name=="MainMenu")StartButton.st.offMusic();
			else HeroRabbit.lastRabbit.offMusic();
			
		}
	}
}
