/*
 *  프로그램명 : 움직이는 AI 객체 부모 클래스
 *  작성자 : 2016039006 문재식 (최병도, 김종우, 박성진, 문재식, 김서빈)
 *  작성일 : 2019.11.27
 *  프로그램 설명 : 앞으로 이동하는 기본 클래스
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed;   // 자동차 속도
    public GameObject TargetTraffic; // 신호등

    public void Forward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}