/*
 *  프로그램명 : 거리 계산에 따른 AI 오브젝트 신호등 구현 (시나리오 #3, 4)
 *  작성자 : 2016039006 문재식 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.11.27
 *  프로그램 설명 : 거리 계산을 통해 신호등 불빛 변경
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_11 : TrafficLight    // TrafficLight클래스 상속
{
    void Start()
    {
        Green();    // 기본은 녹색불
    }

    void Update()
    {
        dist = Vector3.Distance(TargetCar.transform.position, this.transform.position); // 자동차와 신호등 거리

        if (dist <= 40 && TargetCar.transform.position.x <= 170) // 거리 20 이내면
        {
            Red();      // 빨간불 점등
            Invoke("Green", 10); // 5초후 초록불 점등
        }

        else if (dist <= 80 && TargetCar.transform.position.x <= -170) // 자동차가 거리 50 이내로 들어오면
            Yellow();   // 노란불 점등


    }
}
