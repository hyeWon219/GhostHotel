using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float speed = 0.25f;
    private Vector2 nowPos;
    private Vector2 prePos;
    private Vector2 movePos;

    public Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float y = Input.GetAxis("Mouse Y");
            if (mainCamera.transform.position.y <= -0.45f && mainCamera.transform.position.y >= -8.3f)
            {
                mainCamera.transform.position -= new Vector3(0, y, 0);
            }
            else if (mainCamera.transform.position.y > -0.45f)
            {
                mainCamera.transform.position = new Vector3(0, -0.45f, -10);
            }
            else
            {
                mainCamera.transform.position = new Vector3(0, -8.3f, -10);
            }
        }
        /*if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos.y = touch.position.y - touch.deltaPosition.y;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos.y = touch.position.y - touch.deltaPosition.y;
                movePos.y = (prePos.y - nowPos.y) * Time.deltaTime * speed;
                mainCamera.transform.Translate(movePos);
                prePos.y = touch.position.y - touch.deltaPosition.y;
            }
        }*/
    }
}
