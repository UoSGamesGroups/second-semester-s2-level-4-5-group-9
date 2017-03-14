using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    public static List<GameObject> Balls;

    public float[] VelocitySettings;

    public float LaunchForce;

    private GameObject GameController;
    private Game_Controller GCScript;

    private Rigidbody2D rb;

    void Start()
    {
        if ( Balls == null )
        {
            Balls = new List<GameObject>();
        }

        Balls.Add(gameObject);

        rb = GetComponent<Rigidbody2D>();

        GameController = GameObject.Find("Game_Controller");
        GCScript = GameController.GetComponent<Game_Controller>();

        Launch();
    }

    void Update()
    {
    
    }

    public void Throw(int player, int throwCharge, Vector2 pos, Player_Controller.ThrowDirection ThrowDir)
    {
        int vertModifier = 0;

        if (ThrowDir == Player_Controller.ThrowDirection.Down)
            vertModifier = -1;
        else if (ThrowDir == Player_Controller.ThrowDirection.Up)
            vertModifier = 1;

        int horizModifier = player == 1 ? 1 : -1;

        Vector2 newVelocity = new Vector2(VelocitySettings[throwCharge] * horizModifier, VelocitySettings[throwCharge] * vertModifier);
        rb.velocity = newVelocity;

        transform.position = pos;
    }

    public void Launch()
    {
        Vector2 launchDirection = Random.insideUnitCircle;
        rb.AddForce(launchDirection * LaunchForce, ForceMode2D.Impulse);
    }

    IEnumerator Reset()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        yield return new WaitForSeconds(1);
        Launch();
    }

    void OnCollisionEnter2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == ("LeftGoal"))
        {
            GCScript.Player2Score++;
            GCScript.UpdateScoreBoard();
            StartCoroutine (Reset());
        }

        if (Coll.gameObject.tag == ("RightGoal"))
        {
            GCScript.Player1Score++;
            GCScript.UpdateScoreBoard();
            StartCoroutine (Reset());
        }
    }
}