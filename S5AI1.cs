/*
 *  프로그램명 : 거리 계산에 따른 AI 오브젝트 움직임 구현 (시나리오 #5)
 *  작성자 : 2016039076 김종우 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.11.27
 *  프로그램 설명 : 거리 계산을 통하여 멈춰 있던 AI자동차가 MAIN자동차와 가까워지면
 *                  출발 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class S5AI1 : MonoBehaviour
{
    float dt;           //AI 자동차와 신호등의 거리
    public GameObject Maincar;  //메인 자동차 객체
    public GameObject car;      //AI 자동차 객체
    public GameObject cloud;    //AI 자동차의 위치 저장 객체
    public GameObject obj;      //신호등 객체
    float dt1;                  //메인 자동차와 AI 자동차의 거리

    public float cloud_z = 0;       //위치 초기화
    public float speed = 10.0f;     //자동차 스피드 10

    void Start()
    {
        cloud = GameObject.Find("5AI_car1");     //AI자동차의 객체 이름 찾기
    }

    void FixedUpdate()
    {
        dt1 = Vector3.Distance(Maincar.transform.position, car.transform.position);  //메인 자동차와 AI자동차의 거리 계산
        dt = Vector3.Distance(car.transform.position, obj.transform.position);  //AI 자동차와 신호등의 거리 계산

        cloud_z = (cloud.GetComponent<Transform>().position.z); //위치 저장

        cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);    //위치를 앞으로 이동 

        if (dt <= 10)   //AI자동차와 신호등의 거리가 10 미만일때
        {
            speed = 0.0f;   //자동차 멈춤

        }
        if (dt1 <= 30)    //Main 자동차와 AI 자동차의 거리가 30 미만이 될때
        {
            speed = 30.0f;  //스피드 30
            cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime); // 앞으로 이동
        }
    }
}
