using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public PlayerScript Guns2;

    // Audio clip to play when pickup is collected.
    //public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {

        Guns2 = FindObjectOfType<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Guns2.twoGuns = true;
            Destroy(this.gameObject);
        }
    }
}
