/*
 *  ��ȣ��� �����ڵ���, AI �ڵ����� �Ÿ��� ����Ͽ� 
 *  AI �ڵ��� ������ ����
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
        dt1 = Vector3.Distance(Maincar.transform.position, car.transform.position);  //���� �ڵ����� ai�ڵ����� �Ÿ�
        dt = Vector3.Distance(car.transform.position, obj.transform.position);  //ai �ڵ����� ��ȣ���� �Ÿ�

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