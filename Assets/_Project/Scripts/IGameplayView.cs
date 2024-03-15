using UnityEngine;

public interface IGameplayView
{
    float AddDistance { get; }
    int AddScore { get; }

    void Update(Vector2 touchPosition);
}