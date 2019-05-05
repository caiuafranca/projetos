#pragma strict
var tiroVel = 10;
function Start () {

}

function Update () {
	var velocidade = tiroVel * Time.deltaTime;

	// mover a nave
	transform.Translate(Vector3.left * velocidade);
	if(transform.position.x >= 10){
		Destroy(gameObject);
	}	

	
	
}