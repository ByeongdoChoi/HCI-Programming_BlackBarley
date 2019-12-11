/*
 * 프로그램명 : 충돌 처리를 하는 프로그램
 * 작성자 : 2016039033 최병도 (김종우, 박성진, 김서빈, 문재식)
 * 작성일 : 2019.12.05
 * 프로그램 설명 : 자동차와 다른 오브젝트 간에 충돌시 처리하는 프로그램
 */
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
        //충돌 효과음을 주기 위한 변수
        RadioPlayer = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        //충돌시 충돌 효과음이 나온 후 2초 뒤에 종료 화면이 출현된다
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
