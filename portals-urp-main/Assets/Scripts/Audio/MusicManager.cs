using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClipHolder level1Music;

    public void PlayMusic()
    {
        AudioManager.Instance.PlayMusic(level1Music.AudioClip, level1Music.Volume);
    }
}
