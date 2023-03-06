using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;

    public Text goldPerClickDisplayer;

    public DataController dataController;


    void Update()
    {
        // 총 골드량 + 냥
        goldDisplayer.text = dataController.GetGold() + "냥";
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + dataController.GetGoldPerClick();
    }
}