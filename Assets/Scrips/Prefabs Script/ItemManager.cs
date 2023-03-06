using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    //구매 한 아이템 배열 저장 스크립트
    public GameObject[] itemNumber = new GameObject[4];
    public GameObject[] furniture = new GameObject[4];
    public GameObject[] expand = new GameObject[4];

    private static ItemManager instance = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static ItemManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void SaveItem(GameObject obj)
    {
        for(int i = 0; i < 4; i++)
        {
            if (itemNumber[i] == null)
            {
                itemNumber[i] = obj;
                break;
            }
        }
    }
    
    public void SaveFurniture(GameObject obj)
    {
        for (int i = 0; i < 4; i++)
        {
            if (furniture[i] == null)
            {
                furniture[i] = obj;
                break;
            }
        }
    }

    public void SaveExpand(GameObject obj)
    {
        for (int i = 0; i < 4; i++)
        {
            if (expand[i] == null)
            {
                expand[i] = obj;
                break;
            }
        }
    }
}
