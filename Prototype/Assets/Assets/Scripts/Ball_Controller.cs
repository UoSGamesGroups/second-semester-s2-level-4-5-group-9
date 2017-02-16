using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    private float RandomX = 0;
    [SerializeField] private int Ball = 0;

    void Start()
    {
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

    void OnCollisionEnter2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == ("RightWall"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Coll.gameObject.tag == ("LeftWall"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}