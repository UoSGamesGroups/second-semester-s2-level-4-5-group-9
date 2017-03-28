using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Controller : MonoBehaviour {

    bool BlockCD = true;
    private int Cooldown = 10;
    public bool BlockActivated = false;
    private float Visable = 0.3f;
    private bool CanBlock = true;
    public GameObject BlockAsset;
    private GameObject Player_Controller;
    private Player_Controller Player_Script;

    void Start ()
    {
        Player_Controller = this.gameObject;
        Player_Script = Player_Controller.GetComponent<Player_Controller>();
        BlockAsset.SetActive(false);
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
        BlockAsset.SetActive(true);
        BlockActivated = true;
        yield return new WaitForSeconds(Visable);
        BlockActivated = false;
        BlockAsset.SetActive(false);
        BlockCD = false;
    }
}