using UnityEngine;
using System.Collections;

public class CarVermelho : MonoBehaviour {

	public bool EUminstanciador = false;
	public GameObject ObjetoASerInserido;
	private float Contador = 0;	
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Wall")) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (EUminstanciador) {
			Contador += Time.deltaTime;

			if (Contador >= Random.value * 100) {
				Contador = 0;
				Instantiate (ObjetoASerInserido, 
					new Vector3 (Random.Range(-0.9f, 2.4f), 14, 0), ObjetoASerInserido.transform.rotation);
				
			}
		} else{
			transform.Translate (0, -10 * Time.deltaTime, 0);
		}
	}
}
