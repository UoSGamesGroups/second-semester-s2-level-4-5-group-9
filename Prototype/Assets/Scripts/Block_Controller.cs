using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Controller : MonoBehaviour {

    bool BlockCD = true;
    private int Cooldown = 10;
    public bool BlockActivated = false;
    private float Visable = 0.3f;
    private bool CanBlock = true;
    public CircleCollider2D PC;
    private GameObject Player_Controller;
    private Player_Controller Player_Script;
    public GameObject BlockObject;

    void Start ()
    {
        Player_Controller = this.gameObject;
        Player_Script = Player_Controller.GetComponent<Player_Controller>();
        PC.GetComponent<CircleCollider2D>().enabled = false;
        BlockObject.GetComponent<Animation>()["BlockAnim"].wrapMode = WrapMode.Once;
    }


    void Update()
    {
        switch (Player_Script.Player)
        {
            case 0:
                break;
            case 1:
                if (BlockCD && (Input.GetKeyDown(KeyCode.R)) && CanBlock)
                {
                    StartCoroutine(BlockActive());
                    CanBlock = false;
                }
                else if (!BlockCD)
                {
                    StartCoroutine(BlockCooldown());
                }
                break;
            case 2:
                if ((BlockCD) && (Input.GetKeyDown(KeyCode.P)) && CanBlock)
                {
                    StartCoroutine(BlockActive());
                    CanBlock = false;
                }
                else if (!BlockCD)
                {
                    StartCoroutine(BlockCooldown());
                }
                break;
        }
    }

    IEnumerator BlockCooldown ()
    {
        int tempTimer = Cooldown;

        for (int i = Cooldown; i > 0; i -= 1)
        {
            tempTimer -= 1;
            yield return new WaitForSeconds(1);
        }
        CanBlock = true;
        BlockCD = true;
    }

    IEnumerator BlockActive ()
    {
        PC.GetComponent<CircleCollider2D>().enabled = true;
        BlockActivated = true;
        BlockObject.GetComponent<Animation>().Play("BlockAnim");
        yield return new WaitForSeconds(Visable);
        BlockActivated = false;
        PC.GetComponent<CircleCollider2D>().enabled = false;
        BlockCD = false;
    }
}