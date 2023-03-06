using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLobby : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickNewGame()
    {
        {
            SceneManager.LoadScene("Hotel Outside");
        }
        Debug.Log("새 게임");
    }

    public void onClickLoad()
    {
        Debug.Log("불러오기");
    }

    public void onClickOption()
    {
        Debug.Log("옵션");
    }
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
