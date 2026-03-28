using UnityEngine;

public class CameraForTracking : MonoBehaviour
{
    private FlyingPlayer _player;
    private float _offset = 2;

    private void Awake()
    {
        _player = FindAnyObjectByType<FlyingPlayer>();
    }

    private void Start()
    {
        transform.position = new Vector3(_player.transform.position.x + _offset, _player.transform.position.y, transform.position.z);
    }

    void Update()
    {
        TrackingPlayer();
    }

    private void TrackingPlayer()
    {
        transform.position = new Vector3(_player.transform.position.x + _offset, transform.position.y, transform.position.z);
    }
}
