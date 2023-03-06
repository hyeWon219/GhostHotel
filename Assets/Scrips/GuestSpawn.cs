using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuestSpawn : MonoBehaviour
{
    public GameObject guest_1;
    public GameObject guest_2;
    public GameObject guest_3;
    public GameObject guest_4;
    public GameObject guest_5;
    public GameObject spawner_1;
    public GameObject spawner_2;

    int num;

    // Start is called before the first frame update
    void Start()
    {
    }

    public Vector3 randomSpawn_Outside()
    {
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            return spawner_1.transform.position + new Vector3(0, Random.Range(-1f, 1f), 0);
        }
        else
        {
            return spawner_2.transform.position + new Vector3(0, Random.Range(-1f, 1f), 0);
        }
    }

    public Vector3 randomSpawn_Inside()
    {
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            return spawner_1.transform.position + new Vector3(0, Random.Range(-0.5f, 0.5f), 0);
        }
        else
        {
            return spawner_2.transform.position + new Vector3(0, Random.Range(-0.5f, 0.5f), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Hotel Outside" && GameObject.Find("Spawner").transform.childCount < 10)
        {
            num = Random.Range(0, 5);
            if (num == 1)
            {
                GameObject _obj = Instantiate(guest_1, randomSpawn_Outside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
            else if (num == 2)
            {
                GameObject _obj = Instantiate(guest_2, randomSpawn_Outside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
            else if (num == 3)
            {
                GameObject _obj = Instantiate(guest_3, randomSpawn_Outside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
            else if (num == 4)
            {
                GameObject _obj = Instantiate(guest_4, randomSpawn_Outside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
            else
            {
                GameObject _obj = Instantiate(guest_5, randomSpawn_Outside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Hotel Inside" && GameObject.Find("Spawner").transform.childCount < 10)
        {
            num = Random.Range(0, 3);
            if (num == 1)
            {
                GameObject _obj = Instantiate(guest_1, randomSpawn_Inside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
            else if (num == 2)
            {
                GameObject _obj = Instantiate(guest_2, randomSpawn_Inside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
            else if (num == 3)
            {
                GameObject _obj = Instantiate(guest_3, randomSpawn_Inside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
            else if (num == 4)
            {
                GameObject _obj = Instantiate(guest_4, randomSpawn_Inside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
            else
            {
                GameObject _obj = Instantiate(guest_5, randomSpawn_Inside(), Quaternion.identity);
                _obj.transform.parent = GameObject.Find("Spawner").transform;
            }
        }
    }

}
