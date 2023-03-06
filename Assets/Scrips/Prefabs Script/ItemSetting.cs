using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemSetting : MonoBehaviour
{
    //가구 변경해주는 스크립트

    public GameObject[] realFurniture = new GameObject[4];
    public GameObject[] furniturePanel = new GameObject[4];
    public GameObject[] furnitureImageSet = new GameObject[4];

    public Sprite img;
    
    public GameObject itemManager;

    // Start is called before the first frame update
    void Start()
    {
        itemManager = GameObject.Find("ItemManager");
        FurnitureOff();
    }

    // Update is called once per frame
    void Update()
    {
        FurnitureOn();
    }

    public void FurnitureOff()
    {
        for (int i = 0; i < 4; i++)
        {
            if (furniturePanel[i].tag == "Furniture")
            {
                furniturePanel[i].SetActive(false);
            }
        }

        for(int j = 0; j <4; j++)
        {
            furnitureImageSet[j].SetActive(false);
        }
    }

    public void FurnitureOn()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if(realFurniture[i]== itemManager.GetComponent<ItemManager>().furniture[j])
                {
                    furniturePanel[i].SetActive(true);
                    furnitureImageSet[i].SetActive(true);
                }
            }
        }
    }

    public void ChangeTable(Sprite img)
    {
        GameObject.Find("table1").GetComponent<SpriteRenderer>().sprite = img;
    }

    public void ChangeBlanket(Sprite img)
    {
        GameObject.Find("blanket1").GetComponent<SpriteRenderer>().sprite = img;
    }

}
