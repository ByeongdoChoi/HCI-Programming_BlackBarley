using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public WheelCollider FR;
    public WheelCollider FL;
    public WheelCollider RR;
    public WheelCollider RL;

    public float MaxTorque;
    public float Angle;

    void Start()
    {
        MaxTorque = 0f;
        Angle = 0f;
    }

    public void Front()
    {
        RR.motorTorque += 50;
        RL.motorTorque += 50;

        RR.brakeTorque = 0;
        RL.brakeTorque = 0;

        if (RR.motorTorque >= 250)
        {
            RR.motorTorque = 250;
            RL.motorTorque = 250;
        }
            
    }
    public void Stop()
    {
        RR.motorTorque = 0;
        RL.motorTorque = 0;

        //RR.motorTorque -= 80;
        //RL.motorTorque -= 80;
        //if(RR.motorTorque <= 0)
        //{
        //    RR.motorTorque = 0;
        //    RL.motorTorque = 0;
        //}

        RR.brakeTorque += 200;
        RL.brakeTorque += 200;


    }

    public void Left()
    {

        FL.steerAngle -= 5;
        FR.steerAngle -= 5;


        if (FL.steerAngle <= -45)
        {
            FL.steerAngle = -45;
            FR.steerAngle = -45;

        }
    }

    public void Right()
    {

        FL.steerAngle += 5;
        FR.steerAngle += 5;
        if (FL.steerAngle >= 45)
        {
            FL.steerAngle = 45;
            FR.steerAngle = 45;
        }

    }
}
