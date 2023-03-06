using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Roomopen : MonoBehaviour
{
    void Update()
    {
        
    }

    public void GoHotelRoom()
    {
        SceneManager.LoadScene("Hotel Room");
    }
    public void GoInside()
    {
        SceneManager.LoadScene("Hotel Inside");
    }
}
