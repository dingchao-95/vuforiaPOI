using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchItem : MonoBehaviour {
	public GameObject imageText;
	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (this.gameObject);
	}
	


	void Update()
	{
		RaycastHit hit;
		Ray ray;

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);


		if(Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
		{
			Debug.Log(" you clicked on " + hit.collider.gameObject.name);

			if(hit.collider.gameObject.name == "Sphere" || hit.collider.gameObject.name == "testsphere")
			{
				// Write things you want to do when you click.
				if (imageText.active == false) 
				{
					imageText.SetActive (true);
				//} else 
				//{
				//	imageText.SetActive (false);
				//}
				}
			}
		}
	}


}