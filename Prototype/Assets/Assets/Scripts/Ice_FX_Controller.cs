using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_FX_Controller : MonoBehaviour
{

    [Space(5), Tooltip("Prefab for the Ice Shatter animation")]
    public GameObject IceShatterFXObj;


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LeftWall")
        {
            IceShatterFX(); 
        }
    }

    void IceShatterFX()
    {
        Instantiate(IceShatterFXObj, transform.position + transform.forward, transform.rotation);
        Debug.Log("Work");
    }
}
