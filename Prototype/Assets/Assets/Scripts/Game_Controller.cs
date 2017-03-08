using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {
    [Header("Players Score")]
    public int Player1Score = 0;
    public int Player2Score = 0;

    // Stores player score as a string
    public Text Player1ScoreTxt;
    public Text Player2ScoreTxt;
    // Stores Winning player text
    public Text WinningPlayer;

    void Start()
    {
        UpdateScoreBoard();
    }

    void Update ()
    {
		if (Player1Score == 5)
        {
            print("Player1 Wins");
            WinningPlayer.text = "Player One Wins!";
        }
        
        if (Player2Score == 5)
        {
            print("Player2 Wins");
            WinningPlayer.text = "Player Two Wins!";
        }
	}
    // Updates score, called from 'Ball_Controller' on goal
    public void UpdateScoreBoard()
    {
        Player1ScoreTxt.text = "Player One: " + Player1Score.ToString();
        Player2ScoreTxt.text = "Player Two: " + Player2Score.ToString();
    }
}
