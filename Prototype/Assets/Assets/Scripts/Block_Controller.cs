using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Controller : MonoBehaviour {

    bool BlockCD = true;
    private int Cooldown = 10;
    public BoxCollider2D BlockCollider;
    public bool BlockActivated = false;
    private int Visable = 1;
    private GameObject Player_Controller;
    private Player_Controller Player_Script;

    void Start ()
    {
        Player_Controller = this.gameObject;
        Player_Script = Player_Controller.GetComponent<Player_Controller>();
        BlockCollider.enabled = false;
	}


    void Update()
    {
        switch (Player_Script.Player)
        {
            case 0:
                break;
            case 1:
                if ((BlockCD) && (Input.GetKeyDown(KeyCode.R)))
                {
                    StartCoroutine(BlockActive());
                }
                else if (!BlockCD)
                {
                    StartCoroutine(BlockCooldown());
                }
                break;
            case 2:
                if ((BlockCD) && (Input.GetKeyDown(KeyCode.P)))
                {
                    StartCoroutine(BlockActive());
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

        BlockCD = true;
    }

    IEnumerator BlockActive ()
    {
        BlockCollider.enabled = true;
        BlockActivated = true;
        //Play Animation
        //Instantiate the image
        yield return new WaitForSeconds(Visable);
        BlockActivated = false;
        BlockCollider.enabled = false;
        BlockCD = false;
    }
}