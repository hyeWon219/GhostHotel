using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLock : MonoBehaviour
{
    public GameObject purchaseButton;

    void Start()
    {
        
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
                if (touchObject.transform.tag == "MapLock")
                {
                    //purchaseButton.SetActive(true);
                }
            }
        }
    }
}
