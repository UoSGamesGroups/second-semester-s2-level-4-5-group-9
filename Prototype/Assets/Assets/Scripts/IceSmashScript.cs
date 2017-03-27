using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSmashScript : MonoBehaviour {

    // Time until Object is disabled after being pulled from the object pool
    public float IceSmashLenth;

    void OnEnable()
    {
        Invoke("Destroy", IceSmashLenth);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
