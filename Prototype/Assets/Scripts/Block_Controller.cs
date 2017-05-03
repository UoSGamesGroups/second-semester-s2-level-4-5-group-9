using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Controller : MonoBehaviour {

    bool BlockCD = true;
    private int Cooldown = 10;
    private float Visable = 1.0f;
    private bool CanBlock = true;
    public CapsuleCollider2D PC;
    private GameObject Player_Controller;
    private Player_Controller Player_Script;
    public Animator Blockanimm;
    public GameObject BlockObj;

    void Start ()
    {
        Player_Controller = this.gameObject;
        Player_Script = Player_Controller.GetComponent<Player_Controller>();
        PC.GetComponent<CapsuleCollider2D>().enabled = false;
        BlockObj.GetComponent<SpriteRenderer>().enabled = false;
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
        BlockObj.GetComponent<SpriteRenderer>().enabled = true;
        Blockanimm.SetBool("Block", true);
        yield return new WaitForSeconds(0.3f);
        PC.GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.7f);
        Blockanimm.SetBool("Block", false);
        PC.GetComponent<CapsuleCollider2D>().enabled = false;
        BlockObj.GetComponent<SpriteRenderer>().enabled = false;
        BlockCD = false;
    }
}