using UnityEngine;

public class ForTrackingPlayer : MonoBehaviour
{
    private FlyingPlayer _player;
    [SerializeField] private float _offset = 2;

    private void Awake()
    {
        _player = FindAnyObjectByType<FlyingPlayer>();
    }
    private void OnEnable()
    {
        GameOverPlayer.gameOver += GameOver;
    }

    private void GameOver()
    {
        enabled = false;
    }

    void Update()
    {
        TrackingPlayer();
    }

    private void TrackingPlayer()
    {
        transform.position = new Vector3(_player.transform.position.x + _offset, transform.position.y, transform.position.z);
    }   

    private void OnDisable()
    {
        GameOverPlayer.gameOver -= GameOver;
    }
}
