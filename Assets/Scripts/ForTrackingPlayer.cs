using UnityEngine;

public class ForTrackingPlayer : MonoBehaviour
{
    private FlyingPlayer _player;
    [SerializeField] private float _offset = 2;

    private void Awake()
    {
        _player = FindAnyObjectByType<FlyingPlayer>();
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
