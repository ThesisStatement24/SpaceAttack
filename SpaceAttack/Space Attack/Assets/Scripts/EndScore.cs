using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndScore : MonoBehaviour
{

    public Text PlayerScoreText;
    public Text HScoreText;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        PlayerScoreText.text = "Your Score: " + PlayerPrefs.GetInt("Score").ToString();
        HScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();

    }
}
