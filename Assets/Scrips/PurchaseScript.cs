using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseScript : MonoBehaviour
{
    //아이템 구매하는 스크립트
    public GameObject[] hirePanel = new GameObject[4];
    public GameObject[] expandPanel = new GameObject[4];
    public GameObject[] purchasePanel = new GameObject[4];

    //public GameObject[] purchaseItem = new GameObject[15];

    public GameObject panelSetting;
    public GameObject purchaseButton;
    public GameObject panelText;

    public GameObject item;

    Coin coinScript;
    Coin money;
    GameObject coinManagerScript;
    GameObject itemManager;
    CoinManager coinManager;


    // Start is called before the first frame update
    void Start()
    {
        coinScript = GameObject.Find("Money").GetComponent<Coin>();
        coinManagerScript = GameObject.Find("GameManager");
        itemManager = GameObject.Find("ItemManager");
        coinManager = GameObject.Find("GameManager").GetComponent<CoinManager>();
        hirePanelOff();
        expandPanelOff();
        purchasePanelOff();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void hirePanelOff()
    {
        for(int i = 0; i <4; i++)
        {
            if (hirePanel[i].tag != "Sell")
                hirePanel[i].SetActive(false);
        }
    }

    public void expandPanelOff()
    {
        for (int i = 0; i < 4; i++)
        {
            if (expandPanel[i].tag != "Sell")
                expandPanel[i].SetActive(false);
        }
    }

    public void purchasePanelOff()
    {
        for (int i = 0; i < 4; i++)
        {
            if (purchasePanel[i].tag != "Sell")
                purchasePanel[i].SetActive(false);
        }
    }

    public void PanelOn()
    {
        panelSetting.SetActive(true);
    }

    public void HPurchase()
    {
        //도깨비 고용
        if (coinManagerScript.GetComponent<CoinManager>().money >= item.GetComponent<Item>().returnPrice())
        {
            coinScript.DownMoney(item.GetComponent<Item>().returnPrice());
            
            Destroy(purchaseButton);

            panelText.SetActive(true);

            hirePanel[item.GetComponent<Item>().returnNum()].SetActive(true);
            hirePanel[item.GetComponent<Item>().returnNum()].tag = "Sell";

            //고용인 기능 추가(시간 당 돈 더 많이 얻게 함)
            for(int i = 0; i < 4; i++)
            {
                coinManager.buffMoney = 300 + coinManager.buffMoney;

                if (coinManager.buffMoney > 3000)
                    break;

                if (coinManager.buffMoney == 0)
                    coinManager.buffMoney = 3000;
            }

            itemManager.GetComponent<ItemManager>().SaveItem(item);
        }
    }

    public void EPurchase()
    {
        //층 확장
        if (coinManagerScript.GetComponent<CoinManager>().money >= item.GetComponent<Item>().returnPrice())
        {
            coinScript.DownMoney(item.GetComponent<Item>().returnPrice());
            
            Destroy(purchaseButton);

            panelText.SetActive(true);

            expandPanel[item.GetComponent<Item>().returnNum()].SetActive(true);
            expandPanel[item.GetComponent<Item>().returnNum()].tag = "Sell";

            itemManager.GetComponent<ItemManager>().SaveExpand(item);
        }
    }

    public void PPurchase()
    {
        //가구 구매
        if (coinManagerScript.GetComponent<CoinManager>().money >= item.GetComponent<Item>().returnPrice())
        {
            coinScript.DownMoney(item.GetComponent<Item>().returnPrice());
           
            Destroy(purchaseButton);

            panelText.SetActive(true);

            purchasePanel[item.GetComponent<Item>().returnNum()].SetActive(true);
            purchasePanel[item.GetComponent<Item>().returnNum()].tag = "Sell";

            itemManager.GetComponent<ItemManager>().SaveFurniture(item);
        }
    }
}
