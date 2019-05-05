using UnityEngine;
using System.Collections;

public class MoveScene : MonoBehaviour {

	private Material materialCurrent;
	public float speed;
	private float offset;
	// Use this for initialization
	void Start () {
		materialCurrent = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		offset += 0.001f;
		materialCurrent.SetTextureOffset ("_MainTex", new Vector2(offset*speed, 0));
	
	}
}
