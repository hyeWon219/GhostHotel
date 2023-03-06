using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GhostFind : MonoBehaviour
{
    public GameObject box1, box2, market, point1, point2, mob;
    public Text text, mobCount ,score, gold;
    public GameObject startPannel, endPannel;
    int scoreInt;
    int goldInt;
    int heart;
    int count;
    bool check = false;
    void Start()
    {
        heart = 3;
        count = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInFormation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
            if (hitInFormation.collider != null)
            {
                GameObject touchObject = hitInFormation.transform.gameObject;
                if (touchObject.transform.tag == "Enemy")
                {
                    touchObject.SetActive(false);
                    count++;
                    goldInt += 100;
                    scoreInt += 500;
                }
            }
        }
        if (heart == 2)
        {
            GameObject.Find("Heart").transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (heart == 1)
        {
            GameObject.Find("Heart").transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (heart <= 0)
        {
            GameObject.Find("Heart").transform.GetChild(2).gameObject.SetActive(false);
            EndGame();
        }
        text.text = "잡은 악령 수 : " + count;
    }
    // 게임 시작
    IEnumerator GameStart(float min, float max, float dest)
    {
        count = 0;
        scoreInt = 0;
        goldInt = 0;
        check = false;
        text.gameObject.SetActive(true);
        do
        {
            StartCoroutine(SpawnGhost(dest));
            yield return new WaitForSecondsRealtime(Random.Range(min, max));

            if (heart <= 0)
            {
                break;
            }
        } while (true);
    }

    // 악령 스폰
    IEnumerator SpawnGhost(float dest)
    {
        GameObject ghost = GameObject.Find("Ghost").transform.GetChild(Random.Range(0, 12)).gameObject;
        if (ghost.activeSelf)
        {
            ghost = GameObject.Find("Ghost").transform.GetChild(Random.Range(0, 12)).gameObject;
        }
        else
        {
            ghost.SetActive(true);
            yield return new WaitForSecondsRealtime(dest);
            if (ghost.activeSelf == true)
            {
                ghost.SetActive(false);
                if (heart > 0)
                {
                    heart--;
                }
            }
        }
        if (heart <= 0)
        {
            for (int i = 0; i < 12; i++)
            {
                GameObject.Find("Ghost").transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    // 난이도 조정
    public void Easy()
    {
        StartCoroutine(GameStart(2f, 3f, 3));
        startPannel.SetActive(false);
    }
    public void Normal()
    {
        StartCoroutine(GameStart(1f, 2f, 2));
        startPannel.SetActive(false);
    }
    public void Hard()
    {
        StartCoroutine(GameStart(0f, 1f, 0.5f));
        startPannel.SetActive(false);
    }

    // 게임 종료
    void EndGame()
    {
        endPannel.SetActive(true);
        mobCount.text = "잡은 악령 수 : " + count;
        score.text = "획득한 점수 : " + scoreInt;
        gold.text = "획득한 재화 : " + goldInt;
        if (check == false)
        {
            GameManager.Instance.GetComponent<CoinManager>().money += goldInt;
            check = true;
        }
    }

    // 재시작
    public void Restart()
    {
        heart = 3;
        GameObject.Find("Heart").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Heart").transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Heart").transform.GetChild(2).gameObject.SetActive(true);
        endPannel.SetActive(false);
        startPannel.SetActive(true);
    }

    // 나가기
    public void Exit()
    {
        SceneManager.LoadScene("Hotel Outside");
    }
}
