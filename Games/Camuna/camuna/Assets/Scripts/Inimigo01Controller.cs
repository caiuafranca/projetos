using UnityEngine;
using System.Collections;

public class Inimigo01Controller : MonoBehaviour {


	private Animator animator;
	public Rigidbody2D body;
	public float velocidade = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Correr ();
	}

	void Correr(){
		transform.Translate ( Random.Range(2,10) * Random.Range(1,2) * Time.deltaTime, 0, 0);
	}
}
