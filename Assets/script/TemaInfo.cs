using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TemaInfo : MonoBehaviour {
	private SoundControler soundcontroler;
	private TemaScene temaScene;
	private fade fade;


	[Header("configuração do tema")]
	public int idTema;
	public string nomeTema;
	public Color corTema;

	[Header("configuração das Estrelas")]
	public int notaMin1Estrela;
	public int notaMin2Estrelas;

	[Header("configuração do botão")]
	public Text idTemaTxt;
	public GameObject[] estrela;
	private int notaFinal;

	public int nivel;



	// Use this for initialization
	void Start () {
		soundcontroler = FindObjectOfType (typeof(SoundControler)) as SoundControler;
		fade = FindObjectOfType (typeof(fade)) as fade; 

		notaFinal = PlayerPrefs.GetInt ("notaFinal_" + idTema.ToString ());

		temaScene= FindObjectOfType (typeof(TemaScene)) as TemaScene;

		idTemaTxt.text = idTema.ToString ();
		estrelas ();

	}

	public void selecionarTema(){
		temaScene.nomeTemaTxt.text = nomeTema;
		temaScene.nomeTemaTxt.color = corTema;

		PlayerPrefs.SetInt ("idTema", idTema);
		PlayerPrefs.SetString ("nomeTema", nomeTema);
		PlayerPrefs.SetInt ("notaMin1Estrela", notaMin1Estrela);
		PlayerPrefs.SetInt ("notaMin2Estrelas", notaMin2Estrelas);

		temaScene.btnJogar.interactable = true;
	}
	


	public void estrelas(){
		
		foreach (GameObject e in estrela) {
			e.SetActive (false);

		}

		int nEstrelas = 0;


		if (notaFinal== 10) {
			nEstrelas = 3;
		} else if (notaFinal >= notaMin2Estrelas) {
			nEstrelas = 2;
		}
		else if (notaFinal >= notaMin1Estrela) {
			nEstrelas = 1;
		}

		for (int i = 0; i < nEstrelas; i++) {
			estrela [i].SetActive (true);

		}
	}



}
