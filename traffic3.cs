/*
 *  프로그램명 : 신호등 점등 구현 (엔딩)
 *  작성자 : 2016039076 김종우 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.12.04
 *  프로그램 설명 : 노란불로 점등되는 신호등을 구현하여 자유로운 신호 구현
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class traffic3 : MonoBehaviour
{
    [SerializeField] private Light YLight1; //노란불1
    [SerializeField] private Light YLight2; //노란불2
    [SerializeField] private Light YLight3; //노란불3


    void Start() 
    {
    }

    void Update()       //인보크 함수를 사용해 노란불 3개를 점등형식으로 구현
    {
        Invoke("Yellow1", 1.0f);
        Invoke("Yellow2", 0.8f);
    }


    void Yellow1() 
    {
        YLight1.GetComponent<Light>().enabled = true;
        YLight2.GetComponent<Light>().enabled = true;
        YLight3.GetComponent<Light>().enabled = true;
    }

    void Yellow2() 
    {
        YLight1.GetComponent<Light>().enabled = true;
        YLight2.GetComponent<Light>().enabled = false;
        YLight3.GetComponent<Light>().enabled = false;
    }

    void Yellow3() 
    {
        YLight1.GetComponent<Light>().enabled = false;
        YLight2.GetComponent<Light>().enabled = false;
        YLight3.GetComponent<Light>().enabled = false;
    }
}
