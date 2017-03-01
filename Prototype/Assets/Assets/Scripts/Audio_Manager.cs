using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour {

    public AudioMixer mainMixer;                            // Gets the mixer

    public void SetMusicLvl(float musicLvl)
    {
        mainMixer.SetFloat("musicVol", musicLvl);           // Will adjust the BG music volume level
    }
    public void SetsfxLvl(float sfxLvl)                     // Will adjust the sfx level
    {
        mainMixer.SetFloat("sfxVol", sfxLvl);
    }
}