/*
 * 프로그램명 : 카메라 흔들림 구현
 * 작성자 : 2016039033 최병도 (김종우, 박성진, 김서빈, 문재식)
 * 작성일 : 2019.12.05
 * 프로그램 설명 : 카메라의 위치를 랜덤적으로 조절하여 카메라를 흔드는 프로그램
 */
using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{


    public float shakeAmount;//카메라가 흔들리는 양

 
    float shakePercentage;//A percentage (0-1) representing the amount of shake to be applied when setting rotation.
    float startAmount;//초기 카메라 흔들림 변수

    bool isRunning = false; //Is the coroutine running right now?

    public bool smooth;//카메라를 부드럽게 해주는 변수
    public float smoothAmount = 5f;//카메라 부드러운 크기

    void Start()
    {

        if (debugMode) ShakeCamera();
    }


    void ShakeCamera()
    {

        startAmount = shakeAmount;//카메라 흔들림 양을 받는
    }

    public void ShakeCamera(float amount, float duration)
    {

        shakeAmount += amount; //카메라 흔들림의 현재 크기를 유지한다.
        startAmount = shakeAmount;//카메라 흔들림 크기를 유지한다.
        if (!isRunning) StartCoroutine(Shake());
    }


    IEnumerator Shake()
    {
        isRunning = true;

        while (true)
        {
            Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount;//카메라의 위치를 랜덤적으로 움직이는 변수
            rotationAmount.z = 0;//z값이 변하는 정도

            //부드러움 정도를 체크한다.
            if (smooth)
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothAmount);
            else
                transform.localRotation = Quaternion.Euler(rotationAmount);//Set the local rotation the be the rotation amount.

            yield return null;
        }
        transform.localRotation = Quaternion.identity;//Set the local rotation to 0 when done, just to get rid of any fudging stuff.
        isRunning = false;
    }

}
