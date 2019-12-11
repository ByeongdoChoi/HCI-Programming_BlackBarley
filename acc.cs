/*
 * 프로그램명 : 자동차 엔진음을 나오기 위한 변수
 * 작성자 : 2016039033 최병도 (김종우, 박성진, 김서빈, 문재식)
 * 작성일 : 2019.11.30
 * 프로그램 설명 : 라디오 음악과 차량의 엔진음을 동시에 재생하는 함수
 */
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
