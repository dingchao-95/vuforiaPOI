﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class backToMain : MonoBehaviour {
	void Awake()
	{
		//VuforiaBehaviour.Instance.enabled = true;
	}
	// Use this for initialization
	void Start () {
		VuforiaBehaviour.Instance.enabled = true;
	}
	
	// Update is called once per frame
	 void Update () {
		//VuforiaBehaviour.Instance.enabled = false;
		//SceneManager.LoadSceneAsync("MainMenu");
     } 

	public void mainmenu()
	{
		//VuforiaRuntime.Instance.Deinit ();
		VuforiaBehaviour.Instance.enabled = false;
		SceneManager.LoadScene("MainMenu");
	}
}
