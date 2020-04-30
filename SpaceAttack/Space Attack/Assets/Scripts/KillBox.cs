using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Enemy")
        {

            Destroy(col.gameObject);

        }

        if (col.gameObject.tag == "Asteroid")
        {

            Destroy(col.gameObject);

        }

        if (col.gameObject.tag == "EnemyBullet")
        {

            Destroy(col.gameObject);

        }

        if (col.gameObject.tag == "PlayerBullet")
        {

            Destroy(col.gameObject);

        }

    }
}
