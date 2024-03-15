using UnityEngine;

public class Player : MonoBehaviour
{
    public float AddDistance { get; private set; }

    private Vector3 _originPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.IsCollisionEnter = true;
        }
    }

    public void SetPosition(Vector2 touchPosition, float playerSpeed)
    {
        var offset = 30;
        var pos = new Vector3(Mathf.Clamp(touchPosition.x, offset, Screen.width - offset), Mathf.Clamp(touchPosition.y, offset, Screen.height - offset));
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;

        _originPos = transform.position;

        transform.position = Vector3.Lerp(transform.position, pos, playerSpeed * Time.deltaTime);

        //TODO: sqrMagnitude
        AddDistance = Vector3.Distance(_originPos, transform.position);
        _originPos = transform.position;
    }
}