public interface IApplicationModel
{
    float Distance { get; }
    int Score { get; }

    void Update(int score, float distance);
    void Save();
}
