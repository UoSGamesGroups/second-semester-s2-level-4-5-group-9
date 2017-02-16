using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private int Player = 0;
    private float Speed = 7f;
    private float MoveX = 0f;
    private float MoveY = 0f;
    private GameObject[] Balls;
    private GameObject ThePlayer;

    private bool BallCaught = false;
    private GameObject BallToThrow;
    public GameObject Ball1;
    public GameObject Ball2;

    IEnumerator Start()
    {
        while (true)
        {
            Balls = GameObject.FindGameObjectsWithTag("Ball");
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        foreach (GameObject Ball in Balls)
        {
            switch (Player)
            {
            case 0:
                break;
            case 1:
                ThePlayer = GameObject.FindGameObjectWithTag("Player1");
                BallDistance(ThePlayer, KeyCode.E, Ball);
                break;
            case 2:
                ThePlayer = GameObject.FindGameObjectWithTag("Player2");
                BallDistance(ThePlayer, KeyCode.O, Ball);
                break;
            }
        }

        switch (Player)
        {
            case 0:
                break;
            case 1:
                if (Input.GetKey(KeyCode.A))
                    MoveX = -1;
                else if (Input.GetKey(KeyCode.D))
                    MoveX = 1;
                else
                    MoveX = 0;

                if (Input.GetKey(KeyCode.W))
                    MoveY = 1;
                else if (Input.GetKey(KeyCode.S))
                    MoveY = -1;
                else
                    MoveY = 0;
                break;
            case 2:

                if (Input.GetKey(KeyCode.J))
                    MoveX = -1;
                else if (Input.GetKey(KeyCode.L))
                    MoveX = 1;
                else
                    MoveX = 0;

                if (Input.GetKey(KeyCode.I))
                    MoveY = 1;
                else if (Input.GetKey(KeyCode.K))
                    MoveY = -1;
                else
                    MoveY = 0;
                break;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(MoveX * Speed, MoveY * Speed);

        if (BallCaught)
        {
            switch (Player)
            {
                case 1:
                    ThePlayer = GameObject.FindGameObjectWithTag("Player1");
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        BallToThrow = Ball1;
                        print("GO GO SANIC");
                        Instantiate(BallToThrow, ThePlayer.transform.position, ThePlayer.transform.rotation);
                        BallCaught = false;
                    }
                    break;
                case 2:
                    ThePlayer = GameObject.FindGameObjectWithTag("Player2");
                    if (Input.GetKeyUp(KeyCode.O))
                    {
                        BallToThrow = Ball2;
                        print("GO GO SONIC");
                        Instantiate(BallToThrow, new Vector3(ThePlayer.transform.position.x, ThePlayer.transform.position.y,0), ThePlayer.transform.rotation);
                        BallCaught = false;
                    }
                    break;
            }
        }
    }

    void BallDistance(GameObject player, KeyCode pressedKey, GameObject Ball)
    {
        if (Ball != null)
        {
            if (Vector3.Distance(player.transform.position, Ball.transform.position) < 1.0f && Input.GetKeyDown(pressedKey))
            {
                BallCaught = true;
                Destroy(Ball.gameObject);
            }
        }
    }
}