using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuestTouch : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "Hotel Outside")
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInFormation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
            if (hitInFormation.collider != null)
            {
                GameObject touchObject = hitInFormation.transform.gameObject;
                if (touchObject.transform.tag == "Guest" && touchObject.gameObject.name != "Tutorial_Guest")
                {
                    touchObject.GetComponent<GuestMove>().speed = 0;
                    StartCoroutine("Guest_Scale", touchObject);
                }
                else if (touchObject.gameObject.name == "Tutorial_Guest")
                {
                    StartCoroutine("Guest_Scale", touchObject);
                }
            }
        }
        else if (Input.GetMouseButtonDown(0) && GameManager.Instance.Room())
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInFormation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
            if (hitInFormation.collider != null)
            {
                GameObject touchObject = hitInFormation.transform.gameObject;
                if (touchObject.transform.tag == "Enemy")
                {
                    GameManager.Instance.CleanDust();
                    touchObject.SetActive(false);
                }
            }

            /*if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hitInfo = Physics2D.Raycast(touchPos, Camera.main.transform.forward * -1);

                    if (hitInfo.collider.tag != null)
                    {
                        Debug.Log("1");
                        GameObject touchObj = hitInfo.transform.gameObject;
                        if (touchObj.gameObject.tag == "Guest")
                        {
                            Debug.Log("2");
                        }
                    } 
                }
            }*/
        }
    }
    IEnumerator Guest_Scale(GameObject obj)
    {
        float time;
        time = Time.deltaTime;
        do
        {
            if (obj.transform.localScale.x <= 0.5f)
            {
                obj.transform.localScale += Vector3.one * (0.03f + Time.deltaTime);
            }
            else
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        } while (true);

        do
        {
            if (obj.transform.localScale.x >= 0.3f)
            {
                obj.transform.localScale -= Vector3.one * (0.03f + Time.deltaTime);
            }
            else
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        } while (true);

        obj.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        obj.GetComponent<GuestMove>().touchCount++;
    }
}
