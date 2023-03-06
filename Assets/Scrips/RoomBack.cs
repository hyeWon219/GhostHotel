using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomBack : MonoBehaviour
{
    public void BackToInside()
    {
        SceneManager.LoadScene("Hotel Inside");
    }

    public void BackToOutSide()
    {
        SceneManager.LoadScene("Hotel Outside");
    }
}