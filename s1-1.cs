/*
 *  신호등과 메인자동차, AI 자동차의 거리를 계산하여 
 *  AI 자동차 움직임 구현
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AI1 : MonoBehaviour
{
    private float dt;
    public GameObject Maincar;
    public GameObject car;
    public GameObject cloud;
    public GameObject obj;
    float dt1;

    public float cloud_z = 0;
    public float speed = 20.0f;

    void Start()
    {
        cloud = GameObject.Find("AI_car1");
    }

    void Update()
    {
        dt1 = Vector3.Distance(Maincar.transform.position, car.transform.position);  //메인 자동차와 ai자동차의 거리
        dt = Vector3.Distance(car.transform.position, obj.transform.position);  //ai 자동차와 신호등의 거리

        cloud_z = (cloud.GetComponent<Transform>().position.z);

        cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);

        if (dt <= 10)
        {
            speed = 0.0f;

            if(dt1 <=30)
            {
                speed = 20.0f;
                cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}