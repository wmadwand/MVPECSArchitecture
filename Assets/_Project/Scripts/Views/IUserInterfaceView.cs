using UnityEngine;

public interface IUserInterfaceView
{
    void Update(int score, float distance);
    Vector2 TouchPosition { get; }
}