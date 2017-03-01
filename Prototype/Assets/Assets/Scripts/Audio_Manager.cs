using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour {

    public AudioMixer mainMixer;

    public void SetMusicLvl(float musicLvl)
    {
        mainMixer.SetFloat("musicVol", musicLvl);
    }
    public void SetsfxLvl(float sfxLvl)
    {
        mainMixer.SetFloat("sfxVol", sfxLvl);
    }
}