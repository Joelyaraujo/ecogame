using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour {

	public AudioSource AudioMusic, AudioFX; 
	public AudioClip somAcerto, somErro, somBotao, vinheta3Estrelas;
	public AudioClip[] musicas;


	void Awake(){

		DontDestroyOnLoad (this.gameObject);
	}


	// Use this for initialization
	void Start () {
		carregarPreferencias ();
		AudioMusic.clip = musicas [0];
		AudioMusic.Play ();

	}

	public void playAcerto(){
		AudioFX.clip = somAcerto;
		AudioFX.Play ();
		
	}

	public void playErro(){
		AudioFX.clip = somErro;
		AudioFX.Play ();

		
	}

	public void playButton(){
		AudioFX.clip = somBotao;
		AudioFX.Play ();

	}
	 
	public void playVinheta(){
		AudioFX.clip = vinheta3Estrelas;
		AudioFX.Play ();

	}
	void carregarPreferencias(){

		if (PlayerPrefs.GetInt ("valoresDefault") == 0) {
			PlayerPrefs.SetInt ("valoresDefault", 1);
			PlayerPrefs.SetInt ("onOffMusica", 1);
			PlayerPrefs.SetInt ("onOffEfeitos", 1);
			PlayerPrefs.SetFloat ("volumeMusica", 1);
			PlayerPrefs.SetFloat ("volumeEfeitos", 1);
		}

		int onOffMusica = PlayerPrefs.GetInt ("onOffMusica");
		int onOffEfeitos = PlayerPrefs.GetInt ("onOffEfeitos");
		float volumeMusica = PlayerPrefs.GetFloat ("volumeMusica");
		float volumeEfeitos = PlayerPrefs.GetFloat ("volumeEfeitos");

		bool tocarMusica = false;
		bool tocarEfeitos = false;

		if (onOffMusica == 1) {
			tocarMusica = true;
		}
		if (onOffEfeitos == 1) {
			tocarEfeitos = true;
		}

		AudioMusic.mute = !tocarMusica;
		AudioFX.mute = !tocarEfeitos;

		AudioMusic.volume = volumeMusica;
		AudioFX.volume = volumeEfeitos;
	}
}
