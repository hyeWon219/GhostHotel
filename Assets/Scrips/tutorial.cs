using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Text text;
    public GameObject canvas;
    public GameObject tutorial_Guest;
    public GameObject shopImage;

    void Start()
    {
        text.text = "손님 클릭 3번";
    }

    void Update()
    {
        if (canvas.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            canvas.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Hotel Outside")
        {
            if (tutorial_Guest.activeSelf == false && text.text != "문 클릭")
            {
                canvas.SetActive(true);
                GameManager.Instance.GetComponent<CoinManager>().money += 30000;
                text.text = "문 클릭";
            }
        }

        else if (SceneManager.GetActiveScene().name == "Hotel Inside")
        {
            if (canvas.activeSelf == false && text.text == "문 클릭" && GameObject.Find("MapLock").transform.Find("Map_2F").gameObject.activeSelf == true)
            {
                GameManager.Instance.GetComponent<CoinManager>().money += 10000;
                canvas.SetActive(true);
                text.text = "상점 클릭";
            }
            // 복도 연동 이후
            else if (shopImage.activeSelf == true && text.text == "상점 클릭")
            {
                canvas.SetActive(true);
                text.text = "복도 구매";

            }
            else if (text.text == "복도 구매" && GameObject.Find("MapLock").transform.Find("Map_2F").gameObject.activeSelf == false)
            {
                canvas.SetActive(true);
                text.text = "문 클릭";
            }
        }

        else if (SceneManager.GetActiveScene().name == "Room_01")
        {
            if (canvas.activeSelf == false && text.text == "문 클릭")
            {
                canvas.SetActive(true);
                text.text = "먼지 제거";
            }
            // 상점 연동 -> 이후 가구 변경
            else if (canvas.activeSelf == false && text.text == "먼지 제거" && GameObject.Find("Roomee").transform.Find("table1").transform.Find("dust").gameObject.activeSelf == false 
                && GameObject.Find("Roomee").transform.Find("blanket1").transform.Find("dust").gameObject.activeSelf == false)
            {
                canvas.SetActive(true);
                GameManager.Instance.GetComponent<CoinManager>().money += 30000;
                text.text = "재화 보상 30000냥";
            }
        }
    }
}
