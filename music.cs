/*
 * 프로그램명 : 음악 동시 재생
 * 작성자 : 2016039033 최병도 (김종우, 박성진, 김서빈, 문재식)
 * 작성일 : 2019.11.22
 * 프로그램 설명 : 라디오 음악과 차량의 엔진음을 동시에 재생하는 함수
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource RadioPlayer; //유니티에서 라디오를 재생하기 위한 오브젝트
    //음악 파일이 오브젝트 1, 2, 3, 4
    public AudioClip radio1; 
    public AudioClip radio2; 
    public AudioClip radio3;
    public AudioClip radio4;

    void Start()
    {
        RadioPlayer = GetComponent<AudioSource>(); //오디오 소스 컴포넌트를 얻어와 유니티의 오디오 소스와 연결시킨다.

        PlayRadio(RadioPlayer); //오디오 소스를 함수에 넘겨 음악을 재생
    }
    public void PlayRadio(AudioSource audioPlayer)
    {
        int random = Random.Range(1, 5); //랜덤으로 음악을 재생하기 위한 random 변수
       
        //얻은 랜덤 변수에 따라 음악 재생
        if (random==1)
        {
            audioPlayer.Stop(); //앞서 재생하던 음악을 정지 시킨다.
            audioPlayer.clip = radio1; //라디오1을 클립에 넣어준다.
            audioPlayer.loop = false;  //루프를 반복하진 않는다.
            audioPlayer.time = 0;      //0초 부터 음악 시작
            audioPlayer.Play();        //음악 재생
        }
        else if(random==2)
        {
            audioPlayer.Stop();
            audioPlayer.clip = radio2;
            audioPlayer.loop = false;
            audioPlayer.time = 0;
            audioPlayer.Play();
        }
        else if (random == 3)
        {
            audioPlayer.Stop();
            audioPlayer.clip = radio3;
            audioPlayer.loop = false;
            audioPlayer.time = 0;
            audioPlayer.Play();
        }
        else if (random == 4)
        {
            audioPlayer.Stop();
            audioPlayer.clip = radio4;
            audioPlayer.loop = false;
            audioPlayer.time = 0;
            audioPlayer.Play();
        }
    }
}
