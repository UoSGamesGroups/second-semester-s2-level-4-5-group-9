using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

    public int Player1Score = 0;
    public int Player2Score = 0;
	
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
	}
}
