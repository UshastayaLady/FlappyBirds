using UnityEngine;

public class CameraForTracking : MonoBehaviour
{
    private FlyingPlayer player;

    private void Awake()
    {
        player = FindAnyObjectByType<FlyingPlayer>();
    }

    private void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    void Update()
    {
        TrackingPlayer();
    }

    private void TrackingPlayer()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
