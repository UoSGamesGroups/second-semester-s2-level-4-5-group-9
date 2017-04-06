using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalWinsStorer : MonoBehaviour{

    [Header("Players' Total Wins")]
    public int playerOneWinTotal = 0;
    public int playerTwoWinTotal = 0;

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
