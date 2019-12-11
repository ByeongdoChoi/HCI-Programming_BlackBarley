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

public class AICar_11 : Move // Move클래스 상속
{
    public int Rspeed; // 차선 이동 속도
    public int fastspeed;   // 급발진 속도
    public GameObject Car;  // 운전 차량
    Vector3 pos_mycar;        // 운전 차량의 좌표
    Vector3 pos;            // 현재 차량의 좌표
    Vector3 pos_tl;         // 신호등 좌표

    void Start()
    {
        pos_tl = TargetTraffic.transform.position;
    }

    void Update()
    {
        pos = this.transform.position;  // 현재 차량의 좌표
        pos_mycar = Car.transform.position; // 운전 차량의 좌표

        if (pos_mycar.x >= -300)          // 운전 차량이 근처에 오면 움직이기 시작
        {
            if (pos.x <= pos_tl.x)    // 신호등 이전에서는 빨간불과 초록불 신호에 영향을 받음 
            {
                Forward();  // 급발진을 위해 전진 함수를 분류
                Stop();     // 신호등 빨간불에 정지
            }

            else if (pos.x >= pos_tl.x)   // 신호등 이후에서는 끼어들기 시도
            {
                FastForward();  // 급발진을 위해 전진 함수 분류
                Interrupt();    // 끼어들기 함수
            }
        }
    }

    void Stop()
    {
        if (GameObject.Find("TrafficLight3").GetComponent<TL_11>().GreenLight.enabled == true)
            speed = 8;
        else if (GameObject.Find("TrafficLight3").GetComponent<TL_11>().RedLight.enabled == true && Vector3.Distance(pos_tl, pos) <= 30)
            speed = 0;  // 신호등과의 거리가 20 이내에 들어오고 빨간불이면 정지
    }

    void Interrupt()    // 끼어들기 함수
    {
        if (pos.x - pos_mycar.x >= 10.0f)
            Right();        // 오른쪽 차량과 거리가 10이상 벌어지면 끼어들기 시작
        if (pos.z <= -4.0f)
            Rspeed = 0;     // 2차선으로 이동 완료하면 Rspeed 0 으로 셋팅
    }

    void FastForward()
    {
        transform.Translate(Vector3.forward * fastspeed * Time.deltaTime);  // 급발진 속도 함수
    }

    void Right()
    {
        transform.Translate(Vector3.right * Rspeed * Time.deltaTime);       // 오른쪽 이동 함수
    }
}