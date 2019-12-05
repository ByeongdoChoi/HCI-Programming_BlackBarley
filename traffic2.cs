/*
 *  프로그램명 : 신호등 구현
 *  작성자 : 2016039076 김종우 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.12.02
 *  프로그램 설명 : 차량 거리에 따른 신호등 신호 구현
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class traffic2 : MonoBehaviour
{
    private float dt;   //자동차와 신호등 구현
    public GameObject car;  // AI 자동차 객체
    [SerializeField] private Light RedLight1;   //빨간불
    [SerializeField] private Light YellowLight1;    //노란불
    [SerializeField] private Light GreenLight1; //초록불


    void Start()    //시작시 빨간불
    {
        Red();
    }

    void Update()
    {

        dt = Vector3.Distance(car.transform.position, this.transform.position); //자동차, 신호등 거리

        if (dt <= 40)   //거리가 40이하일때 초록불
        {
            Green();
        }

    }


    void Red()  // 빨간불
    {
        RedLight1.GetComponent<Light>().enabled = true;
        YellowLight1.GetComponent<Light>().enabled = false;
        GreenLight1.GetComponent<Light>().enabled = false;
    }

    void Yellow() // 노란불
    {
        RedLight1.GetComponent<Light>().enabled = false;
        YellowLight1.GetComponent<Light>().enabled = false;
        GreenLight1.GetComponent<Light>().enabled = false;
    }

    void Green() // 초록불
    {
        RedLight1.GetComponent<Light>().enabled = false;
        YellowLight1.GetComponent<Light>().enabled = false;
        GreenLight1.GetComponent<Light>().enabled = true;
    }
}
