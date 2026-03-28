using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AnimatorPlayer))]
[RequireComponent(typeof(ButtonsPlayer))]
public class FlyingPlayer : MonoBehaviour
{
    [SerializeField] private float _forceUpSpace;
    [SerializeField] private float _forceUpWhenKill;
    [SerializeField] private float _speedFly;
    [SerializeField] private float _rotationDuration = 0.5f;

    private Rigidbody2D _rigbody;

    private void Awake()
    {
        _rigbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ButtonsPlayer.clickedFlyUp += FlewUpPlayer;
        GameOverPlayer.gameOver += GameOverAnimation;
    }

    void FixedUpdate()
    {        
        FlewPlayer();
    }

    private void FlewUpPlayer()
    {
        _rigbody.AddForce(Vector2.up * _forceUpSpace, ForceMode2D.Impulse);
    }

    private void FlewPlayer()
    {
        _rigbody.linearVelocityX = _speedFly * Time.fixedDeltaTime;
    }
    private void GameOverAnimation()
    {
        ButtonsPlayer.clickedFlyUp -= FlewUpPlayer;
        GameOverPlayer.gameOver -= GameOverAnimation;

        _rigbody.AddForce(Vector2.up * _forceUpWhenKill, ForceMode2D.Impulse);

        StartCoroutine(RotateSmoothly(-180));

        _rigbody.gravityScale = 3;
        this.enabled = false;
    }

    private IEnumerator RotateSmoothly(float angle)
    {
        Quaternion startRotation = Quaternion.Euler(0, 0, 0); ;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, angle);
        float elapsed = 0f;

        while (elapsed < _rotationDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / _rotationDuration;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null; // ждём следующий кадр
        }

        transform.rotation = endRotation;
    }

    private void OnDisable()
    {
        ButtonsPlayer.clickedFlyUp -= FlewUpPlayer;
        GameOverPlayer.gameOver -= GameOverAnimation;
    }
}
