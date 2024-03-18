using UniRx;

public class ApplicationModel : IApplicationModel
{
    public int Score { get; private set; }
    public float Distance { get; private set; }

    public ReactiveProperty<float> DistanceRx { get; private set; }

    private readonly UserDataLocalStorage _userDataStorage;

    public ApplicationModel(UserDataLocalStorage userDataStorage)
    {
        DistanceRx = new ReactiveProperty<float>();

        _userDataStorage = userDataStorage;
        var data = _userDataStorage.Load();
        if (data != null)
        {
            Score = data.Score;
            Distance = data.Distance;
            DistanceRx.Value = data.Distance;
        }
    }

    void IApplicationModel.Save()
    {
        var data = new UserData(Score, Distance);
        _userDataStorage.Save(data);
    }

    void IApplicationModel.Update(int score, float distance)
    {
        Distance += distance;
        Score += score;
        DistanceRx.Value += distance;
    }
}
