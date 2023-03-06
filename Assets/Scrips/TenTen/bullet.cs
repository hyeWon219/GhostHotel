using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;

    void Start()
    {
        Invoke("DestroyBullet", 2);   
    }


    void Update()
    {
        //RaycastHit2D ray_cover_1 = Physics2D.Raycast(transform.position, transform.right, distance);

        RaycastHit2D ray_cover_2 = Physics2D.Raycast(transform.position, transform.right, distance, 1 << 8);


        if(ray_cover_2.collider !=null)
        {
            if (ray_cover_2.collider.tag == "FLYMOB")
            {
                ray_cover_2.collider.gameObject.SetActive(false);
            }

            DestroyBullet();
        }
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ENEMY"))
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
