using UnityEngine;

public class CameraForTracking : MonoBehaviour
{
    private FlyingPlayer player;
    private float offset = 2;

    private void Awake()
    {
        player = FindAnyObjectByType<FlyingPlayer>();
    }

    private void Start()
    {
        transform.position = new Vector3(player.transform.position.x + offset, player.transform.position.y, transform.position.z);
    }

    void Update()
    {
        TrackingPlayer();
    }

    private void TrackingPlayer()
    {
        transform.position = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
