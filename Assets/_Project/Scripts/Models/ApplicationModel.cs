public class ApplicationModel : IApplicationModel
{
    public int Score { get; private set; }
    public float Distance { get; private set; }

    private readonly UserDataLocalStorage _userDataStorage;

    public ApplicationModel()
    {
        //TODO: inject
        _userDataStorage = new UserDataLocalStorage();
        var data = _userDataStorage.Load();

        if (data != null)
        {
            Score = data.Score;
            Distance = data.Distance;
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
    }
}
