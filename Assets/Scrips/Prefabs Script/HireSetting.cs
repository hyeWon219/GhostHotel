using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HireSetting : MonoBehaviour
{
    //고용인 맵에 나타내는 스크립트

    GameObject itemManager;

    public GameObject[] checkItem = new GameObject[4];
    public GameObject[] realHire = new GameObject[4];

    void Start()
    {
        itemManager = GameObject.Find("ItemManager");

        for (int i = 0; i < 4; i++)
        {
            realHire[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SceneChecking();
    }

    public void HireOn()
    {
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if (checkItem[i] == itemManager.GetComponent<ItemManager>().itemNumber[j])
                {
                    realHire[i].SetActive(true);
                    //realHire[i].tag = "Hired";
                    break;
                }
            }
        }
    }

    public void SceneChecking()
    {
        if (SceneManager.GetActiveScene().name != "Hotel Outside")
        {
            for (int i = 0; i < 4; i++)
            {
                realHire[i].SetActive(false);
            }
        }
        else
        {
            HireOn();
        }
    }
}
