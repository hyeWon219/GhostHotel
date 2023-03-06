using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public string upgradeName;

    [HideInInspector]

    // 한번 업그레이드 할때마다 goldperclick 증가량 지정
    public int goldByUpgrade;
    // 게임 처음 시작시 기초 값
    public int startGoldByUpgrade;

    [HideInInspector]

    // 아이템 구매시 가격
    public int currentCost = 1;
    public int startCurrentCost = 1;

    [HideInInspector]

    public int level = 1;

    // 업그레이드 시 가격 증가 (도깨비)
    public float upgradePow = 3.14f;

    void Start()
    {
        currentCost = startCurrentCost;
        level = 1;
        goldByUpgrade = startGoldByUpgrade;
    }

    // 도깨비 업그레이드 시 레벨 증가 및 사용되는 재화 증가
    public void purchaseUpgrade ()
    {
        // public DatController dataController; 대체
        //                                     돈이 충분하면 
        if(DataController.GetInstance().GetGold()  >= currentCost)
        {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);
        }
    }
}
