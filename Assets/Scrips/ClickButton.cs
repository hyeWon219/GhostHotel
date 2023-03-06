using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    // datacontroller 래퍼런스 가져오기
    public DataController dataController;

    public void OnClick()
    {
        //gold = gold + goldPerClick;
        int goldPerClick = dataController.GetGoldPerClick();
        dataController.AddGold(goldPerClick);
    }
}
