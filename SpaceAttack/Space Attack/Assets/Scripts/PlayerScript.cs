using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public Transform Gun1;
    public Transform Gun2;
    public Transform Gun3;
    public GameObject bullet;
    public GameObject SpawnPoint;
    public GameObject Player;
    public int Lives;
    public bool oneGun;
    public bool twoGuns;

    public float laserFireRate;
    float laserCooldown = 0;

    void Start()
    {
        // When object is constructed set it's position to the designer defined startPosition

        oneGun = true;
        rb = GetComponent<Rigidbody2D>();
        Lives = 3;

    }

    void Update()
    {
        if (twoGuns == true)
        {

            oneGun = false;
            StartCoroutine(PowerUpCooldown());

        }

        if (Lives == 0)
        {
            Destroy(this.gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);

        }

        fireLaser();

    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rb.velocity = movement * speed;

    }



    // We will fire a laser here
    void fireLaser()
    {

        laserCooldown -= Time.deltaTime;
        if (laserCooldown <= 0 && Input.GetButton("Fire1") && oneGun == true)
        {
            laserCooldown = laserFireRate;
            Instantiate(bullet, Gun1.position, Gun1.rotation); // Create a new bullet
        }

        if (laserCooldown <= 0 && Input.GetButton("Fire1") && twoGuns == true)
        {
            laserCooldown = laserFireRate;
            Instantiate(bullet, Gun2.position, Gun2.rotation); // Create a new bullet
            Instantiate(bullet, Gun3.position, Gun3.rotation); // Create a new bullet
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            Lives--;
            Player.transform.position = SpawnPoint.transform.position;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "EnemyBullet")
        {

            Lives--;
            Player.transform.position = SpawnPoint.transform.position;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Asteroid")
        {

            Lives--;
            Player.transform.position = SpawnPoint.transform.position;
            Destroy(collision.gameObject);

        }


    }

    IEnumerator PowerUpCooldown ()
    {

        yield return new WaitForSeconds(10);
        oneGun = true;
        twoGuns = false;


    }

}
