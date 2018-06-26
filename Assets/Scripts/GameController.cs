using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public static GameController instance;

	private const string HIGH_SCORE = "High score";
	private const string SELECTED_BIRD = "Selected Bird";
	private const string RED_BIRD = "Red Bird";
	private const string BLUE_BIRD = "Blue Bird";

	// Use this for initialization
	void Awake()
	{
		MakeSingleton();
		IsTheGameStartedForTheFirsTime();
	}

	void MakeSingleton()
	{
		if( instance != null )
		{
			Destroy (gameObject);
		} else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void IsTheGameStartedForTheFirsTime()
	{
		if( !PlayerPrefs.HasKey ("IsTheGameStartedForTheFirsTime") )
		{
			PlayerPrefs.SetInt (HIGH_SCORE, 0);
			PlayerPrefs.SetInt (SELECTED_BIRD, 0);
			PlayerPrefs.SetInt (RED_BIRD, 0);
			PlayerPrefs.SetInt (BLUE_BIRD, 0);
			PlayerPrefs.SetInt ("IsTheGameStartedForTheFirsTime", 0);
		}
	}

	public void SetHighscore(int score)
	{
		PlayerPrefs.SetInt(HIGH_SCORE, score);
	}

	public int GetHighscore()
	{
		return PlayerPrefs.GetInt(HIGH_SCORE);
	}

	public void SetSelectedBird(int selectedBird)
	{
		PlayerPrefs.SetInt(SELECTED_BIRD, selectedBird);
	}

	public int GetSelectedBird()
	{
		return PlayerPrefs.GetInt(SELECTED_BIRD);
	}

	public void UnlockRedBird()
	{
		PlayerPrefs.SetInt(RED_BIRD, 1);
	}

	public int IsRedBirdUnlocked()
	{
		return PlayerPrefs.GetInt(RED_BIRD);
	}

	public void UnlockBlueBird()
	{
		PlayerPrefs.SetInt(BLUE_BIRD, 1);
	}

	public int IsBlueBirdUnlocked()
	{
		return PlayerPrefs.GetInt(BLUE_BIRD);
	}


}
