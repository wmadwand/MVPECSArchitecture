using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceText;

    public ApplicationModel model;

    private void Awake()
    {
        Player.OnDestroyEnemy += Player_OnDestroyEnemy;

        //TODO: move to Presenter
        model = new ApplicationModel();        
    }

    private void Player_OnDestroyEnemy(Enemy enemy)
    {
        model.AddScore(enemy.Score);


    }

    public void UpdateView(int score, float distance)
    {
        //TODO: use StringBuilder
        scoreText.text = $"Score: {score}";
        distanceText.text = $"Distance: {distance}";
    }

    private void OnDestroy()
    {
        Player.OnDestroyEnemy -= Player_OnDestroyEnemy;
    }

    private void OnApplicationQuit()
    {
        model.Save();
    }
}
