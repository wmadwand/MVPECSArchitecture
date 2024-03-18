using UnityEngine;
using UnityEngine.UI;

public interface IUserInterfaceView
{
    void Update(int score, float distance);
    Vector2 TouchPosition { get; }
    bool Pause { get; }
    bool Resume { get; }
    void ShowPause(bool value);
    Text DistanceRxText { get; }
}