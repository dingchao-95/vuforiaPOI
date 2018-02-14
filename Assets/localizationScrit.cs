using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class localizationScrit : MonoBehaviour {
	public Text buttonText;
	public Text LanguageButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (LanguageButton.text) {
		case "English":
			ChangeEnglish ();
			break;
		case "Chinese":
			ChangeChinese ();
			break;
		case "French":
			ChangeFrench ();
			break;
		default:
			break;
		}
	}

	public void ChangeEnglish()
	{
		buttonText.text = "Login with FaceBook";
	}

	public void ChangeChinese()
	{
		buttonText.text = "登录 Facebook";
	}

	public void ChangeFrench()
	{
		buttonText.text = "Se connecter avec Facebook";
	}
}
