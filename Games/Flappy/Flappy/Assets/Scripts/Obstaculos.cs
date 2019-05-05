using UnityEngine;
using System.Collections;

public class Obstaculos : MonoBehaviour {

	public Vector2 velocity = new Vector2(-4, 0);
	public float range = 1.5f;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = velocity;
		transform.position = new Vector3(0f, Random.Range(0f,1f), 0f);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = velocity;
	}
}
