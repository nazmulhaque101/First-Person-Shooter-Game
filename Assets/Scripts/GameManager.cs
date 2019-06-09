using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
	public static GameManager gm;
 
	public int score = 0;

	public bool canBeatLevel = false;
	public int beatLevelScore = 0;

	public float startTime = 25.0f;

	public Text mainScoreDisplay;
	public Text mainTimerDisplay;

	public GameObject gameOverScoreOutline;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;

	public GameObject playAgainButtons;

	public GameObject exitButton;
	public string playAgainLevelToLoad;

	public GameObject nextLevelButtons;
	public string nextLevelToLoad;

	private float currentTime;
 
	void Start ()
	{
 
		currentTime = startTime;
 
		if (gm == null)
		{

			gm = this.gameObject.GetComponent<GameManager> ();
		}
 
		mainScoreDisplay.text = "0";
 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (false);
 
		if (playAgainButtons)
		{
			playAgainButtons.SetActive (false);

		}

		if (exitButton)
		{
			exitButton.SetActive (false);
		}
 
		if (nextLevelButtons)
			nextLevelButtons.SetActive (false);
	}
 
	void Update ()
	{
		if (!gameIsOver)
		{
			if (canBeatLevel && (score >= beatLevelScore))
			{ 
				BeatLevel ();
			}
			else if (currentTime < 0)
			{ 
				EndGame ();
			}
			else
			{  
				currentTime -= Time.deltaTime;
				mainTimerDisplay.text = currentTime.ToString ("0.00");
			}
		}
	}

	void EndGame ()
	{
 
		gameIsOver = true;
 
		mainTimerDisplay.text = "GAME OVER\n\n\n-- Credit --\nNazmul Haque\nRoll: 1510476128\nUniversity of Rajshahi";
 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);
 
		if (playAgainButtons)
		{
			playAgainButtons.SetActive (true);
		}

		if (exitButton)
		{
			exitButton.SetActive (true);
		}
 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f;  
	}

	void BeatLevel ()
	{
	 
		gameIsOver = true;

		 
		mainTimerDisplay.text = "LEVEL COMPLETE";
 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);
 
		if (nextLevelButtons)
			nextLevelButtons.SetActive (true);
 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f;  
	}
 
	public void targetHit (int scoreAmount, float timeAmount)
	{ 
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString ();
 
		currentTime += timeAmount;
 
		if (currentTime < 0)
			currentTime = 0.0f;
 
		mainTimerDisplay.text = currentTime.ToString ("0.00");
	}
 
	public void RestartGame ()
	{ 
		Application.LoadLevel (playAgainLevelToLoad);
	}

	public void Exit ()
	{ 
		Application.Quit ();
	}
 
	public void NextLevel ()
	{ 
		Application.LoadLevel (nextLevelToLoad);
	}

}