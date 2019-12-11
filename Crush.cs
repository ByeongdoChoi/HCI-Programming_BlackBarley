using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Crush : MonoBehaviour
{
    private AudioSource RadioPlayer;
    public AudioClip radio1;
    void Start()
    {
        RadioPlayer = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        PlayRadio(RadioPlayer);
        Invoke("second", 2.0f);
        
    }
    void second()
    {
        SceneManager.LoadScene("DDS_End");
    }
    public void PlayRadio(AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = radio1;
        audioPlayer.loop = false;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
}
