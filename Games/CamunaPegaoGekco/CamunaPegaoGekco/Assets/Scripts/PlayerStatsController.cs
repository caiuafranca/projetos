using UnityEngine;
using System.Collections;

public class PlayerStatsController : MonoBehaviour {


	public static PlayerStatsController instance;

	public int xpMultiply = 1;
	public float xpFirstLevel = 100;
	public float difficultFactor = 1.5f;
	private float xpNextLevel;

	// Use this for initialization
	void Start () {
		instance = this;
		DontDestroyOnLoad (gameObject);
		Application.LoadLevel ("GamePlay");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void AddXp(float xpAdd){
		float newXp = (PlayerPrefs.GetFloat ("currentXp") + xpAdd) * PlayerStatsController.instance.xpMultiply;

		if (newXp > getCurrentLevel ()) {
			addLevel ();
			float diff = newXp - getXp();
			newXp = diff;
		}

		PlayerPrefs.SetFloat ("currentXp", newXp);
	}

	public static int getCurrentLevel(){
		return PlayerPrefs.GetInt ("currentLevel");
	}

	public static float getXp(){
		return PlayerPrefs.GetFloat ("currentXp");
	}

	public static void addLevel(){
		int newLevel = getCurrentLevel () + 1;
		PlayerPrefs.SetInt ("currentLevel",newLevel);
	}

	public static float getNextXp(){
		return PlayerStatsController.instance.xpFirstLevel * (getCurrentLevel() +1) * 
			PlayerStatsController.instance.difficultFactor;
	}

}
