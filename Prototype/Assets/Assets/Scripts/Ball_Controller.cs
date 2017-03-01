using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    private float RandomX = 0;
    [SerializeField] private int Ball = 0;
    private GameObject GameController;
    private Game_Controller GCScript;

    void Start()
    {
        GameController = GameObject.Find("Game_Controller");
        GCScript = GameController.GetComponent<Game_Controller>();

        switch (Ball)
        {
            case 0:
                RandomX = Random.Range(0, 1);
                if (RandomX == 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(15f, 15f);
                }
                if (RandomX == 1)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-15f, -15f);
                }
                break;
            case 1:
                GetComponent<Rigidbody2D>().velocity = new Vector2(15f, 15f);
                break;
            case 2:
                GetComponent<Rigidbody2D>().velocity = new Vector2(-15f, -15f);
                break;
        }
    }

    IEnumerator Reset()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        yield return new WaitForSeconds(1);
        RandomX = Random.Range(0, 1);
        if (RandomX == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(15f, 15f);
        }
        if (RandomX == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-15f, -15f);
        }
    }

    void OnCollisionEnter2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == ("RightWall"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
            AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        }

        if (Coll.gameObject.tag == ("LeftWall"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
        if (Coll.gameObject.tag == ("SideWall"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
        if (Coll.gameObject.tag == ("LeftGoal"))
        {
            GCScript.Player2Score++;
            StartCoroutine (Reset());
        }

        if (Coll.gameObject.tag == ("RightGoal"))
        {
            GCScript.Player1Score++;
            StartCoroutine (Reset());
        }
    }
}