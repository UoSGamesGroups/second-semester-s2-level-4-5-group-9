using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Space(5), Tooltip("Turns camera jolt Lerp/Smoothing On/Off")]
    public bool smoothOn = true;
    [Space(5), Tooltip("The Amount the camera Jolts on goal event")]
    public float offCenterAmount;
    private float offCenterDir; // Used to set jolt to Left or Right
    [Space(5), Tooltip("Adjusts camera Jolt Lerp/Smooth amount"), Range(0.01f, 1.0f)]
    public float joltSmoothAmount;
    [Space(5), Tooltip("Adjusts camera Reset Lerp/Smooth amount"), Range(0.01f, 1.0f)]
    public float resetSmoothAmount;
    [Space(5), Tooltip("Amount of time to wait before reset/returing camera to center")]
    public float resetWaitTime = 0.2f;

    private Vector3 desiredPos;     // Stores position to jolt to
    private Vector3 centerPos;      // Stores return/reset position

    void Start()
    {
        // Sets reset position
        centerPos = transform.position;
    }

    public void CameraJoltLeft()
    {
            offCenterDir = -offCenterAmount;
            StartCoroutine(CamJolt());
    }

    public void CameraJoltRight()
    {
            offCenterDir = offCenterAmount;
            StartCoroutine(CamJolt());
    }

    IEnumerator CamJolt()
        {
            desiredPos = transform.position + new Vector3(offCenterDir, 0, 0);
            while (Vector3.Distance(transform.position, desiredPos) > 0.05f)
            {
                transform.position = smoothOn ? Vector3.Lerp(transform.position, desiredPos, joltSmoothAmount) : desiredPos;
            }

            yield return new WaitForSeconds(resetWaitTime);

            while (Vector3.Distance(transform.position, centerPos) > 0.05f)
            {
                transform.position = smoothOn ? Vector3.Lerp(transform.position, centerPos, resetSmoothAmount) : centerPos;
                yield return null;
            }
    }
}