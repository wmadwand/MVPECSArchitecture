using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceText;

    //private void Player_OnDestroyEnemy(Enemy enemy)
    //{
    //    model.AddScore(enemy.Score);
    //}

    public void UpdateView(int score, float distance)
    {
        //TODO: use StringBuilder
        scoreText.text = $"Score: {score}";
        distanceText.text = $"Distance: {distance}";
    }
}