using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPumpNozzle : MonoBehaviour
{
    private bool isMoving = true;

    public GameObject connectPrefab; // 생성할 Connect 프리팹
    public GameObject robot; // Robot 오브젝트
    public GameObject fuelCap; // fuelCap 오브젝트
    public GameObject mainObject; // Main 오브젝트

    private bool isMousePressed = false;
    private Vector3 initialPosition;
    private float moveSpeed; // 움직이는 속도
    private float distanceThreshold; // 내려갈 최대 거리
    private float spawnDistance; // 생성 위치 간격
    private float constant;

    private Transform connectionTransform; // Connection 오브젝트의 Transform
    private List<GameObject> spawnedPrefabs = new List<GameObject>(); // 생성된 프리팹들을 저장하는 리스트

    private void Start()
    {
        moveSpeed = 35.0f;
        distanceThreshold = 2.5f;
        spawnDistance = 0.07f;
        initialPosition = transform.position;
        connectionTransform = transform.parent.Find("Connect/Connection");
        Debug.Log(connectionTransform.position.y);

        constant = 0.5f;
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            if (Input.GetMouseButton(0))
            {
                isMousePressed = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isMousePressed = false;
                transform.position = initialPosition;

                // 생성된 프리팹들을 삭제
                foreach (var prefab in spawnedPrefabs)
                {
                    Destroy(prefab);
                }
                spawnedPrefabs.Clear();
            }

            if (isMousePressed)
            {
                float moveDistance = moveSpeed * Time.deltaTime;
                Vector3 newPosition = transform.position + Vector3.down * moveDistance;

                float distance = Vector3.Distance(initialPosition, newPosition);
                if (distance <= distanceThreshold)
                {
                    transform.position = newPosition;

                    if (connectionTransform != null)
                    {
                        float currentY = connectionTransform.position.y;

                        currentY -= 4 * spawnDistance + 0.0125f;

                        float spawnY = currentY - spawnDistance;

                        while (spawnY >= currentY - distance - constant)
                        {
                            SpawnConnectPrefab(spawnY);
                            spawnY -= spawnDistance;
                        }
                    }
                }
                else
                {
                    isMousePressed = false;
                }
            }
        }
    }

    

    private void SpawnConnectPrefab(float yPosition)
    {
        Vector3 spawnPosition = connectionTransform.position;
        spawnPosition.y = yPosition;

        GameObject spawnedPrefab = Instantiate(connectPrefab, spawnPosition, Quaternion.identity);
        spawnedPrefabs.Add(spawnedPrefab);
    }

}