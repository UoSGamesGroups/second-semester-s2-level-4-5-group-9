using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {
    public Dropdown Player1Character;
    public Dropdown Player2Character;

    [Header("Player 1 Character Selection")]
    private int FaceofCharacter = 0;
    public GameObject Penguin;
    public GameObject PolarBear;
    public GameObject Reindeer;
    public GameObject Wolf;

    [Header("Player 2 Character Selection")]
    private int FaceofCharacter2 = 0;
    public GameObject Penguin2;
    public GameObject PolarBear2;
    public GameObject Reindeer2;
    public GameObject Wolf2;

    private GameObject Game_Controller;
    private ValueStorer GameC_Script;

    void Start ()
    {
        Game_Controller = GameObject.Find("GameController");
        GameC_Script = Game_Controller.GetComponent<ValueStorer>();

        Penguin.SetActive(true);
        PolarBear.SetActive(false);
        Reindeer.SetActive(false);
        Wolf.SetActive(false);
        Penguin2.SetActive(true);
        PolarBear2.SetActive(false);
        Reindeer2.SetActive(false);
        Wolf2.SetActive(false);
    }

	void Update ()
    {
        //Below is the code for the character selection
        switch (FaceofCharacter)
        {
            case 0:
                Penguin.SetActive(true);
                PolarBear.SetActive(false);
                Reindeer.SetActive(false);
                Wolf.SetActive(false);
                break;
            case 1:
                Penguin.SetActive(false);
                PolarBear.SetActive(true);
                Reindeer.SetActive(false);
                Wolf.SetActive(false);
                break;
            case 2:
                Penguin.SetActive(false);
                PolarBear.SetActive(false);
                Reindeer.SetActive(true);
                Wolf.SetActive(false);
                break;
            case 3:
                Penguin.SetActive(false);
                PolarBear.SetActive(false);
                Reindeer.SetActive(false);
                Wolf.SetActive(true);
                break;
        }

        switch (FaceofCharacter2)
        {
            case 0:
                Penguin2.SetActive(true);
                PolarBear2.SetActive(false);
                Reindeer2.SetActive(false);
                Wolf2.SetActive(false);
                break;
            case 1:
                Penguin2.SetActive(false);
                PolarBear2.SetActive(true);
                Reindeer2.SetActive(false);
                Wolf2.SetActive(false);
                break;
            case 2:
                Penguin2.SetActive(false);
                PolarBear2.SetActive(false);
                Reindeer2.SetActive(true);
                Wolf2.SetActive(false);
                break;
            case 3:
                Penguin2.SetActive(false);
                PolarBear2.SetActive(false);
                Reindeer2.SetActive(false);
                Wolf2.SetActive(true);
                break;
        }

        if (Player1Character.value == 0)
        {
            FaceofCharacter = 0;
            GameC_Script.Player1Character = 0;
        }
        else if (Player1Character.value == 1)
        {
            FaceofCharacter = 1;
            GameC_Script.Player1Character = 1;
        }
        else if (Player1Character.value == 2)
        {
            FaceofCharacter = 2;
            GameC_Script.Player1Character = 2;
        }
        else if (Player1Character.value == 3)
        {
            FaceofCharacter = 3;
            GameC_Script.Player1Character = 3;
        }

        if (Player2Character.value == 0)
        {
            FaceofCharacter2 = 0;
            GameC_Script.Player2Character = 0;
        }
        else if (Player2Character.value == 1)
        {
            FaceofCharacter2 = 1;
            GameC_Script.Player2Character = 1;
        }
        else if (Player2Character.value == 2)
        {
            FaceofCharacter2 = 2;
            GameC_Script.Player2Character = 2;
        }
        else if (Player2Character.value == 3)
        {
            FaceofCharacter2 = 3;
            GameC_Script.Player2Character = 3;
        }
    }
}
