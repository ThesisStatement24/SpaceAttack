using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    public int score;

    public static int highscore;

    public Text text;

    /*
    public static ScoreManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    */

    void Start()
    {
        text = GetComponent<Text>();

        

        score = PlayerPrefs.GetInt("Score");
    }

    void Update()
    {

        //score = PlayerPrefs.GetInt("Score", score);

        text.text = "Score: " + score;
        

        PlayerPrefs.SetInt("Score", score);
    }

    public void AddPoints(int pointsToAdd)
    {
        Debug.Log("Hello?");
        score += pointsToAdd;

    }
}
