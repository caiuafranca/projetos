using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameControllerScript : MonoBehaviour {

	public Slider healthSlider;

	private float m_health;

	// Use this for initialization
	void Start () {
		m_health = 100f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void TakeDamage() {
		if (m_health > 0f) m_health -= 0.1f;
		healthSlider.value = m_health;
	}

	public void GainLife() {
			if (m_health < 90f) {
			m_health += 10;
			} else {
				m_health = 100f;
			}
			healthSlider.value = m_health;
	}

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
	
	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}
	
	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}
