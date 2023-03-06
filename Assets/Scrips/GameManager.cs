using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopImage;
    public GameObject shopButton;
    public GameObject miniGameButton;
    public GameObject miniGameCanvas;
    private static GameManager instance = null;

    List<string> room = new List<string>();
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Start()
    {
        shopImage.SetActive(false);
        AddRoom();
    }
    public void PushButton_shop()
    {
        shopImage.SetActive(true);
    }
    public void PushButton_exit()
    {
        shopImage.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TenTen" || SceneManager.GetActiveScene().name == "GhostHunter" || Room() || shopImage.activeSelf)
        {
            if (SceneManager.GetActiveScene().name == "TenTen" || SceneManager.GetActiveScene().name == "GhostHunter" || shopImage.activeSelf)
            {
                miniGameButton.SetActive(false);
                shopButton.SetActive(false);
            }
            else if (Room())
            {
                miniGameButton.SetActive(false);
            }
        }
        else
        {
            shopButton.SetActive(true);
            miniGameButton.SetActive(true);
        }
    }



    public void CleanDust()
    {
        GetComponent<CoinManager>().money += 500;
    }

    public void AddRoom()
    {
        room.Add("Room_01");
        room.Add("Room_02");
        room.Add("Room_03");
        room.Add("Room_04");
        room.Add("Room_05");
        room.Add("Room_06");
        room.Add("Room_07");
        room.Add("Room_08");
        room.Add("Room_09");
        room.Add("Room_10");
        room.Add("Room_11");
        room.Add("Room_12");
        room.Add("Room_13");
        room.Add("Room_14");
        room.Add("Room_15");
    }
    
    public bool Room()
    {
        for (int i = 0; i < room.Count; i++)
        {
            if (SceneManager.GetActiveScene().name == room[i])
            {
                return true;
            }
        }
        return false;
    }
}
