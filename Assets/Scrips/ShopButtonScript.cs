using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonScript : MonoBehaviour
{
    //상점 버튼 및 고용, 구매, 확장 기능 여는 스크립트
    public GameObject hireScorllView;
    public GameObject expandScrollView;
    public GameObject purchaseScrollView;

    public GameObject purchaseScript;

    GameObject gameManager;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        PushHireButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        gameManager.GetComponent<GameManager>().PushButton_shop();
        button.SetActive(false);
    }

    public void CloseShop()
    {
        gameManager.GetComponent<GameManager>().PushButton_exit();
        button.SetActive(true);
    }

    public void PushHireButton()
    {
        hireScorllView.SetActive(true);
        expandScrollView.SetActive(false);
        purchaseScrollView.SetActive(false);

        purchaseScript.GetComponent<PurchaseScript>().expandPanelOff();
        purchaseScript.GetComponent<PurchaseScript>().purchasePanelOff();
    }

    public void PushExpandButton()
    {
        expandScrollView.SetActive(true);
        hireScorllView.SetActive(false);
        purchaseScrollView.SetActive(false);

        purchaseScript.GetComponent<PurchaseScript>().purchasePanelOff();
        purchaseScript.GetComponent<PurchaseScript>().hirePanelOff();
    }

    public void PushPurchaseButton()
    {
        purchaseScrollView.SetActive(true);
        hireScorllView.SetActive(false);
        expandScrollView.SetActive(false);

        purchaseScript.GetComponent<PurchaseScript>().hirePanelOff();
        purchaseScript.GetComponent<PurchaseScript>().expandPanelOff();
    }
}
