using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomPlayer : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector3 mousePos, transPos, targetPos, dist;
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(collision.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CalTargetPos();

        RotateMove();
    }

    void CalTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
    }

    void RotateMove()
    {
        dist = targetPos - transform.position;
        transform.position += dist * speed * Time.deltaTime;

        float angle = Mathf.Atan2(dist.y, dist.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }


    void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
        }
    }

}