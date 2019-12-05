/*
 *  프로그램명 : 거리 계산에 따른 AI 오브젝트 움직임 구현 (시나리오 #2)
 *  작성자 : 2016039076 김종우 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.11.22
 *  프로그램 설명 : 신호등과 메인자동차, AI 자동차의 거리를 계산하여 
 *                  AI 자동차 움직임 구현
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AI2 : MonoBehaviour
{
    float dt;           //AI 자동차와 신호등의 거리
    public GameObject Maincar;  //메인 자동차 객체
    public GameObject car;      //AI 자동차 객체
    public GameObject cloud;    //AI 자동차의 위치 저장 객체
    public GameObject obj;      //신호등 객체
    float dt1;                  //메인 자동차와 AI 자동차의 거리

    public float cloud_z = 0;       //위치 초기화
    public float speed = 20.0f;     //자동차 스피드 20

    void Start()
    {
        cloud = GameObject.Find("AI_car2");     //AI자동차의 객체 이름 찾기
    }

    void FixedUpdate()
    {
        dt1 = Vector3.Distance(Maincar.transform.position, car.transform.position);  //메인 자동차와 AI자동차의 거리 계산
        dt = Vector3.Distance(car.transform.position, obj.transform.position);  //AI 자동차와 신호등의 거리 계산

        cloud_z = (cloud.GetComponent<Transform>().position.z); //위치 저장

        cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);    //위치를 앞으로 이동 

        if (dt <= 40)   //AI자동차와 신호등의 거리가 40 미만일때
        {
            speed = 0.0f;   //자동차 멈춤
        }
        if (dt1 <= 60)    //Main 자동차와 AI 자동차의 거리가 60 미만이 될때
        {
            speed = 25.0f;  //스피드 25
            cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime); // 앞으로 이동
        }
    }
}
