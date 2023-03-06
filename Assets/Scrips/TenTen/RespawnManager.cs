using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> MobPool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 1;
    void Awake()
    {
        for (int i = 0; i < Mobs.Length; i++)
        {
            for (int q = 0; q < objCnt; q++)
            {
                MobPool.Add(CreateObj(Mobs[i], transform));
            }
        }
    }
    private void Start()
    {
        GameManager2.instance.onPlay += PlayGame;
    }
    void PlayGame(bool isplay)
    {
        if (isplay)
        {
            for (int i = 0; i < MobPool.Count; i++)
            {
                if (MobPool[i].activeSelf)
                    MobPool[i].SetActive(false);
            }
            StartCoroutine(CreateMob());
        }
        else
            StopAllCoroutines();
    }

    // 코루틴 Random.Range(최소, 최대); 최소 ~ 최대 사이의 임의의 수 반환
    IEnumerator CreateMob()
    {
        // 0.5초후 실행
        yield return new WaitForSeconds(0.5f);
        while (GameManager2.instance.isPlay)
        {
            MobPool[DeactiveMob()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    int DeactiveMob()
    {
        List<int> num = new List<int>();
        for (int i = 0; i < MobPool.Count; i++)
        {
            if (!MobPool[i].activeSelf)
                num.Add(i);
        }
        int x = 0;
        if (num.Count > 0)
        x = num[Random.Range(0, num.Count)];
        return x;
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }

    public GameObject GetBullet()
    {
        // 풀 순회
        for(int i = 0; i<MobPool.Count; i++)
        {
            // 해당 오브젝트가 활성화 되어 있지 않다면
            if(!MobPool[i].activeSelf)
            {
                // 해당 오브젝트를 활성화
                MobPool[i].SetActive(true);
                // 오브젝트를 반환
                return MobPool[i];
            }
        }
        // 활성화 되어 있어서 쏠  총알이 없다면 null
        return null;
    }
}