/*
 *  프로그램명 : 거리 계산에 따른 AI 오브젝트 움직임 구현 (엔딩)
 *  작성자 : 2016039076 김종우 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.11.30
 *  프로그램 설명 : 메인 자동차가 목표지점에 도달하면 경찰차 도착 후 엔딩
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class police2 : MonoBehaviour
{
    float dt;           //AI 자동차와 캡슐 거리
    float dt1;          //메인 자동차와 목표지점 거리
    public GameObject car;      //AI 자동차 객체
    public GameObject cloud;    //AI 자동차의 위치 저장 객체
    public GameObject cap;      //캡슐 객체
    public GameObject fin;      //목표지점 객체
    public GameObject Maincar;  //메인 자동차 객체

    public float cloud_z = 0;       //위치 초기화
    public float speed = 0.0f;     //자동차 스피드 0

    void Start()
    {
        cloud = GameObject.Find("p2");     //AI자동차의 객체 이름 찾기
        speed = 100.0f;     //자동차 스피드 100
    }

    void FixedUpdate()
    {
        dt = Vector3.Distance(car.transform.position, cap.transform.position);  //AI 자동차와 캡슐 객체 거리 계산
        dt1 = Vector3.Distance(Maincar.transform.position, fin.transform.position);  //메인 자동차와 목표지점 거리 계산
        cloud_z = (cloud.GetComponent<Transform>().position.z); //위치 저장

        if (dt1 <= 8)   //메인자동차와 목표지점 거리가 8 이하 일때
        {
            cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);    //위치를 앞으로 이동 
        }
        if (dt <= 12)   //AI자동차와 캡슐의 거리가 12 이하일때
        {
            speed = 0.0f;   //자동차 멈춤
        }

    }
}