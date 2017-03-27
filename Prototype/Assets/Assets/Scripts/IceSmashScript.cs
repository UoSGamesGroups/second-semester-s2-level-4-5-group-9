using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSmashScript : MonoBehaviour {

    [Space(5), Tooltip("Time until Object is disabled, after being pulled from the object pool")]
    public float IceSmashLength;

    void OnEnable()
    {
        Invoke("Destroy", IceSmashLength);
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
