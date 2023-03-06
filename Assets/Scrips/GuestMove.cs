using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuestMove : MonoBehaviour
{
    public float speed;
    public int touchCount;
    public GameObject canvas;
    private Transform point_01;
    private Transform point_02;

    bool dist;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        point_01 = GameObject.Find("Point_01").transform;
        point_02 = GameObject.Find("Point_02").transform;

        if (gameObject.name != "Tutorial_Guest")
        {
            randomSpeed();
            moveCast();
        }
    }
    public void randomSpeed()
    {
        speed = Random.Range(0.005f, 0.02f);
    }

    public void moveCast()
    {
            if (Vector2.Distance(point_01.transform.position, transform.position) > Vector2.Distance(point_02.transform.position, transform.position))
            {
                dist = true;
            }
            else
            {
                dist = false;
            }
    }
    void Update()
    {
        if (gameObject.name != "Tutorial_Guest")
        {
            if (dist)
            {
                transform.Translate(Vector3.left * speed);

                if (point_01.transform.position.x - 3 >= transform.transform.position.x)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(Vector3.left * speed);

                if (point_02.transform.position.x + 3 <= transform.transform.position.x)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (gameObject.name == "Tutorial_Guest")
        {
            speed = 0;
        }
        if (touchCount >= 1)
        {
            canvas.SetActive(true);
            if (touchCount == 1 && GetComponent<GuestBar>().nowGauge != 33.4f)
            {
                GetComponent<GuestBar>().nowGauge = 33.4f;
                audioSource.Play();
            }
            else if (touchCount == 2 && GetComponent<GuestBar>().nowGauge != 66.8f)
            {
                GetComponent<GuestBar>().nowGauge = 66.8f;
                audioSource.Play();
            }
            else if (touchCount >= 3 && GetComponent<GuestBar>().nowGauge != 100)
            {
                GetComponent<GuestBar>().nowGauge = 100;
                audioSource.Play();
                if (gameObject.name != "Tutorial_Guest")
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
