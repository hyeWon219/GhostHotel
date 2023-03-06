using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureImageOn : MonoBehaviour
{
    public GameObject furnitureImg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FurnitureImageSetOn()
    {
        furnitureImg.SetActive(true);
    }

    public void FurnitureImageSetOff()
    {
        furnitureImg.SetActive(false);
    }
}
