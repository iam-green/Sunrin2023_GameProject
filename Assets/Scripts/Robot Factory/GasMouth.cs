using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMouth : MonoBehaviour
{
    private bool isColliding = false;

    private void FixedUpdate()
    {
        // 충돌 감지 로직
        if (isColliding)
        {
            // 충돌 처리 코드
            Debug.Log("Collision Detected!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌이 발생하면 isColliding을 true로 설정
        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // 충돌이 종료되면 isColliding을 false로 설정
        isColliding = false;
    }
}
