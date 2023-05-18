using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    public float speed; // 컨베이어 벨트의 속도

    void Start()
    {
        speed = 3f;
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 localPosition = transform.InverseTransformPoint(collision.gameObject.transform.position);
        if (localPosition.y > 0f)
        {
            // 충돌한 오브젝트가 윗면에 있는 경우에만 작동
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("HELLO");
                // 컨베이어 벨트의 전진 방향으로 힘을 가합니다.
                rb.velocity = transform.forward * speed;
            }
        }
    }
}