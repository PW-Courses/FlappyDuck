using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public static MenuController instance;

	[SerializeField]
	private GameObject[] birds;

	private bool isBlueBirdUnlocked, isRedBirdUnlocked;


	// Use this for initialization
	void Awake()
	{
		MakeInstance ();
	}

	void Start()
	{
		birds[GameController.instance.GetSelectedBird ()].SetActive (true);
		CheckIfBirdsAreUnlocked ();
	}

	void MakeInstance()
	{
		if( instance == null )
		{
			instance = this;
		}
	}

	void CheckIfBirdsAreUnlocked()
	{
		if( GameController.instance.IsRedBirdUnlocked () == 1 )
		{
			isRedBirdUnlocked = true;
		}

		if( GameController.instance.IsBlueBirdUnlocked () == 1 )
		{
			isBlueBirdUnlocked = true;
		}
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("GamePlay");
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void ChangeBird()
	{
		if( GameController.instance.GetSelectedBird () == 0 )
		{
			if( isRedBirdUnlocked )
			{
				birds[0].SetActive (false);
				GameController.instance.SetSelectedBird (1);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			}
		} else if( GameController.instance.GetSelectedBird () == 1 )
		{
			if( isRedBirdUnlocked )
			{
				birds[1].SetActive (false);
				GameController.instance.SetSelectedBird (2);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			} else
			{
				birds[1].SetActive (false);
				GameController.instance.SetSelectedBird (0);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			}
		} else if( GameController.instance.GetSelectedBird () == 2 )
		{
			birds[2].SetActive (false);
			GameController.instance.SetSelectedBird (0);
			birds[GameController.instance.GetSelectedBird ()].SetActive (true);
		}
	}
}
