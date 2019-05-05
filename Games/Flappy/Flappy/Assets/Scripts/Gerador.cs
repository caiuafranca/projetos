using UnityEngine;
using System.Collections;

public class Gerador : MonoBehaviour {

	public GameObject rocks;
	private int score;
	public float velocidade =1f;
	public float frequencia =1f;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating ("CreateObstacle", velocidade, frequencia);
	}
	// Update is called once per frame
	void OnGUI () 
	{
		GUI.color = Color.white;
		GUILayout.Label(" Score: " + score.ToString());
	}
		

	void CreateObstacle()
	{
		Instantiate(rocks);
		score++;
	}
}