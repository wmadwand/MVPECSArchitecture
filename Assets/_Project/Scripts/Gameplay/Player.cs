using System;
using UnityEngine;
using Zenject;

public interface IPlayer
{
    float AddDistance { get; }

    void SetPosition(Vector2 touchPosition, float playerSpeed, int offset);
}

public class Player : MonoBehaviour, IPlayer
{
    public float AddDistance { get; private set; }

    private Vector3 _originPos;
    private ExtraSettings _extraSettings;
    private Camera _camera;

    [Inject]
    private void Construct(ExtraSettings extraSettings, Camera camera)
    {
        _extraSettings = extraSettings;
        _camera = camera;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.IsCollisionEnter = true;
        }
    }

    public void SetPosition(Vector2 touchPosition, float playerSpeed, int offset)
    {
        var pos = new Vector3(Mathf.Clamp(touchPosition.x, offset, Screen.width - offset), Mathf.Clamp(touchPosition.y, offset, Screen.height - offset));
        pos = _camera.ScreenToWorldPoint(pos);
        pos.z = 0;

        _originPos = transform.position;
        transform.position = Vector3.Lerp(transform.position, pos, playerSpeed * Time.deltaTime);
        //TODO: sqrMagnitude
        AddDistance = Vector3.Distance(_originPos, transform.position);
        _originPos = transform.position;
    }

    [Serializable]
    public class ExtraSettings
    {
        public Vector3 Velocity;
    }

    //TODO:
    //public class Factory : PlaceholderFactory<Player> { }
}