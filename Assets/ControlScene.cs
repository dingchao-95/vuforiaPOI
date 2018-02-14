using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class ControlScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		Camera mainCamera = Camera.main;
//		if (mainCamera) 
//		{
//			if (mainCamera.GetComponent<VuforiaBehaviour>() == null)
//			{
//				mainCamera.GetComponent<VuforiaBehaviour> ().enabled = true;
//			}
//			if (mainCamera.GetComponent<VideoBackgroundBehaviour>() == null)
//			{
//				mainCamera.GetComponent<VideoBackgroundBehaviour>().enabled = true;
//			}
//			if (mainCamera.GetComponent<DefaultInitializationErrorHandler>() == null)
//			{
//				mainCamera.GetComponent<DefaultInitializationErrorHandler>().enabled = true;
//			}
//		}

		VuforiaRuntime.Instance.Deinit();

		VuforiaBehaviour.Instance.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextScene()
	{
		StartCoroutine (StartVuforiaAndPlay ());
		//VuforiaRuntime.Instance.InitVuforia();
		//SceneManager.LoadScene("testScene");
		//StartCoroutine(StartVuforiaAndPlay());
	}



	IEnumerator StartVuforiaAndPlay()
	{
		VuforiaRuntime.Instance.InitVuforia();
		while (!VuforiaRuntime.Instance.HasInitialized)
		{
			yield return null;
		}
		SceneManager.LoadSceneAsync("testscene");

		//Application.LoadLevelAsync ("testScene");


	}
}
