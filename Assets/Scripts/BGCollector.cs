using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{

	private GameObject[] backgrounds;
	private GameObject[] grounds;

	private float lastBGX;
	private float lastGroundX;

	// Use this for initialization
	void Start()
	{
		backgrounds = GameObject.FindGameObjectsWithTag ("Background");
		grounds = GameObject.FindGameObjectsWithTag ("Ground");

		lastBGX = backgrounds[0].transform.position.x;
		lastGroundX = grounds[0].transform.position.x;

		foreach (GameObject bg in backgrounds)
		{
			if( bg.transform.position.x > lastBGX )
			{
				lastBGX = bg.transform.position.x;
			}
		}

		foreach (GameObject g in grounds)
		{
			if( g.transform.position.x > lastGroundX )
			{
				lastGroundX = g.transform.position.x;
			}
		}
			


	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collider)
	{
		if( collider.tag == "Background" )
		{
			Vector3 temp = collider.transform.position;
			float width = ((BoxCollider2D)collider).size.x;

			temp.x = lastBGX + width;

			collider.transform.position = temp;

			lastBGX = temp.x;
		}

		if( collider.tag == "Ground" )
		{
			Vector3 temp = collider.transform.position;
			float width = ((BoxCollider2D)collider).size.x;

			temp.x = lastGroundX + width;

			collider.transform.position = temp;

			lastGroundX = temp.x;
		}
	}
}















































