using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    #region instance
    public static GameManager2 instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;
    
    int scoreInt;
    int goldInt;

    public float gameSpeed = 1;
    public bool isPlay = false;
    public GameObject playBtn;
    public GameObject startPannel, endPannel;

    public Text bestScoreTxt;
    public Text scoreTxt;
    public Text goldTxt;
    // 점수 
    public int Score = 0;

    private void Start()
    {
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    IEnumerator AddScore()
    {
        // 게임이 실행 되면 1초마다 점수증가
        while (isPlay)
        {
            Score++;
            scoreTxt.text = Score.ToString();
            // 시간이 지날수록 게임 스피드 증가
            gameSpeed = gameSpeed + 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void PlayBtnClick()
    {
        startPannel.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        Score = 0;
        scoreTxt.text = Score.ToString();
        StartCoroutine(AddScore());
        endPannel.SetActive(false);
    }

    public void GameOver()
    {
        endPannel.SetActive(true);
        isPlay = false;
        onPlay.Invoke(isPlay);
        StopCoroutine(AddScore());

        // gold.text = "획득한 재화 : " + goldInt;
        // GameManager.Instance.GetComponent<CoinManager>().money += goldInt;

        // 최고점수 및 표출 및 점수 저장
        if (PlayerPrefs.GetInt("BestScore",0) < Score)
        {
            PlayerPrefs.SetInt("BestScore", Score);
            bestScoreTxt.text = Score.ToString();
        }
    }
}



