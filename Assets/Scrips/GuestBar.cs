using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestBar : MonoBehaviour
{
    public Transform guest;
    public Slider gaugeBar;
    public float maxGauge;
    public float nowGauge;

    void Start()
    {
        maxGauge = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = guest.position + new Vector3(0, 0, 0);
        gaugeBar.value = nowGauge / maxGauge;
    }
}
