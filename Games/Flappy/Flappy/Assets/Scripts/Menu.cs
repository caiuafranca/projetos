﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount >= 1/*Input.GetKeyUp("space")*/){
			Application.LoadLevel (1);
		}
	}
}
