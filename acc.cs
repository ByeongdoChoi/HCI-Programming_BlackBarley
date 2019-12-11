using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acc : MonoBehaviour
{
    private AudioSource RadioPlayer;
    public AudioClip radio1;
    // Start is called before the first frame update
    void Start()
    {
        RadioPlayer = GetComponent<AudioSource>();

        PlayRadio(RadioPlayer);
    }
    public void PlayRadio(AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = radio1;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
}
