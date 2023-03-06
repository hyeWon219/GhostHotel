using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnManager : MonoBehaviour
{
    // 생성 개수 제한
    public int maxCount;
    public int enemyCount;

    // 몬스터 생성 주기 간격
    public float spwanTime = 3f;
    public float curTime;
    public Transform[] spawnPoints;

    // 같은자리 중복 생성 제한
    public bool[] isSpawn;
    public GameObject enemy;

    private void Start()
    {
        isSpawn = new bool[spawnPoints.Length];
        for (int i = 0; i < isSpawn.Length; i++)
        {
            isSpawn[i] = false;
        }
    }

    private void Update()
    {
        if(curTime >= spwanTime && enemyCount < maxCount)
        {
            int x = Random.Range(0,spawnPoints.Length);
            SpawnEnemy(x);
        }
        curTime += Time.deltaTime;

    }

    public void SpawnEnemy(int ranNum)
    {
        curTime = 0;
        enemyCount++;
        Instantiate(enemy, spawnPoints[ranNum]);
    }
}