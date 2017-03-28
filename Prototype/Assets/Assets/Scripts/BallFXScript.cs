using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFXScript : MonoBehaviour{
    
    public AudioClip iceSmashSound;

    private AudioSource source;

    [Header("Picks random Volume between these ranges")]
    [Tooltip("Adjusts lowest Pitch")]
    public float pitchLowRange = .5f;
    [Tooltip("Adjusts highest Pitch")]
    public float pitchHighRange = 1.0f;
    

    [Space(5),Tooltip("How loud the sound is, relative to velocity")]
    public float velocityToVol = .2F;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D Coll)
    { 

        if (Coll.gameObject.tag == ("Wall"))
        {
            // Triggers soundFx
            source.pitch = Random.Range(pitchLowRange, pitchHighRange);
            float hitVol = Coll.relativeVelocity.magnitude * velocityToVol;
            source.PlayOneShot(iceSmashSound, hitVol);

            // Gets an IceSmash Object from the IceSmashPooler
            GameObject obj = IceSmashPooler.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
        }
    }
}
