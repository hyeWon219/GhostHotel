using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotDestroy : MonoBehaviour
{
    //public GameObject doorButton;

    // Start is called before the first frame update
    private static NotDestroy instance = null;
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
    public static NotDestroy Instance
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

    void Start()
    {

    }

    // Update is called once per frame
    /*void Update()
    {
        //씬이 변경되면 doorbutton비활성화
        if (SceneManager.GetActiveScene().name != "Hotel Outside")
        {
            doorButton.SetActive(false);
        }
        else
        {
            doorButton.SetActive(true);

        }
    }*/
}
