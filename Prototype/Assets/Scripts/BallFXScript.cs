﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFXScript : MonoBehaviour{
    
    private AudioSource source;

    public AudioClip iceSmashSound;
    public AudioClip splashSound;
    public AudioClip iceScrapeSound;
    public AudioClip goalPostSound;

    public bool _scoringSfxEnabled;

    [Header("Ice Smash SFX")]
    [Header("Picks random Pitch between these ranges")]
    [Tooltip("Adjusts lowest Pitch")]
    public float icePitchLowRange = .5f;
    [Tooltip("Adjusts highest Pitch")]
    public float icePitchHighRange = 1.0f;
    [Space(5), Tooltip("How loud the sound is, relative to velocity")]
    public float velocityToVol = .2F;

    [Header("Splash SFX")]
    [Header("Picks random Pitch between these ranges")]
    [Tooltip("Adjusts lowest Pitch")]
    public float splashPitchLowRange = .9f;
    [Tooltip("Adjusts highest Pitch")]
    public float splashPitchHighRange = 1.2f;

    [Header("Adjusts Goal Post Hit Sfx Volume"), Range(0.01f, 1.0f)]
    public float goalPostVol = 0.5f;

    //------------ Not triggering TODO ----------------------//

    [Header("Ice Scrape SFX")]
    [Header("Picks random Pitch between these ranges")]
    [Tooltip("Adjusts lowest Pitch")]
    public float iceScrapeLowRange = .5f;
    [Tooltip("Adjusts highest Pitch")]
    public float iceScrapeHighRange = 1.0f;
    [Space(5), Tooltip("How loud the sound is, relative to puck velocity")]
    public float scrapeVelocityToVol = .1F;

    [Header("Ice Smash Prefab")]
    [Space(5), Tooltip("How large the Ice Smash is, relative to puck velocity")]
    public float velocityToIceSize = .01f;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        _scoringSfxEnabled = true; 
    }


    void OnCollisionEnter2D(Collision2D Coll)
    { 

        if (Coll.gameObject.tag == ("Wall"))
        {
            // Triggers soundFx
            source.pitch = Random.Range(icePitchLowRange, icePitchHighRange);
            float hitVol = Coll.relativeVelocity.magnitude * velocityToVol;
            source.PlayOneShot(iceSmashSound, hitVol);

            // Gets an IceSmash Object from the IceSmashPooler
            GameObject obj = IceSmashPooler.current.GetPooledObject();
            if (obj == null) return;
            float iceSmashSize = Coll.relativeVelocity.magnitude * velocityToIceSize;
            obj.transform.localScale += new Vector3(iceSmashSize, iceSmashSize, iceSmashSize);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
        }
        if (Coll.gameObject.tag == ("LeftGoal") && (_scoringSfxEnabled))
        {
            GoalSFX();
        }

        if (Coll.gameObject.tag == ("RightGoal") && (_scoringSfxEnabled))
        {
            GoalSFX();
        }

        if (Coll.gameObject.tag == ("CenterLine"))
        {
            source.pitch = Random.Range(iceScrapeLowRange, iceScrapeHighRange);
            float hitVol = Coll.relativeVelocity.magnitude * scrapeVelocityToVol;
            source.PlayOneShot(iceScrapeSound, hitVol);
        }
    }

    void OnTriggerEnter2D(Collider2D Coll)
    {
        if (Coll.gameObject.tag == ("GoalPost"))
        {
            source.PlayOneShot(goalPostSound, goalPostVol);
        }
    }

    void GoalSFX()
    {
        source.pitch = Random.Range(splashPitchLowRange, splashPitchHighRange);
        source.PlayOneShot(splashSound, 1f);
    }
}
