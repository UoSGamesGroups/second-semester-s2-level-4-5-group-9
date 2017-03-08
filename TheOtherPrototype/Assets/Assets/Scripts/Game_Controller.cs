using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {
	[Header("Player's Scores")]
    public int Player1Score = 0;
    public int Player2Score = 0;
	
	// Stores player score as a string
    public Text Player1ScoreTxt;
    public Text Player2ScoreTxt;
    // Stores Winning player text
    //public Text WinningPlayer;
    // Timer varibles
    public Text MatchTimerTxt;
    [SerializeField]
    private float timer = 0f;
	
	    void Start()
    {
        UpdateScoreBoard();
    }
	
	void Update ()
    {
		if (Player1Score == 5)
        {
            print("Player1 Wins");
        }
        
        if (Player2Score == 5)
        {
            print("Player2 Wins");
        }
        // Updates timer, sorts into mins and secs, updates 'MatchTimerTxt'
        timer += Time.deltaTime;
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
}
