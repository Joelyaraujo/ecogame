using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnComandos : MonoBehaviour {
	private fade fade;
	private SoundControler soundcontroler;



	void Start (){
		soundcontroler = FindObjectOfType (typeof(SoundControler)) as SoundControler;
		fade = FindObjectOfType (typeof(fade)) as fade; 

	}

	//carrega uma nova cena
  public void irParaCena(string nomeCena){
		soundcontroler.playButton ();	

		//if(SceneManager.GetActiveScene().name != "Título" && SceneManager.GetActiveScene().name != "Temas 1"){
			//soundcontroler.AudioMusic.clip = soundcontroler.musicas [0];
			//soundcontroler.AudioMusic.Play ();
		//}
		StartCoroutine ("transicao", nomeCena);

	}



	//fecha o aplicativo
	public void sair(){
		Application.Quit ();
	}

	public void jogarNovamente(){
		soundcontroler.playButton ();		
		int idCena = PlayerPrefs.GetInt ("idTema");
		if (idCena != 0) {
			SceneManager.LoadScene (idCena.ToString ());
		}
	}
	 
	IEnumerator transicao(string nomeCena){
		fade.fadeIn();
		yield return new WaitWhile (() => fade.fume.color.a < 0.9f);
		SceneManager.LoadScene (nomeCena);
	}

}
