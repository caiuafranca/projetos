using UnityEngine;
using System.Collections;

public class PlatformerCharacter2D : MonoBehaviour {

	[SerializeField] private float m_MaxSpeed = 10f;
	[Range(0, 1000)][SerializeField] private float m_JumpForce = 400f;
	[SerializeField] private bool m_AirControl = false;
	[SerializeField] private LayerMask m_WhatIsGround;

	private Transform m_GroundCheck;
	const float k_GroundedRadius = .5f;
	private bool m_Grounded;
	private Animator m_Anim;
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;
	private AudioSource m_jumpAudio;

	private GameObject m_Controller;

	void Awake () {
		m_GroundCheck = transform.Find ("GroundCheck");
		m_Rigidbody2D = GetComponent<Rigidbody2D> ();
		m_jumpAudio = GetComponent < AudioSource> ();
		m_Anim = GetComponent<Animator> ();
		m_Controller = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	void FixedUpdate () {
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll (m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders [i].gameObject != gameObject) {
				m_Grounded = true;
				if (colliders[i].gameObject.name.Equals("Spikes")) {
					m_Controller.GetComponent<GameControllerScript>().TakeDamage();
				}
			}
		}

		m_Anim.SetBool ("Ground", m_Grounded);
	}

	public void Move(float move, bool jump) {
		if (m_Grounded || m_AirControl) {

			m_Anim.SetFloat("Speed", Mathf.Abs(move));

			m_Rigidbody2D.velocity = new Vector2 (move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

			if (move > 0 && !m_FacingRight) {
				Flip();
			} else if (move < 0 && m_FacingRight) {
				Flip();
			}
		}

		if (m_Grounded && jump && m_Anim.GetBool("Ground")) {
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			m_Anim.SetBool("Ground", false);
			m_jumpAudio.Play();
		}

	}

	private void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Life")) {
			m_Controller.GetComponent<GameControllerScript>().GainLife();
			Destroy(col.gameObject);
		}
	}

	private void Flip() {
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
