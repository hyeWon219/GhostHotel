using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeControl : MonoBehaviour
{
    public List<Transform> guest;
    public List<GameObject> gaugeBar;

    Camera camera;
    void Start()
    {
        camera = Camera.main;
        for (int i = 0; i < guest.Count; i++)
        {
            gaugeBar[i].transform.position = guest[i].position;
        }
    }

    void Update()
    {
        for (int i = 0; i < guest.Count; ++i)
        {
            gaugeBar[i].transform.position = camera.WorldToScreenPoint(guest[i].position + new Vector3(0, 1, 0));
        }
    }
}
