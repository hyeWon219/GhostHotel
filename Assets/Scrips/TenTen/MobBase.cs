using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public float mobSpeed = 0;
    public Vector2 StartPosition;

    // OnEnable 함수는 오브젝트가 활성화 될때 실행
    private void OnEnable()
    {
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager2.instance.isPlay)
        transform.Translate(Vector2.left * Time.deltaTime * GameManager2.instance.gameSpeed);

        if(transform.position.x < -6)
        {
            gameObject.SetActive(false);
        }
    }
}
