using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GPS : MonoBehaviour {


	public static GPS Instance { set; get; }
	public float latitude;
	public float longitude;

	public GameObject ufo;
	public Text coordinates;
	public Text referenceCoordinates;
	public Text distanceFrom3dModel;

	private double referenceLatitude;
	private double referenceLongitude;
	private double referenceDistance;

	private double distFrom3dModel_lat;
	private double distFrom3dModel_lon;

	private void Awake()
	{
//		DontDestroyOnLoad (this);
//
//		if (FindObjectsOfType (GetType ()).Length > 1) 
//		{
//			Destroy (gameObject);
//		}

		//ufo.SetActive (false);
			
	}

	private void Start() {
		Instance = this;
		//DontDestroyOnLoad(this.gameObject);
		ufo.SetActive(false);
		referenceLatitude = 1.39065;
		referenceLongitude = 103.89858;
		referenceDistance = 0.0020;
		distFrom3dModel_lat = 0;
		distFrom3dModel_lon = 0;
		distanceFrom3dModel.text = "Distance (Lan,Lon): 0 - 0 ";
		referenceCoordinates.text = "Reference (Lat,Lon): " + referenceLatitude.ToString() + " - " + referenceLongitude.ToString();
		StartCoroutine(StartLocationService());
	}

	private void Update()
	{
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		coordinates.text = "Current (Lat,Lon): " + GPS.Instance.latitude.ToString() + " - " + GPS.Instance.longitude.ToString();
		if (CloseEnoughForMe(Instance.latitude, referenceLatitude, referenceDistance) && CloseEnoughForMe(Instance.longitude,referenceLongitude, referenceDistance))
		{
			ufo.SetActive(true);
		}
		else
		{
			ufo.SetActive(false);
		}
	}

	private bool CloseEnoughForMe(double value1, double value2, double acceptableDifference)
	{
		distanceFrom3dModel.text = "Distance (Lan,Lon): " + Math.Abs(value1 - value2).ToString();
		return Math.Abs(value1 - value2) <= acceptableDifference;
	}

	private double distanceBetweenTwoPoints(double value1, double value2)
	{
		return Math.Abs(value1 - value2);
	}

	private IEnumerator StartLocationService(){
		if (!Input.location.isEnabledByUser) {
			Debug.Log("User has not enabled GPS");
			yield break;
		}

		Input.location.Start();

		int maxWait = 20;
		while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		if (maxWait <= 0) {
			Debug.Log("Timed out");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log("Unable to determin device location");
			yield break;
		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		yield break;
	}
}