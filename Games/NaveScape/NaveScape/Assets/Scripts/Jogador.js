#pragma strict
var jogadorVel : float;
var vidaJogador = 3;
static var pontosJogador = 0;
var tiro:Rigidbody2D;

function Start () {

}

function Update () {
	//calculo de velocidades
	var velocidade = jogadorVel * Input.GetAxis("Vertical");

	// mover a nave
	transform.Translate(Vector3.left * velocidade);

	if(Input.GetKeyDown("space")){
		var tempTiro:Rigidbody2D;	
		tempTiro = Instantiate(tiro,transform.position,transform.rotation);
	}
}

function OnGUI(){
	//menu de Pontos do Jogo
	GUI.Label(Rect(10,10,200,50),"Pontos: "+ pontosJogador);
	//Menu de Vidas
	GUI.Label(Rect(10,30,200,50),"Vidas: " + vidaJogador);
}