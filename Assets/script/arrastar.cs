using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class arrastar : MonoBehaviour {
	public Transform obj;
	Vector2 vec2;
	Vector2 scrennpoint;
	Vector2 offset;
	Vector3 posInicial;

	float distancia;

	[HideInInspector]
	public bool estaConectado;

	[Range(1, 15)]
	public float velocidadeDeMovimento = 10;

	[Space(10)]
	public Transform conector;

	[Range(0.1f, 2.0f)]
	public float distanciaMinimaConector = 0.5f;


	void Start (){
		posInicial = transform.position;

	}

	void OnMouseDown () {
		scrennpoint = Camera.main.WorldToScreenPoint (obj.position);
		offset = obj.position - Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
	}


	void OnMouseDrag () {
		vec2 = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		obj.position = Camera.main.ScreenToWorldPoint (vec2) + new Vector3 (offset.x, offset.y, 1);
	}

	void FixedUpdate (){
		if (!estaConectado) {
			distancia = Vector2.Distance (transform.root.position, conector.position);
			transform.position = posInicial;

		}
		
			if (distancia < 1f) {
				estaConectado = true;
			Destroy(gameObject);
			}

		}
}
