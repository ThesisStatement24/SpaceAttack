using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTPscreen : MonoBehaviour
{

    public GameObject HTPcanvas;
    public GameObject UIcanvas;

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey)
        {

            HTPcanvas.SetActive(false);
            UIcanvas.SetActive(true);
            Time.timeScale = 1;

        }

    }
}
