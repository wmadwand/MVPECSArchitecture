using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private Model model;

    private void Awake()
    {
        Player.OnDestroyEnemy += Player_OnDestroyEnemy;

        model = new Model();
    }

    private void Player_OnDestroyEnemy(Enemy enemy)
    {
        model.AddScore(enemy.Score);

        scoreText.text = model.Score.ToString();
    }

    private void OnDestroy()
    {
        Player.OnDestroyEnemy -= Player_OnDestroyEnemy;
    }
}

public class Model
{
    public int Score { get; private set; }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void LoseScore(int value)
    {
        Score -= value;
        Score = Mathf.Clamp(Score, 0, Score);
    }
}
