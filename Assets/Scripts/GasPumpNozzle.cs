using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPumpNozzle : MonoBehaviour
{
    public float maxDistance; // 오브젝트가 내려갈 수 있는 최대 거리
    public float speed; // 오브젝트 이동 속도

    public float prefabSpawnInterval; // 프리팹 생성 간격
    public Transform prefabTransform;
    public GameObject prefabToSpawn; // 생성할 프리팹
    public float nowY;

    private Vector3 startPosition; // 오브젝트의 초기 위치
    private bool isMouse = false; // 마우스 버튼이 눌리는지 여부
    private List<GameObject> spawnedPrefabs = new List<GameObject>(); // 생성한 프리팹들을 추적하기 위한 리스트

    private void Start()
    {
        startPosition = transform.position;
        prefabTransform = transform.Find("Connect/Connection").transform;
        Debug.Log(prefabTransform);
        maxDistance = 0.7f;
        speed = 10f;
        prefabSpawnInterval = 0.07f;
        nowY = prefabTransform.position.y; 
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isMouse = true;
            StartCoroutine(MoveObjectDown());
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouse = false;
            StartCoroutine(MoveObjectUp());
        }
    }

    private IEnumerator MoveObjectDown()
    {
        nowY = prefabTransform.position.y;
        while (isMouse)
        {
            Vector3 targetPosition = startPosition - new Vector3(0f, maxDistance, 0f);

            while (transform.position.y > targetPosition.y)
            {
                if (transform.position.y <= nowY)
                {
                    nowY -= prefabSpawnInterval;
                    Vector3 newPos = prefabTransform.position;
                    newPos.y = nowY;
                    prefabTransform.position = newPos;
                    SpawnPrefab(prefabTransform);
                }

                Vector3 newPosition = transform.position;
                newPosition.y -= speed * Time.deltaTime;
                transform.position = newPosition;

                yield return null;
            }

            yield return null;
        }
    }

    private IEnumerator MoveObjectUp()
    {
        Vector3 targetPosition = startPosition;
        float upSpeed = speed * 2f;

        while (transform.position.y < targetPosition.y)
        {
            Vector3 newPosition = transform.position;
            newPosition.y += upSpeed * Time.deltaTime;
            transform.position = newPosition;

            yield return null;
        }
    }

    private void SpawnPrefab(Transform transform)
    {
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        spawnedPrefabs.Add(spawnedPrefab);
    }
}
