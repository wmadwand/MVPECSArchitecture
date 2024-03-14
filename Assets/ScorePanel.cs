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

        //TODO: move to Presenter
        model = new Model();
        UpdateView();

    }

    private void Player_OnDestroyEnemy(Enemy enemy)
    {
        model.AddScore(enemy.Score);

        UpdateView();
    }

    private void UpdateView()
    {
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
    public float Distance { get; private set; }

    private readonly UserDataStorage _userDataStorage;

    public Model()
    {
        //TODO: inject
        _userDataStorage = new UserDataStorage();
        var data = _userDataStorage.Load();

        if (data != null)
        {
            Score = data.score;
            Distance = data.distance;
        }
    }

    private UserData GetUserData()
    {
        return new UserData(Score, Distance);
    }

    ~Model()
    {
        _userDataStorage.Save(GetUserData());
    }

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
