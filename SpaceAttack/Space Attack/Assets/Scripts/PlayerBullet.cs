using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public ScoreManager addScore;

    private void Start()
    {

        addScore = FindObjectOfType<ScoreManager>();

    }

    // If an object collides with the level ignore it, and if objects colliding share a tag ignore them too, otherwise destroy the object that is colliding
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {

            addScore.AddPoints(30);
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }

        if (other.gameObject.tag == "Asteroid")
        {

            addScore.AddPoints(10);
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }
}
