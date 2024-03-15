using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceText;

    public Model model;

    private void Awake()
    {
        Player.OnDestroyEnemy += Player_OnDestroyEnemy;

        //TODO: move to Presenter
        model = new Model();
        UpdateView();
    }

    private void Update()
    {
        UpdateView();
    }

    private void Player_OnDestroyEnemy(Enemy enemy)
    {
        model.AddScore(enemy.Score);

        UpdateView();
    }

    private void UpdateView()
    {
        //TODO: use StringBuilder
        scoreText.text = $"Score: {model.Score}";
        distanceText.text = $"Distance: {model.Distance}";
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
