/*
 *  프로그램명 : 신호등 불빛을 조절하는 부모 클래스
 *  작성자 : 2016039006 문재식 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.11.27
 *  프로그램 설명 : 신호등의 불빛을 조절한다
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    protected float dist;   // 자동차와 신호등 사이의 거리
    public GameObject TargetCar;    // 타겟 자동차
    public Light RedLight;   // 신호등 불빛마다 변수 선언
    public Light YellowLight;
    public Light GreenLight;

    public void Red()  // 빨간불
    {
        RedLight.enabled = true;
        YellowLight.enabled = false;
        GreenLight.enabled = false;
    }

    public void Yellow() // 노란불
    {
        RedLight.enabled = false;
        YellowLight.enabled = true;
        GreenLight.enabled = false;
    }

    public void Green() // 초록불
    {
        RedLight.enabled = false;
        YellowLight.enabled = false;
        GreenLight.enabled = true;
    }
}