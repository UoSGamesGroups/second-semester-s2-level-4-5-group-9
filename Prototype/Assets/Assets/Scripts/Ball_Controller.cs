using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Controller : MonoBehaviour
{
    public static List<GameObject> Balls;

    public float[] VelocitySettings;

    public float LaunchForce;

    private int PlayerScored = 0;

    // Varibles to update score UI
    private GameObject GameController;
    private Game_Controller GCScript;
    // Varibles for camera jolt
    private GameObject CamControllerObj;
    private CameraController CCScript;

    public Text ResumeText;
    public GameObject resumetext;
    private float ResumeTimer = 4;
    private int ResumeGame = 0;
    private Rigidbody2D rb;

    // bool is changed by Game_Controller Script
    public bool _scoringEnabled;

    void Start()
    {
        if (Balls == null)
        {
            Balls = new List<GameObject>();
        }

        resumetext.SetActive(false);

        Balls.Add(gameObject);

        rb = GetComponent<Rigidbody2D>();

        // Gets/sets compononents to up date UI
        GameController = GameObject.Find("Game_Controller");
        GCScript = GameController.GetComponent<Game_Controller>();
        // Gets/sets compononents for camera jolt
        CamControllerObj = GameObject.Find("Main Camera");
        CCScript = CamControllerObj.GetComponent<CameraController>();
        // Makes sure _scoringEnabled is set true on start 
        _scoringEnabled = true;

        Launch();
    }

    void Update()
    {
        if (ResumeGame == 1)
        {
            ResumeTimer -= Time.deltaTime;
            int seconds = (int)ResumeTimer % 60;
            ResumeText.text = seconds.ToString("00");
            if (ResumeTimer <= 0)
            {
                ResumeGame = 2;
            }
        }
        else if (ResumeGame == 2)
        {
            resumetext.SetActive(false);
            StartBall();
            ResumeGame = 0;
        }
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
        ResumeGame = 1;
        resumetext.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D Coll)
    {
        if ((Coll.gameObject.tag == ("LeftGoal")) && (_scoringEnabled))
        {
            CCScript.CameraJoltLeft();      // Triggers camera jolt 
            GCScript.PlayerTwoScored();     // Triggers Player Two scored Animation
            GCScript.Player2Score++;
            PlayerScored = 2;
            GCScript.UpdateScoreBoard();    // Updates score UI
            StartCoroutine(Reset());
        }

        if ((Coll.gameObject.tag == ("RightGoal")) && (_scoringEnabled))
        {
            CCScript.CameraJoltRight();     // Trigger camera jolt
            GCScript.PlayerOneScored();     // Triggers Player One scored Animation
            GCScript.Player1Score++;
            PlayerScored = 1;
            GCScript.UpdateScoreBoard();    // Updates score UI
            StartCoroutine(Reset());
        }
    }

    void StartBall()
    {
        if (PlayerScored == 1)
        {
            Vector2 LaunchDirection = new Vector2(Random.Range(0.1f, 0.99f), Random.Range(0.1f, 0.99f));
            rb.AddForce(LaunchDirection * LaunchForce, ForceMode2D.Impulse);
            PlayerScored = 0;
        }

        if (PlayerScored == 2)
        {
            Vector2 LaunchDirection = new Vector2(Random.Range(-0.1f, -0.99f), Random.Range(-0.1f, -0.99f));
            rb.AddForce(LaunchDirection * LaunchForce, ForceMode2D.Impulse);
            PlayerScored = 0;
        }
    }
}