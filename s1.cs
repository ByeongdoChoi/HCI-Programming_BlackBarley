/*
 *  자동차와 신호등의 거리를 계산하여
 *  신호등 불빛 구현
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Traffic : MonoBehaviour
{
    private float dt;
    public GameObject car;
    [SerializeField] private Light RedLight1;
    [SerializeField] private Light YellowLight1;
    [SerializeField] private Light GreenLight1;


    void Start()    //시작시 빨간불
    {
        Red();
    }

    void Update()
    {

        dt = Vector3.Distance(car.transform.position, this.transform.position); //자동차, 신호등 거리

        if (dt <= 60)   //거리가 60이하일때 초록불
        {
            Green();
        }

    }


    void Red()  // 빨간불
    {
        RedLight1.GetComponent<Light>().enabled = true;
        YellowLight1.GetComponent<Light>().enabled = false;
        GreenLight1.GetComponent<Light>().enabled = false;
    }

    void Yellow() // 노란불
    {
        RedLight1.GetComponent<Light>().enabled = false;
        YellowLight1.GetComponent<Light>().enabled = false;
        GreenLight1.GetComponent<Light>().enabled = false;
    }

    void Green() // 초록불
    {
        RedLight1.GetComponent<Light>().enabled = false;
        YellowLight1.GetComponent<Light>().enabled = false;
        GreenLight1.GetComponent<Light>().enabled = true;
    }
}