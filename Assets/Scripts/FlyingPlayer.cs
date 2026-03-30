using System.Collections;
using Unity.VisualScripting;
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

    [SerializeField] private float _angleUp = 20f;
    [SerializeField] private float _angleDown = -10f;
    [SerializeField] private float _duration = 0.2f;
    [SerializeField] private float _pausaBetweenUpDown = 0.1f;

    private Rigidbody2D _rigbody;
    private Coroutine _currentRotationCoroutine;

    private void Awake()
    {
        _rigbody = GetComponent<Rigidbody2D>();
        StartCoroutine(RotateSmoothly(_angleDown, _duration));
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
        if (_currentRotationCoroutine != null)
            StopCoroutine(_currentRotationCoroutine);

        _currentRotationCoroutine = StartCoroutine(RotateUpThenDown(_pausaBetweenUpDown));

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

        if (_currentRotationCoroutine != null)
            StopCoroutine(_currentRotationCoroutine);

        _rigbody.AddForce(Vector2.up * _forceUpWhenKill, ForceMode2D.Impulse);

        StartCoroutine(RotateSmoothly(-180, _rotationDuration));

        _rigbody.gravityScale = 3;
        enabled = false;
    }
    private IEnumerator RotateUpThenDown(float _pausaBetweenUpDown)
    {
        // Поворот вверх
        yield return StartCoroutine(RotateSmoothly(_angleUp, _duration));
        
        yield return new WaitForSeconds(_pausaBetweenUpDown);
        
        // Поворот вниз
        yield return StartCoroutine(RotateSmoothly(_angleDown, _duration));

        _currentRotationCoroutine = null;
    }

    private IEnumerator RotateSmoothly(float angle, float duration)
    {
        Quaternion startRotation = Quaternion.Euler(0, 0, transform.rotation.z);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return new WaitForFixedUpdate();
        }
        transform.rotation = targetRotation;        
    }

    private void OnDisable()
    {
        ButtonsPlayer.clickedFlyUp -= FlewUpPlayer;
        GameOverPlayer.gameOver -= GameOverAnimation;
    }
}
