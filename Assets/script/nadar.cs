using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nadar : MonoBehaviour {
	public float forcaPulo;
	public float velocidadeMaxima;

	public int lives;
	public int rings;

	public Text TextLives;
	public Text TextRings;


	public bool naAgua;

	void Start()
	{
		
	}

	void Update()
	{
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

		float movimento = Input.GetAxis("Horizontal");


		rigidbody.velocity = new Vector2(movimento * velocidadeMaxima, rigidbody.velocity.y);

		if (movimento < 0)
		{
			GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (movimento > 0)
		{
			GetComponent<SpriteRenderer>().flipX = false;
		}
			


		if (movimento > 0 || movimento < 0)
		{
			GetComponent<Animator>().SetBool("nadando", true);
		}
		else
		{
			GetComponent<Animator>().SetBool("nadando", false);
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			rigidbody.AddForce(new Vector2(0, 6f * Time.deltaTime), ForceMode2D.Impulse);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			rigidbody.AddForce(new Vector2(0, -6f * Time.deltaTime), ForceMode2D.Impulse);
		}

		rigidbody.AddForce(new Vector2(0, 10f * Time.deltaTime), ForceMode2D.Impulse);
	


		GetComponent<Animator>().SetBool("nadando", naAgua);
	}

	private void OnTriggerEnter2D(Collider2D collision2D)
	{
		if (collision2D.gameObject.CompareTag("agua"))
		{
			naAgua = true;
		}
	}







}
