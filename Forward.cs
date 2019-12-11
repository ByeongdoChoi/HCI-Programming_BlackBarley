/*
 * 프로그램명 : Car Control
 * 작성자 : 2016039002 박성진 (최병도, 김종우, 박성진, 김서빈, 문재식)
 * 작성일 : 2019.11.22
 * 프로그램 설명 : 차량의 액셀과 브레이크, 바퀴의 좌회전, 우회전 구현
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Forward : MonoBehaviour
{
    public WheelCollider FR; // 오른쪽 앞바퀴
    public WheelCollider FL; // 왼쪽 앞바퀴
    public WheelCollider RR; // 오른쪽 뒷바퀴
    public WheelCollider RL; // 왼쪽 뒷바퀴

    public GameObject left;
    public GameObject right;
    public GameObject steerwheel;

    private Animation anim1;
    private Animation anim2;
    private Animation anim3;


    public float MaxTorque; // 최대 토크
    public float Angle; // 자동차 바퀴 각도


    void Start() // 초기화
    {
        MaxTorque = 0f; // 최대 토크 = 0
        Angle = 0f; // 바퀴 각도 = 0도
        anim1 = steerwheel.GetComponent<Animation>();
        anim2 = left.GetComponent<Animation>();
        anim3 = right.GetComponent<Animation>();

    }


    public void Front() // 액셀
    {
        RR.brakeTorque = 0; // 오른쪽 뒷바퀴 브레이크 값 0으로 초기화
        RL.brakeTorque = 0; // 왼쪽 뒷바퀴 브레이크 값 0으로 초기화

        RR.motorTorque += 400; // 오른쪽 뒷바퀴 토크 70씩 증가
        RL.motorTorque += 400; // 왼쪽 뒷바퀴 토크 70씩 증가

        if (RR.motorTorque >= 1000) // 최대 토크 값을 250으로 설정
        {
            RR.motorTorque = 1000;
            RL.motorTorque = 1000;
        }
    }

    public void Stop() // 브레이크
    {
        // 오른쪽, 왼쪽 뒷바퀴의 토크를 0으로 설정
        RR.motorTorque = 0; 
        RL.motorTorque = 0;

        RR.brakeTorque += 250; // 브레이크 토크 값 250씩 증가
        RL.brakeTorque += 250;
    }

    public void Left() // 앞바퀴 방향 왼쪽으로 회전
    {
        FL.steerAngle -= 3; // 왼쪽으로 3도 회전
        FR.steerAngle -= 3;

        if (FL.steerAngle <= -45) // 최대 왼쪽 회전각도를 45도로 설정
        {
            FL.steerAngle = -45;
            FR.steerAngle = -45;
        }
        left.GetComponent<Animation>().Play("Left");
        right.GetComponent<Animation>().Play("Right");
        steerwheel.GetComponent<Animation>().Play("SteerWheel");
    }

    public void Right() // 앞바퀴 방향 오른쪽으로 회전
    {
        FL.steerAngle += 3; // 오른쪽으로 3도 회전
        FR.steerAngle += 3;

        if (FL.steerAngle >= 45) // 최대 오른쪽 회전각도를 45도로 설정
        {
            FL.steerAngle = 45;
            FR.steerAngle = 45;
        }

        anim1.Play("SteerWheel2");
        anim2.Play("Left2");
        anim3.Play("Right2");

    }
}
