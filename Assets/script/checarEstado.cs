using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checarEstado : MonoBehaviour {
	private SoundControler soundControler;
	private fade fade;
	public bool completou;
	float cronometro;
	public string nomeCena;
	arrastar [] objetos;
	// Use this for initialization
	void Start () {
		soundControler = FindObjectOfType (typeof(SoundControler)) as SoundControler;
		cronometro = 0;
		completou = false;
		objetos = FindObjectsOfType<arrastar> ();


	}
	
	// Update is called once per frame
	void Update () {
		cronometro += Time.deltaTime;

		if (cronometro >= 0.2f) {
			cronometro = 0;
			int soma = 0;
			for (int x = 0; x < objetos.Length; x++) {
				if (objetos [x].estaConectado) {
					soma++;
				}
			}
			if (soma >= objetos.Length) {
				completou = true;
			}
			if (completou == true) {
				StartCoroutine ("aguardarProxima");
			}
	}
}
	public void irParaCena(string nomeCena){
		SceneManager.LoadScene (nomeCena);
	}
	IEnumerator aguardarProxima(){
		yield return new WaitForSeconds (2.0f);
		irParaCena (nomeCena);
	}
}