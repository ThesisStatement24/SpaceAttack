using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public int LifeCount;
    public bool oneGun;
    public bool twoGuns;

    public Text LivesText;

    public float laserFireRate;
    float laserCooldown = 0;

    void Start()
    {
        // When object is constructed set it's position to the designer defined startPosition

        oneGun = true;
        rb = GetComponent<Rigidbody2D>();
        LivesText = GameObject.FindGameObjectWithTag("LifeText").GetComponent<Text>();
        LifeCount = 3;
        LivesText.text = "Lives: " + LifeCount;

    }

    void Update()
    {
        if (twoGuns == true)
        {

            oneGun = false;
            StartCoroutine(PowerUpCooldown());

        }

        if (LifeCount == 0)
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
        if (laserCooldown <= 0 && Input.GetKeyDown(KeyCode.Space) && oneGun == true)
        {
            laserCooldown = laserFireRate;
            Instantiate(bullet, Gun1.position, Gun1.rotation); // Create a new bullet
        }

        if (laserCooldown <= 0 && Input.GetKeyDown(KeyCode.Space) && twoGuns == true)
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

            LifeCount--;
            Player.transform.position = SpawnPoint.transform.position;
            LivesText.text = "Lives: " + LifeCount;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "EnemyBullet")
        {

            LifeCount--;
            Player.transform.position = SpawnPoint.transform.position;
            LivesText.text = "Lives: " + LifeCount;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Asteroid")
        {

            LifeCount--;
            Player.transform.position = SpawnPoint.transform.position;
            LivesText.text = "Lives: " + LifeCount;
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
