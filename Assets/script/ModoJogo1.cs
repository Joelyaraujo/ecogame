using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModoJogo1 : MonoBehaviour {

	public int nivel;


	[Header("Configuração dos textos")]
	public Text perguntaTxt;
	public Image perguntaImg;
	public Text infoRespostasTxt;
	public Text notaFinalTxt;
	public Text msg1Txt;
	public Text msg2Txt;

	[Header("Configuração dos textos alternativas")]
	public Text altAtxt; 
	public Text altBtxt; 
	public Text altCtxt; 
	public Text altDtxt; 

	[Header("Configuração das imagens alternativas")]
	public Image  altAimg; 
	public Image  altBimg; 
	public Image  altCimg; 
	public Image  altDimg; 

	[Header("Configuração das barras")]
	public GameObject barraProgresso;
	public GameObject barraTempo;

	[Header("Configuração dos botões")]
	public Button[] botoes;
	public Color corAcerto, corErro;

	[Header("Configuração do modo de jogo")]
	public bool perguntasComImg;
	public bool perguntasAleatorias;
	public bool utilizarAternativas;
	public bool utilizarAternativasImg;
	public bool jogarComTempo;
	public float tempoResponder;
	public bool mortrarCorreta;
	public int qtdPiscar;


	[Header("Configuração das perguntas")]
	public string[] perguntas;
	public Sprite[] perguntasImg;
	public string[] correta;
	public int qtdPerguntas;
	public List<int> listaPerguntas;

	[Header("Configuração das alternativas")]
	public string[] alternativasA;
	public string[] alternativasB;
	public string[] alternativasC;
	public string[] alternativasD;

	[Header("Configuração das alternativas Img")]
	public Sprite[] alternativasAimg;
	public Sprite[] alternativasBimg;
	public Sprite[] alternativasCimg;
	public Sprite[] alternativasDimg;

	[Header("Configuração dos paineis")]
	public GameObject[] paineis;
	public GameObject[] estrela;

	[Header("Configuração das mensagens")]
	public string[] mensagem1;
	public string[] mensagem2;
	public Color[] corMensagem;
	//----------------------

	private int idResponder, qtdAcertos, notaMin1Estrela, notaMin2Estrelas, nEstrelas, idTema, idBtnCorreto;
	private float pecProgresso, pecTempo, qtdRespondida, notaFinal, valorQuestao, tempTime;
	private bool exibindoCorreta, testeFinalizado;

	private SoundControler soundControler;


	// Use this for initialization
	void Start () {

		soundControler = FindObjectOfType (typeof(SoundControler)) as SoundControler;

		idTema = PlayerPrefs.GetInt ("idTema");
		notaMin1Estrela = PlayerPrefs.GetInt("notaMin1Estrela");
		notaMin2Estrelas = PlayerPrefs.GetInt("notaMin2Estrelas");

		barraTempo.SetActive (false);

		if (perguntasComImg == true) {
			montarListaPerguntasImg ();

		} else {
			montarListaPerguntas ();
		}
		progressaoBarra ();
		controleBarraTempo ();

		paineis [0].SetActive (true);
		paineis [1].SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {

		if (jogarComTempo == true && exibindoCorreta == false && testeFinalizado == false) {
			tempTime += Time.deltaTime;
			controleBarraTempo ();

			if (tempTime >= tempoResponder) {
				proximaPergunta ();
			}
		}
	}

	//ESTA FUNÇÃO É A RESPONSÁVEL POR MONTAR A LISTA DE PERGUNTAS A SEREM RESPONDIDAS

	public void montarListaPerguntas(){
		
		if (qtdPerguntas > perguntas.Length) {
			qtdPerguntas = perguntas.Length; }
		valorQuestao = 10 /(float)perguntas.Length;

		if (perguntasAleatorias == true) {                                            
			// EM CASO DE MODO DE JOGO COM PERGUNTAS ALEATÓRIAS
			
			bool addPergunta = true;

			while (listaPerguntas.Count < qtdPerguntas) {

			addPergunta = true;
			int	 rand = Random.Range (0, perguntas.Length);

			foreach (int idp in listaPerguntas) {
				if (idp == rand) {
				addPergunta = false;}
				}
				if (addPergunta == true) {
				listaPerguntas.Add (rand);}
			    }

			// EM CASO DE MODO DE JOGO ONDE AS PERGUNTAS NÃO SÃO ALEATÓRIAS
		} else {
			
			for (int i = 0; i < qtdPerguntas; i++) {
					listaPerguntas.Add (i);}
		}
			perguntaTxt.text = perguntas [listaPerguntas [idResponder]];

		if (utilizarAternativas == true && utilizarAternativasImg == false) {
			altAtxt.text = alternativasA [listaPerguntas [idResponder]];
			altBtxt.text = alternativasB [listaPerguntas [idResponder]];
			altCtxt.text = alternativasC [listaPerguntas [idResponder]];
			altDtxt.text = alternativasD [listaPerguntas [idResponder]];

		} else 
			if (utilizarAternativas == true && utilizarAternativasImg == true) {
				altAimg.sprite = alternativasAimg[listaPerguntas [idResponder]];
				altBimg.sprite = alternativasBimg [listaPerguntas [idResponder]];
				altCimg.sprite = alternativasCimg [listaPerguntas [idResponder]];
				altDimg.sprite = alternativasDimg [listaPerguntas [idResponder]];
		}
	}

	//ESTA FUNÇÃO É A RESPONSÁVEL POR MONTAR A LISTA DE PERGUNTAS COM IMAGEM A SEREM RESPONDIDAS

	public void montarListaPerguntasImg(){
		if (qtdPerguntas > perguntasImg.Length) {
			qtdPerguntas = perguntasImg.Length; }
		    valorQuestao = 10 /(float)perguntasImg.Length;
	    if (perguntasAleatorias == true) {                                          
			// EM CASO DE MODO DE JOGO COM PERGUNTAS ALEATÓRIAS
			bool addPergunta = true;
			while (listaPerguntas.Count < qtdPerguntas) {
			addPergunta = true;
			int rand = Random.Range (0, perguntasImg.Length);
			foreach (int idp in listaPerguntas) {
				if (idp == rand) {
					addPergunta = false;}
				  }
				if (addPergunta == true) {
					listaPerguntas.Add (rand);}
			      }
				} else {                                                                 
			// EM CASO DE MODO DE JOGO ONDE AS PERGUNTAS NÃO SÃO ALEATÓRIAS
				for (int i = 0; i < qtdPerguntas; i++) {
					listaPerguntas.Add (i);}
		        }
			perguntaImg.sprite = perguntasImg [listaPerguntas [idResponder]];


		if (utilizarAternativas == true && utilizarAternativasImg == false) {
			altAtxt.text = alternativasA [listaPerguntas [idResponder]];
			altBtxt.text = alternativasB [listaPerguntas [idResponder]];
			altCtxt.text = alternativasC [listaPerguntas [idResponder]];
			altDtxt.text = alternativasD [listaPerguntas [idResponder]];

		} else 
			if (utilizarAternativas == true && utilizarAternativasImg == true) {
				altAimg.sprite = alternativasAimg[listaPerguntas [idResponder]];
				altBimg.sprite = alternativasBimg [listaPerguntas [idResponder]];
				altCimg.sprite = alternativasCimg [listaPerguntas [idResponder]];
				altDimg.sprite = alternativasDimg [listaPerguntas [idResponder]];
	   }
	}
	// ESTA FUNÇÃO É RESPONSÁVEL POR PROCESSAR A RESPOSTA DADA PELO JOGADOR 
	public void responder(string alternativa){
		// VERIFICA SE NO MODO DE JOGO ESTÁ SETADO PARA EXIBIR AS ALTERNATIVAS CORRETAS, CASO ESTEJA, ELE RETORNA EM CASO DE MAIS DE UM CLIQUE

		if (exibindoCorreta == true) { return;
		}

		qtdRespondida += 1;
		progressaoBarra ();

		//FAZ A VERIFICAÇÃO DE SE A RESPOSTA ESTÁ CORRETA E INCREMENTA UM NA QUANTDADE DE ACERTOS 

		if (correta [listaPerguntas [idResponder]] == alternativa) {
			qtdAcertos += 1;
			soundControler.playAcerto ();
			} else {
			soundControler.playErro ();}
		switch (correta[listaPerguntas[idResponder]]) {
			case "A":
			idBtnCorreto = 0;
			break;
			case "B":
			idBtnCorreto = 1;
			break;
		    case "C":
			idBtnCorreto = 2;
			break;
		    case "D":
			idBtnCorreto = 3;
			break;}

		 // EM CASO DO MODO DE JOGO EXIBINDO A RESPOSTA CORRETA, ALTERA A COR DOS BOTÕES E FAZ A CHAMADA DA FUNÇÃO DE ANIMAÇÃO
		if (mortrarCorreta == true) {

			foreach (Button b in botoes) {
				b.image.color = corErro;
			}
			exibindoCorreta = true;
			botoes [idBtnCorreto].image.color = corAcerto;
			StartCoroutine ("mostrarAlternativaCorreta");
		} else {// CASO O MODO DE JOGO NÃO ESTEJA PARA EXIBIR A CORRETA, CHAMA A PRÓXIMA PERGUNTA

			exibindoCorreta = true;
			StartCoroutine ("aguardarProxima");
		}
	}
	// FUNÇÃO RESPONSÁVEL POR PROCESSAR AS PERGUNTAS, FAZ A CHAMADA DE UMA NOVA OU ENCERRA O TESTE
	public void proximaPergunta (){
			idResponder += 1;
		tempTime = 0;

		//CASO AINDA HAJA PERGUNTAS A SEREM RESPONDIDAS, PROCESSA A NOVA PERGUNTA
		if (idResponder < listaPerguntas.Count) {
			
			if (perguntasComImg == true) {
				perguntaImg.sprite = perguntasImg [listaPerguntas [idResponder]];

			} else {
				perguntaTxt.text = perguntas [listaPerguntas [idResponder]];
			}
			if (utilizarAternativas == true && utilizarAternativasImg == false) {
				altAtxt.text = alternativasA [listaPerguntas [idResponder]];
				altBtxt.text = alternativasB [listaPerguntas [idResponder]];
				altCtxt.text = alternativasC [listaPerguntas [idResponder]];
				altDtxt.text = alternativasD [listaPerguntas [idResponder]];
			} else 
				if (utilizarAternativas == true && utilizarAternativasImg == true) {
					altAimg.sprite = alternativasAimg[listaPerguntas [idResponder]];
					altBimg.sprite = alternativasBimg [listaPerguntas [idResponder]];
					altCimg.sprite = alternativasCimg [listaPerguntas [idResponder]];
					altDimg.sprite = alternativasDimg [listaPerguntas [idResponder]];
				}


		} else {
			// CASO O TESTE TENHA SIDO FINALIZADO, CHAMA A FUNÇÃO QUE CALCULA A NOTA FNAL
			calcularNotaFinal ();
		}
	}
	// FUNÇÃO QUE CONTROLA A BARRA DE PROGRESSO DO JOGO


	void progressaoBarra(){
		infoRespostasTxt.text = "Respondeu " + qtdRespondida +" de " + listaPerguntas.Count +" perguntas";
		pecProgresso = qtdRespondida / listaPerguntas.Count;
		barraProgresso.transform.localScale = new Vector3 (pecProgresso, 1, 1);
	}


	// FUNÇÃO QUE CONTROLA A BARRA DE TEMPO NO CASO DE MODO DE JOGO COM TEMPO

	void controleBarraTempo(){
		if (jogarComTempo == true) {
			barraTempo.SetActive (true);
		} 
		pecTempo = ((tempTime - tempoResponder) / tempoResponder) * -1;
		if (pecTempo < 0) {
			pecTempo = 0;}
		barraTempo.transform.localScale = new Vector3 (pecTempo, 1, 1);
	}


	// FUNÇÃO RESPONSÁVEL POR CALCULAR E GRAVAR A NOTA FINAL DO TESTE

	void calcularNotaFinal(){
		testeFinalizado = true;
		notaFinal = Mathf.RoundToInt(valorQuestao * qtdAcertos);

		if(notaFinal > PlayerPrefs.GetInt("notaFinal_"+idTema.ToString()))
		{PlayerPrefs.SetInt ("notaFinal_" + idTema.ToString(), (int)notaFinal);}
			
		if (notaFinal == 10) {nEstrelas = 3;
			soundControler.playVinheta ();} 
		else if (notaFinal >= notaMin2Estrelas) {nEstrelas = 2;	}
		else if (notaFinal >= notaMin1Estrela) {nEstrelas = 1;}

		notaFinalTxt.text = notaFinal.ToString ();
		notaFinalTxt.color = corMensagem [nEstrelas];

		msg1Txt.text = mensagem1 [nEstrelas];
		msg1Txt.color = corMensagem [nEstrelas];
		msg2Txt.text = mensagem2 [nEstrelas];

		foreach (GameObject e in estrela) {	e.SetActive (false);}
		for (int i = 0; i < nEstrelas; i++) {estrela [i].SetActive (true);}

		paineis [0].SetActive (false);
		paineis [1].SetActive (true);
	}

	// CORROUTINE QUE FAZ A ANIMAÇÃO DE PISCAR DO BOTÃO DA ALTERNATIVA CORRETA
	IEnumerator aguardarProxima(){
		yield return new WaitForSeconds (0.5f);
		exibindoCorreta = false;
		proximaPergunta ();

	}
		

	IEnumerator mostrarAlternativaCorreta(){

		for (int i = 0; i < qtdPiscar; i++) {
			botoes [idBtnCorreto].image.color = corAcerto;
			yield return new WaitForSeconds (0.2f);
			botoes [idBtnCorreto].image.color = Color.white;
			yield return new WaitForSeconds (0.2f);
		}

		foreach (Button b in botoes) 
		{   b.image.color = Color.white;}

		    exibindoCorreta = false;
		    proximaPergunta ();}

}
