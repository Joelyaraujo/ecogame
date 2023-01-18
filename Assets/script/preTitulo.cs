using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class preTitulo : MonoBehaviour {

	private fade fade;
	public int tempoEspera;

	// Use this for initialization
	void Start () {

		Screen.SetResolution (1920, 1080, false);
		fade = FindObjectOfType (typeof(fade)) as fade; 
		StartCoroutine("esperar");

	}
	

	IEnumerator esperar(){

		yield return new WaitForSeconds (tempoEspera);
		fade.fadeIn ();

		yield return new WaitWhile (() => fade.fume.color.a < 0.9f);
		SceneManager.LoadScene ("Título");

	}

}
