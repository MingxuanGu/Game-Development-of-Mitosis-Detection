/**
 * Author: Zhaoya Pan
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public static float score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //ScoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    public void DisplayScore()
    {
        ScoreText.text = score.ToString();
    }

    public void yesButton()
    {
        // get image label
        string label = LoadImages.filenames[LoadImages.index][1];
        if (label == "1")
            score += 100;
        else
            score -= 50;
    }

    public void noButton()
    {
        // get image label
        string label = LoadImages.filenames[LoadImages.index][1];
        if (label == "0")
            score += 100;
        else
            score -= 50;
    }
}
