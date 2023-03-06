using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController instance;

    public static DataController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataController>();

            if(instance == null)
            {
                GameObject container = new GameObject("DataController");

                instance = container.AddComponent<DataController>();
            }
        }

        return instance;
    }


    private int m_gold = 0;

    private int m_goldPerClick = 0;


    void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold");
        // 기본 지정 값
        m_goldPerClick = PlayerPrefs.GetInt("GoldperClick",1);
    }
    // 로컬 골드 세이브 
    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }
    
    // 골드 +
    public void AddGold(int newGold)
    {
        // m_gold = m_gold + newGold 같은 의미
        m_gold += newGold;
        // PlayerPrefs.SetInt("Gold", m_gold); 로 저장
        SetGold(m_gold);
    }

    // 골드 -
    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    // 골드 가져오기
    public int GetGold()
    {
        return m_gold;
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }


    public void SetGoldPerClick(int newGoldperClick)
    {
        m_goldPerClick = newGoldperClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

}