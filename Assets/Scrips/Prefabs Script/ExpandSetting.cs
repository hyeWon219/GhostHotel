using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpandSetting : MonoBehaviour
{
    GameObject itemManager;

    public GameObject[] checkExpand = new GameObject[4];
    public GameObject[] realExpand = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        itemManager = GameObject.Find("ItemManager");
    }

    // Update is called once per frame
    void Update()
    {
        ExpandOn();
        //SceneChecking();
    }

    public void ExpandOn()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (checkExpand[i] == itemManager.GetComponent<ItemManager>().expand[j])
                {
                    realExpand[i].SetActive(false);
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
                realExpand[i].SetActive(false);
            }
        }
        else
        {
            ExpandOn();
        }
    }
}
