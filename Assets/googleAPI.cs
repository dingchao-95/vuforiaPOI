using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class googleAPI : MonoBehaviour {
	public static googleAPI Instance { set; get; }
	public RawImage img;

	string url;

	public float lat;
	public float lon;

	LocationInfo Li;

	public int zoom = 14;
	public int mapWidth = 640;
	public int mapHeight = 640;

	public enum mapType {roadmap,satellite,hybrid,terrain};
	public mapType mapSelected;
	public int scale;

	IEnumerator StartTrackingLocation()
	{
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;

		// Start service before querying location
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			print("Timed out");
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			print("Unable to determine device location");
			yield break;
		}

		lat = Input.location.lastData.latitude;
		lon = Input.location.lastData.longitude;

		yield break;
	}

	IEnumerator Map()
	{
		url = "https://maps.googleapis.com/maps/api/staticmap?center=" + Input.location.lastData.latitude + "," + Input.location.lastData.longitude +
			"&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale 
			+"&maptype=" + mapSelected +
			"&markers=color:blue%7Clabel:S%7C1.39069,103.89859&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyBbbO1zkYVbvYlc3U4lBA0RQ-FFQ0UK7Sk";
		WWW www = new WWW (url);
		yield return www;
		img.texture = www.texture;
		img.SetNativeSize ();
	}

	// Use this for initialization
	void Start () 
	{
		GameObject arcamera = GameObject.Find ("ARCamera");
		GPS gpsCoordinates = arcamera.GetComponent<GPS> ();

		//Instance = this;
		//DontDestroyOnLoad (gameObject);
		img = gameObject.GetComponent<RawImage> ();
		StartCoroutine (Map());
		StartCoroutine (StartTrackingLocation ());

	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject arcamera = GameObject.Find ("ARCamera");
		GPS gpsCoordinates = arcamera.GetComponent<GPS> ();
		
		lat = gpsCoordinates.latitude;
		lon = gpsCoordinates.longitude;

		url = "https://maps.googleapis.com/maps/api/staticmap?center=" + Input.location.lastData.latitude + "," + Input.location.lastData.longitude +
			"&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale 
			+"&maptype=" + mapSelected +
			"&markers=color:blue%7Clabel:S%7C1.39069,103.89859&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyBbbO1zkYVbvYlc3U4lBA0RQ-FFQ0UK7Sk";

		Map ();
	}
}
