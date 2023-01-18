using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemaScene : MonoBehaviour {
	private SoundControler soundcontroler;
	private fade fade;
	public Text nomeTemaTxt;
	public Button btnJogar;



	// Use this for initialization
	void Start () {
		fade = FindObjectOfType (typeof(fade)) as fade; 
		soundcontroler = FindObjectOfType (typeof(SoundControler)) as SoundControler;
		btnJogar.interactable = false;
	}
		

	public void jogar(){
		soundcontroler.playButton ();
		//soundcontroler.AudioMusic.clip = soundcontroler.musicas [1];
		//soundcontroler.AudioMusic.Play ();


		int idCena = PlayerPrefs.GetInt ("idTema");
		if (idCena != 0) {

			StartCoroutine ("transicao", idCena.ToString ());
			SceneManager.LoadScene (idCena.ToString ());
		}
		
	}


	IEnumerator transicao(string nomeCena){
		fade.fadeIn();
		yield return new WaitWhile (() => fade.fume.color.a < 0.9f);
		SceneManager.LoadScene (nomeCena);
	}
}
