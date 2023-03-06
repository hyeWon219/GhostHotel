using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputTouch : MonoBehaviour
{
    public GameObject guest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

        }
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos;
            Ray ray;
            RaycastHit hit;

            switch (touch.phase)
            {
                case TouchPhase.Ended:
                    Vector2 touchPosToVector2_Cube = new Vector2(touch.position.x, touch.position.y);
                    touchPos = Camera.main.ScreenToViewportPoint(touchPosToVector2_Cube);
                    ray = Camera.main.ScreenPointToRay(touchPosToVector2_Cube);
                    GameObject _obj = GameObject.Find("Cube");

                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        if (hit.collider.tag == "Cube")
                        {
                            _obj.SetActive(false);
                        }
                    }
                    break;

                case TouchPhase.Began:
                    Vector2 touchPosToVector2_Guest = new Vector2(touch.position.x, touch.position.y);
                    touchPos = Camera.main.ScreenToViewportPoint(touchPosToVector2_Guest);
                    ray = Camera.main.ScreenPointToRay(touchPosToVector2_Guest);
                    GameObject guest = GameObject.Find("Guest");

                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        if (hit.collider.tag == "Guest")
                        {
                            guest.transform.Translate(0, 1f * Time.deltaTime, 0);
                        }
                    }
                    break;
            }
        }
        /*if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene("Hotel Inside");
            }
        }*/
    }
}
