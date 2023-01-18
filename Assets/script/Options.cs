using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour {
	private SoundControler soundcontroler;
	public GameObject painel1, painel2, painel3;
	public Toggle onOffMusica, onOffEfeitos;
	public Slider volumeM, volumeE;

	void Start (){
		soundcontroler = FindObjectOfType (typeof(SoundControler)) as SoundControler;
		carregarPreferencias ();
		painel1.SetActive (true);
		painel2.SetActive (false);
		painel3.SetActive (false);

	}

	public void configuracoes(bool onOff){
		soundcontroler.playButton ();
		painel1.SetActive (!onOff);
		painel2.SetActive (onOff);

	}

	public void informacoes(bool onOff){
		soundcontroler.playButton ();
		painel1.SetActive (false);
		painel2.SetActive (false);
		painel3.SetActive (true);

	}

	public void voltarInfo(bool onOff){
		soundcontroler.playButton ();
		painel1.SetActive (true);
		painel2.SetActive (false);
		painel3.SetActive (false);

	}

	public void zerarProgresso(){
		soundcontroler.playButton ();

		int onOffM = PlayerPrefs.GetInt ("onOffMusica");
		int onOffE = PlayerPrefs.GetInt ("onOffEfeitos");
		float volumeMusica = PlayerPrefs.GetFloat ("volumeMusica");
		float volumeEfeitos = PlayerPrefs.GetFloat ("volumeEfeitos");

		PlayerPrefs.DeleteAll ();

		PlayerPrefs.SetInt ("valoresDefault", 1);
		PlayerPrefs.SetInt ("onOffMusica", onOffM);
		PlayerPrefs.SetInt ("onOffEfeitos", onOffE);
		PlayerPrefs.SetFloat ("volumeMusica", volumeMusica);
		PlayerPrefs.SetFloat ("volumeEfeitos", volumeEfeitos);
	}

	public void mutarMusica(){
		soundcontroler.AudioMusic.mute = !onOffMusica.isOn;
		if (onOffMusica.isOn == true) {
			PlayerPrefs.SetInt ("onOffMusica", 1);
		} else {
			PlayerPrefs.SetInt ("onOffMusica", 0);
		}

	}

	public void mutarEfeitos(){
		soundcontroler.AudioFX.mute = !onOffEfeitos.isOn;
		if (onOffEfeitos.isOn == true) {
			PlayerPrefs.SetInt ("onOffEfeitos", 1);
		} else {
			PlayerPrefs.SetInt ("onOffEfeitos", 0);
		}
	}

	public void volumeMusica(){
		soundcontroler.AudioMusic.volume = volumeM.value;
		PlayerPrefs.SetFloat ("volumeMusica", volumeM.value);
	}

	public void volumeEfeitos(){
		soundcontroler.AudioFX.volume = volumeE.value;
		PlayerPrefs.SetFloat ("volumeEfeitos", volumeE.value);
	}

	void carregarPreferencias(){

		int onOffM = PlayerPrefs.GetInt ("onOffMusica");
		int onOffE = PlayerPrefs.GetInt ("onOffEfeitos");
		float volumeMusica = PlayerPrefs.GetFloat ("volumeMusica");
		float volumeEfeitos = PlayerPrefs.GetFloat ("volumeEfeitos");

		bool tocarMusica = false;
		bool tocarEfeitos = false;

		if (onOffM == 1) {
			tocarMusica = true;
		}
		if (onOffE == 1) {
			tocarEfeitos = true;
		}

		onOffMusica.isOn = tocarMusica;
		onOffEfeitos.isOn = tocarEfeitos;

		volumeM.value = volumeMusica;
		volumeE.value = volumeEfeitos;

	}
}
