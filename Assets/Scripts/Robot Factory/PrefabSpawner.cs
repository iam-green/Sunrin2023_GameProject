using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // 생성할 프리팹
    public Vector3 spawnPosition; // 생성 위치
    public float spawnInterval = 3f; // 생성 간격

    private void Start()
    {
        // 3초마다 SpawnPrefab() 메서드를 호출하는 코루틴 시작
        StartCoroutine(SpawnPrefabCoroutine());
        spawnPosition = new Vector3(0f, 15f, 0f);
    }

    private IEnumerator SpawnPrefabCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // 지정된 위치에 프리팹 생성
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}