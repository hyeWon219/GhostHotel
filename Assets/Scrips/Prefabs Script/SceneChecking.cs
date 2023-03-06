using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecking : MonoBehaviour
{
    public GameObject fSet;

    private static SceneChecking instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SceneChecking Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FurnutureActive();
    }

    public void FurnutureActive()
    {
        if (!GameManager.Instance.Room())
        {
            fSet.tag = "OffRoom";
            fSet.SetActive(false);          
        }

        else
        {
            fSet.tag = "OnRoom";
            fSet.SetActive(true);
        }
    }
}
