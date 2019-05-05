using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform sprite;
	private Animator animator;
	public Rigidbody2D body;
	public float velocidade;
	public float forcaPulo = 10f;
	public bool grounded = true;
	public Transform groundCheck;
	public LayerMask Piso;
	public float groundRadius = 0.2f;

	// Use this for initialization
	void Start () {
	
		velocidade = 5.0f;
		body = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Mover ();
	}

	void Mover(){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, Piso);
		animator.SetBool ("Ground", grounded);

		if (Input.GetButtonDown ("Jump") && grounded) {
			body.AddForce (new Vector2 (0, forcaPulo));
		}


		if (Input.GetAxis("Horizontal")>0) {
			transform.Translate (velocidade * Input.GetAxis ("Horizontal") * Time.deltaTime, 0, 0);	
			transform.eulerAngles = new Vector2 (0,0);
			animator.SetFloat ("Speed", Mathf.Abs(Input.GetAxis ("Horizontal")));
		}

		if (Input.GetAxis ("Horizontal") < 0) {
			transform.Translate (velocidade * -Input.GetAxis ("Horizontal") * Time.deltaTime, 0, 0);	
			transform.eulerAngles = new Vector2 (0, 180);
			animator.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		}

	
	}


}
