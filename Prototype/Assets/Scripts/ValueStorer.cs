using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueStorer : MonoBehaviour
{
    public int Player1Character = 0;
    public int Player2Character = 0;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
