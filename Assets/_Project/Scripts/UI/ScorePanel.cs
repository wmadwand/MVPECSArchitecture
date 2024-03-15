using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceText;

    public void UpdateView(int score, float distance)
    {
        //TODO: use StringBuilder
        scoreText.text = $"Score: {score}";
        distanceText.text = $"Distance: {Mathf.Round(distance)}";
    }
}