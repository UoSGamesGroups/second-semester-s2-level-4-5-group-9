using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {

	[Header("Players' Scores")]
    public int Player1Score = 0;
    public int Player2Score = 0;

    [Header("Stores players scores as strings")]
    public Text Player1ScoreTxt;
    public Text Player2ScoreTxt;

    [Header("Stores time remaining as a string")]
    public Text MatchTimerTxt;

    [Header("Length of match in seconds")]
    public float timer = 180f;

    [Header("Animators for the PlayerScored Canvas Images")]
    public Animator PlayerOneScoreAnim;
    public Animator PlayerTwoScoreAnim;

    private bool gameFinished = false;      // To stop match timer from running
    private bool isSuddenDeath = false;

    [Header("End of match game objects")]
    public GameObject playerOneWinsText;
    public GameObject playerTwoWinsText;
    public GameObject playerDrawText;
    public GameObject suddenDeathImage;
    public GameObject timerText;

    public GameObject endOfMatchCanvas;
    public Animator EndOfMatchAnim;         // To fade screen at the end of the match

    private int PlayerWhoWon;

    void Awake()
    {
        UpdateScoreBoard();
    }
	
	void Update ()
    {
        if ((timer <= 0) && (!gameFinished))
        {
            if (Player1Score == Player2Score)
            {
                PlayerWhoWon = 0;
            }
            if (Player1Score > Player2Score)
            {
                PlayerWhoWon = 1;
            }
            if (Player1Score < Player2Score)
            {
                PlayerWhoWon = 2;
            }
            gameFinished = true;
            EndOfMatch();
        }

        // Updates timer, sorts into mins and secs, updates 'MatchTimerTxt'
        if (!gameFinished)
        {
            timer -= Time.deltaTime;
            int minutes = (int)timer / 60;
            int seconds = (int)timer % 60;
            MatchTimerTxt.text = minutes.ToString() + " : " + seconds.ToString("00");
        }
    }
	    // Updates score, called from 'Ball_Controller' on goal
    public void UpdateScoreBoard()
    {
        Player1ScoreTxt.text =  Player1Score.ToString();
        Player2ScoreTxt.text =  Player2Score.ToString();
    }

    public void PlayerOneScored()
    {
        PlayerOneScoreAnim.Play("PlayerOneScoredAnim");

        if (isSuddenDeath)
        {
            PlayerWhoWon = 1;
            EndOfMatch();
        }
    }

    public void PlayerTwoScored()
    {
        PlayerTwoScoreAnim.Play("PlayerTwoScoredAnim");

        if (isSuddenDeath)
        {
            PlayerWhoWon = 2;
            EndOfMatch();
        }
    }

    void EndOfMatch()
    {
        switch (PlayerWhoWon)
        {
            case 0:
                playerDrawText.SetActive(true);
                print("Draw");
                StartCoroutine(SuddenDeath());
                break;
            case 1:
                playerOneWinsText.SetActive(true);
                endOfMatchCanvas.SetActive(true);
                print("Player One Wins!");
                EndOfMatchAnim.Play("EndOfMatchPanelAnim");
                break;
            case 2:
                playerTwoWinsText.SetActive(true);
                endOfMatchCanvas.SetActive(true);
                print("Player Two Wins");
                EndOfMatchAnim.Play("EndOfMatchPanelAnim");
                break;
        }
    }

    IEnumerator SuddenDeath()
    {
        yield return new WaitForSeconds(1f);
        playerDrawText.SetActive(false);
        timerText.SetActive(false);
        suddenDeathImage.SetActive(true);
        Player1Score = 0;
        Player2Score = 0;
        UpdateScoreBoard();
        isSuddenDeath = true;
    }
}
