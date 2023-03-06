using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMapLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInFormation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
            if (hitInFormation.collider != null)
            {
                GameObject touchObject = hitInFormation.transform.gameObject;
                if (touchObject.transform.tag == "MapLock" && touchObject.gameObject.name == "Tutorial_Lock")
                {
                    touchObject.SetActive(false);
                }
            }
        }
    }
}
