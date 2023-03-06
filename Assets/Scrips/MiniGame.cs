using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGame : MonoBehaviour
{
    public GameObject miniGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MiniGameButton()
    {
        miniGame.SetActive(true);
    }

    public void MiniGameExit()
    {
        miniGame.SetActive(false);
    }

    public void GhostRun()
    {
        miniGame.SetActive(false);
        SceneManager.LoadScene("TenTen");
    }

    public void GhostHunter()
    {
        miniGame.SetActive(false);
        SceneManager.LoadScene("GhostHunter");
    }
}
