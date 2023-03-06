using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int money;
    public int buffMoney = 1000;
    public Text moneyText;

    private void Awake()
    {
        money = 0; 
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinUp());
 
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }

    IEnumerator CoinUp()
    {
        do {
            money += buffMoney;
            yield return new WaitForSecondsRealtime(3f);
        } while (true);
    }
}
