/*
 * 프로그램명 : AI human Control
 * 작성자 : 2018038041 김서빈 (김서빈, 김종우, 문재식, 박성진, 최병도)
 * 작성일 : 2019.11.20
 * 프로그램 설명 : 시나리오 #1 구현 위해 자동차와 ai 사람의 거리를 계산하여
 *                 ai 사람이 움직이도록 작성하였다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Move : MonoBehaviour  
{
    //GameObject형 변수 선언
    public GameObject cloud;   // AI사람의 위치 저장 객체
    public GameObject car;     // 자동차 객체
    public GameObject human;   // AI사람 객체
    
    float dt;                  // 자동차와 사람 사이의 거리

    public float cloud_z = 0;    // 위치 초기화
    public float speed = 10.0f;  // 사람의 스피드 값 10

    void Start()
    {
        cloud = GameObject.Find("human1");  // AI사람의 객체 이름 찾기
    }

    void Update()
    {
        dt = Vector3.Distance(car.transform.position, human.transform.position);  // 자동차와 AI사람 사이의 거리 계산

        if (dt <= 30)  // 자동차와 AI사람 사이의 거리가 30 이하일 때
        {
            cloud_z = (cloud.GetComponent<Transform>().position.z);  // 해당 오브젝트의 z position을 찾음

            if (cloud_z >= 100)  // 만약 오브젝트의 z값이 100 이상이란면
                cloud.GetComponent<Transform>().position = new Vector3(-1000, -1000, -1000); // clound의 포지션을 (-1000,-1000,-1000)으로 바꿔줌
            else   // 100 초과일 때
                cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime); // 앞으로 이동
        }
    }
}