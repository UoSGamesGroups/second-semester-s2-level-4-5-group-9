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

    [Header("Stores players' Total Wins as strings")]
    public Text playerOneWinTotalTxt;
    public Text playerTwoWinTotalTxt;

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

    // Bool holders for disabling scoring at the end of the match
    public Ball_Controller scoringEnabled;
    public BallFXScript scoringSfxEnabled;

    // Varibles for Total Wins Storer
    private TotalWinsStorer TotalWins;
    private GameObject TotalWinObj;

    void Awake()
    {
        UpdateScoreBoard();
        GameObject scoreEnabledObj = GameObject.FindGameObjectWithTag("Ball");
        scoringEnabled = scoreEnabledObj.GetComponent<Ball_Controller>();
        scoringSfxEnabled = scoreEnabledObj.GetComponent<BallFXScript>();

        // Gets/sets compononents up for Total Wins Storer
        TotalWinObj = GameObject.Find("TotalWinsStorer");
        TotalWins = TotalWinObj.GetComponent<TotalWinsStorer>();
        // Makes sure the Player Win total is up to date 
        UpdateWinTotal();
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
                scoringEnabled._scoringEnabled = false;             // Turns off the ability to score
                scoringSfxEnabled._scoringSfxEnabled = false;       // Stops the score Sfx
                TotalWins.playerOneWinTotal++;                      // Updates the TotalWinsStorer
                UpdateWinTotal();                                   // Updates WinTotal Text
                playerOneWinsText.SetActive(true);                  // Sets Player One Win text to true
                endOfMatchCanvas.SetActive(true);                   // Activates the end of match canvas
                print("Player One Wins!");
                EndOfMatchAnim.Play("EndOfMatchPanelAnim");         // Starts the End of Match fade to black
                break;
            case 2:
                scoringEnabled._scoringEnabled = false;             // Turns off the ability to score
                scoringSfxEnabled._scoringSfxEnabled = false;       // Stops the score Sfx
                TotalWins.playerTwoWinTotal++;                      // Updates the TotalWinsStorer
                UpdateWinTotal();                                   // Updates WinTotal Text
                playerTwoWinsText.SetActive(true);                  // Sets Player Two Win text to true
                endOfMatchCanvas.SetActive(true);                   // Activates the end of match canvas
                print("Player Two Wins");
                EndOfMatchAnim.Play("EndOfMatchPanelAnim");         // Starts the End of Match fade to black
                break;
        }
    }

    public void UpdateWinTotal()
    {
        playerOneWinTotalTxt.text = "Total\nWins\n" + TotalWins.playerOneWinTotal.ToString();
        playerTwoWinTotalTxt.text = "Total\nWins\n" + TotalWins.playerTwoWinTotal.ToString();
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
