using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveoffset : MonoBehaviour {
	private Material material;
	public float velocidadeX, velocidadeY;
	public float incremento;
	private float offset;
	// Use this for initialization
	void Start () {

		material = GetComponent<Renderer> ().material;
		
	}
	
	// Update is called once per frame
	void Update () {

		offset += incremento;

		material.SetTextureOffset ("_MainTex", new Vector2 (offset * velocidadeX, offset * velocidadeY));
	}
}
