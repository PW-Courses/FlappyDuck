using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{

	private GameObject[] pipeHolders;
	private float distance = 3f;
	private float lastPipesX;
	private float pipeMin = -2f;
	private float pipeMax = 2f;


	// Use this for initialization
	void Awake()
	{

		pipeHolders = GameObject.FindGameObjectsWithTag ("PipeHolder");

		lastPipesX = pipeHolders[0].transform.position.x;

		foreach (GameObject pipe in pipeHolders)
		{
			
			//Nadaje nowa pozycje Y rurom pomiedzy pipeMin i pipeMax
			Vector3 temp = pipe.transform.position;

			temp.y = Random.Range (pipeMin, pipeMax);

			pipe.transform.position = temp;


			//Ustalam wartość X ostatniej rury
			if (pipe.transform.position.x > lastPipesX)
			{
				lastPipesX = pipe.transform.position.x;
			}

		}
			
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		print ("LUL");

		if(collider.tag == "PipeHolder")
		{


			print ("Hello pipe");
			Vector3 temp = collider.transform.position;

			temp.x = lastPipesX + distance;
			temp.y = Random.Range(pipeMin, pipeMax);

			collider.transform.position = temp;

			lastPipesX = temp.x;
		}
	}
}
