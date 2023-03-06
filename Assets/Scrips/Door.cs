using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "Hotel Inside"
            && GameObject.Find("GameManager").transform.Find("MiniGameCanvas").transform.Find("Mini_Game").transform.Find("Mini_Game_Select").gameObject.activeSelf == false
            && GameObject.Find("Canvas").transform.Find("Shop Object").transform.Find("Shop_Image").gameObject.activeSelf == false)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInFormation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
            if (hitInFormation.collider != null)
            {
                GameObject touchObject = hitInFormation.transform.gameObject;
                if (touchObject.transform.tag == "Door")
                {
                    if (transform.root.gameObject.name == "F1_Door")
                    {
                        string roomName = touchObject.name;
                        SceneManager.LoadScene(roomName);
                    }
                    else if (transform.root.gameObject.name == "F2_Door")
                    {
                        if (GameObject.Find("MapLock").transform.Find("Map_2F").gameObject.activeSelf == false)
                        {
                            string roomName = touchObject.name;
                            SceneManager.LoadScene(roomName);
                        }
                    }
                    else if (transform.root.gameObject.name == "F3_Door")
                    {
                        if (GameObject.Find("MapLock").transform.Find("Map_3F").gameObject.activeSelf == false)
                        {
                            string roomName = touchObject.name;
                            SceneManager.LoadScene(roomName);
                        }
                    }
                    else if (transform.root.gameObject.name == "F4_Door")
                    {
                        if (GameObject.Find("MapLock").transform.Find("Map_4F").gameObject.activeSelf == false)
                        {
                            string roomName = touchObject.name;
                            SceneManager.LoadScene(roomName);
                        }
                    }
                    else if (transform.root.gameObject.name == "F5_Door")
                    {
                        if (GameObject.Find("MapLock").transform.Find("Map_5F").gameObject.activeSelf == false)
                        {
                            string roomName = touchObject.name;
                            SceneManager.LoadScene(roomName);
                        }
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "Hotel Outside" &&
            GameObject.Find("Canvas").transform.Find("Shop Object").transform.Find("Shop_Image").gameObject.activeSelf == false
            && GameObject.Find("GameManager").transform.Find("MiniGameCanvas").transform.Find("Mini_Game").transform.Find("Mini_Game_Select").gameObject.activeSelf == false)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInFormation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
            if (hitInFormation.collider != null)
            {
                GameObject touchObject = hitInFormation.transform.gameObject;
                if (touchObject.transform.tag == "Door")
                {
                    SceneManager.LoadScene("Hotel Inside");
                }
            }
        }
    }
}
