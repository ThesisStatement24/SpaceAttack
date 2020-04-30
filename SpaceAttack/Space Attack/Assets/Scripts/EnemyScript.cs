using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public Transform Gun;
    public GameObject Bullet;
    public GameObject PowerUp;
    public PlayerScript PlayerLife;
    int powerup = 1;
    public float laserFireRate;
    float laserCooldown = 0;

        // Start is called before the first frame update
        void Start()
    {

        PlayerLife = FindObjectOfType<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

        laserCooldown -= Time.deltaTime;
        if (laserCooldown <= 0)
        {
            laserCooldown = laserFireRate;
            Instantiate(Bullet, Gun.position, Gun.rotation); // Create a new bullet
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Random.Range(0, 10) == powerup && collision.gameObject.tag == "Player")
        {
            Instantiate(PowerUp, transform.position, transform.rotation);
            Destroy(this.gameObject);

        } else if (Random.Range(0, 10) == powerup && collision.gameObject.tag == "PlayerBullet")
        {
            Instantiate(PowerUp, transform.position, transform.rotation);
            Destroy(this.gameObject);

        }


    }



}
