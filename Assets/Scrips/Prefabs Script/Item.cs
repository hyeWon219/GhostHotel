using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //아이템 가격이랑 아이템 번호 넘겨주는 스크립트
    public int price;
    public int number;

    public int returnPrice()
    {
        return price;
    }

    public int returnNum()
    {
        return number;
    }
}
