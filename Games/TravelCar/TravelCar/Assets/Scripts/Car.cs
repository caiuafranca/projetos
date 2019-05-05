using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	
	// Variaveis
	public float velocidade = 10f;


	void Start () {
	
	}

	void Update () {
		transform.Translate (velocidade * Input.GetAxis("Horizontal") * Time.deltaTime, 
							 velocidade * Input.GetAxis("Vertical") * Time.deltaTime, 0);
	}
}
