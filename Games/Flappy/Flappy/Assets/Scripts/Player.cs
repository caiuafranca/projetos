using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector2 jumpForce = new Vector2 (0, 200);
	public int life = 3;

	void Start () {
	
	}

	void Update () {
		
		// Jump

		if (Input.GetKeyUp("space"))
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce(jumpForce);
		}
			
		if(Input.touchCount >= 1)
		{
			if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				GetComponent<Rigidbody2D>().AddForce(jumpForce);
			}
		}

		// Die by being off screen
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
		{
			Die ();
		}
	}

		// Die by collision
		void OnCollisionEnter2D(Collision2D other)
		{
			Die();
		}

		void Die()
		{
			Application.LoadLevel(Application.loadedLevel);
		}

}
