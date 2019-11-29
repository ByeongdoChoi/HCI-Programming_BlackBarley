/* 
 * 시나리오 #1
 * 자동차와 ai 사람 거리 계산
 * ai 사람 움직임 구현
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Move : MonoBehaviour
{
    public GameObject cloud;
    public GameObject car;
    public GameObject human;
    float dt;

    public float cloud_z = 0;
    public float speed = 10.0f;
    
    void Start()
    {
        cloud = GameObject.Find("human1");
    }

    void Update()
    {
        dt = Vector3.Distance(car.transform.position, human.transform.position);

        if (dt <= 30)
        {
            cloud_z = (cloud.GetComponent<Transform>().position.z);

            if (cloud_z >= 100)
                cloud.GetComponent<Transform>().position = new Vector3(-1000, -1000, -1000);
            else
                cloud.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}