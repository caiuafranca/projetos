using UnityEngine;
using System.Collections;

public class BoxColider : MonoBehaviour {

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
	
	}
}
