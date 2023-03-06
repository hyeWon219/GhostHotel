using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text scoreText;

    public Text txt;

    bool activated;

    float timeElapsed = 0;

    CoinManager coinManger;

    // Start is called before the first frame update
    void Start()
    {
        coinManger = GameObject.Find("GameManager").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activated)
        {
            timeElapsed += UnityEngine.Time.deltaTime;

            txt.text = timeElapsed.ToString("0");
        }
    
    }
    public void StartWatch()
    {
        activated = !activated;
    }

    public void AddMoney()
    {
        coinManger.money += 100;
    }
    public void DownMoney(int i)
    {
        coinManger.money -= i;
    }
}
