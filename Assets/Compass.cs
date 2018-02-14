using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

	public Vector3 NorthDirection;
	public Transform Player;
	public Quaternion MissionDirection;

	public RectTransform NorthLayer;
	public RectTransform MissionLayer;

	public Transform missionplace;



	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
		Input.location.Start ();	
	}
	
	// Update is called once per frame
	void Update () {
		ChangeNorthDirection ();
		//ChangeMissionDirection ();
	}

	public void ChangeNorthDirection()
	{
		//NorthDirection.z = Player.eulerAngles.y;
		//NorthLayer.localEulerAngles = NorthDirection;
		NorthDirection.z = Input.compass.trueHeading;
		NorthLayer.localEulerAngles = NorthDirection;
	}

	public void ChangeMissionDirection()
	{
		Vector3 dir = transform.position - missionplace.position;

		MissionDirection = Quaternion.LookRotation (dir);

		MissionDirection.z = MissionDirection.y;
		MissionDirection.x = 0;
		MissionDirection.y = 0;

		MissionLayer.localRotation = MissionDirection * Quaternion.Euler (NorthDirection);
	}
}
