/*
 *  프로그램명 : 거리 계산에 따른 AI 오브젝트 움직임 구현 (시나리오 #3, 4)
 *  작성자 : 2016039006 문재식 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.11.27
 *  프로그램 설명 : 신호 변경과 동시에 차가 급발진하여 끼어들기
 *                 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar_12 : Move     // Move 클래스 상속
{
    public GameObject Car;  // 끼어들기 차량
    Vector3 pos_car;        // 끼어들기 차량의 좌표
    Vector3 pos;            // 현재 차량의 좌표

    void Start()
    {
       
    }

    void Update()
    {
        Forward();              // 차를 앞으로 이동
        pos_car = Car.transform.position;   // 끼어들기 차량 좌표
        pos = this.transform.position;      // 현재 차량 좌표

        if (pos.x <= TargetTraffic.transform.position.x)
            Stop();     // 신호등 이전에서는 빨간불과 초록불 신호에 영향을 받음
        else if (pos.x >= TargetTraffic.transform.position.x && pos.x <= 0.0f)
            Slow();     // 신호등 이후에서는 끼어들기 차량에 반응
      // else            // 시나리오 이후 차량 속도를 올린다
           // speed = 30;
    }

    void Slow()
    {
        if (pos_car.z - pos.z <= 5.0f)  // 끼어들기 차량과의 거리가 5이내면
            speed = 7;              // 속도를 갑자기 줄인다

        if (pos_car.x - pos.x >= 50.0f)          // 어느정도 멀어지면
            speed = 20;                          // 다시 속도 올림
    }

    void Stop()
    {
        if (GameObject.Find("TL11").GetComponent<TL_11>().GreenLight.enabled == true)
            speed = 15; // 신호등이 초록불이면 앞으로 감
        else if (GameObject.Find("TL11").GetComponent<TL_11>().RedLight.enabled == true)
            speed = 0;  // 빨간불이면 정지
    }

}
