using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour {

	private PlatformerCharacter2D m_Character;
	private GameObject m_Controller;
	private bool m_Jump;
	private bool m_Ad;
	private float h;
	
	private void Awake () {
		m_Character = GetComponent<PlatformerCharacter2D>();
		m_Controller = GameObject.FindGameObjectWithTag ("GameController");
		m_Jump = false;
	}
	
	// Update is called once per frame
	private void Update () {
		if (!m_Jump) {
			m_Jump = Input.GetKeyDown(KeyCode.Space);
		}

		if (!m_Ad) {
			m_Ad = Input.GetKeyDown(KeyCode.J);
		}
	}

	private void FixedUpdate () {
	#if UNITY_EDITOR
		h = Input.GetAxisRaw ("Horizontal");
	#endif
		m_Character.Move (h, m_Jump);
		m_Jump = false;

		if (m_Ad) {
			m_Controller.GetComponent<GameControllerScript>().ShowRewardedAd();
			m_Ad = false;
		}
	}

	public void StartMoving (float hor) {
		h = hor;
	}

	public void Jump() {
		if (!m_Jump) {
			m_Jump = true;
		}
	}
}
