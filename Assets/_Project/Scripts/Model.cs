using UnityEngine;

public class Model:IApplicationModel
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

    public void AddDistance(float value)
    {
        Distance += value;
    }

    public void Save()
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

public interface IApplicationModel
{
}