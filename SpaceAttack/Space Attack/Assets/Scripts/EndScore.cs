using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndScore : MonoBehaviour
{

    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {

        ScoreText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = "Your Score: " + PlayerPrefs.GetInt("Score").ToString();

    }
}
