using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {
	[Header("Player's Scores")]
    public int Player1Score = 0;
    public int Player2Score = 0;
	
	// Stores players scores as strings
    public Text Player1ScoreTxt;
    public Text Player2ScoreTxt;
    // Timer varibles
    public Text MatchTimerTxt;
    [SerializeField]
    private float timer = 180f;

    // Animators for the PlayerScored Canvas Images
    public Animator PlayerOneScoreAnim;
    public Animator PlayerTwoScoreAnim;

    void Start()
    {
        UpdateScoreBoard();
    }
	
	void Update ()
    {
		if (timer <= 0)
        {
            if (Player1Score == Player2Score)
            {
                print("Draw");
            }
            if (Player1Score > Player2Score)
            {
                print("Player One Wins!");
            }
            if (Player1Score < Player2Score)
            {
                print("Player Two Wins");
            }
        }
        

        // Updates timer, sorts into mins and secs, updates 'MatchTimerTxt'
        timer -= Time.deltaTime;
        int minutes = (int)timer / 60;
        int seconds = (int)timer % 60;
        MatchTimerTxt.text =  minutes.ToString() + " : " + seconds.ToString("00");		
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
    }
    public void PlayerTwoScored()
    {
        PlayerTwoScoreAnim.Play("PlayerTwoScoredAnim");
    }
}
