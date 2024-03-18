using UniRx;

public interface IApplicationModel
{
    float Distance { get; }
    int Score { get; }
    ReactiveProperty<float> DistanceRx { get; }

    void Update(int score, float distance);
    void Save();
}
