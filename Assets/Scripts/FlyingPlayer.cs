using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class FlyingPlayer : MonoBehaviour
{
    [SerializeField] private float forceUp;
    [SerializeField] private float speedFly;

    private Rigidbody2D rigbody;

    private void Awake()
    {
        rigbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ButtonsPlayer.clickedFlyUp += FlewUpPlayer;
    }

    void FixedUpdate()
    {
        FlewPlayer();
    }

    private void FlewUpPlayer()
    {
        rigbody.AddForce(Vector2.up * forceUp * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void FlewPlayer()
    {
        rigbody.linearVelocity = new Vector2(transform.position.x + speedFly * Time.fixedDeltaTime, transform.position.y);
    }

    private void OnDisable()
    {
        ButtonsPlayer.clickedFlyUp -= FlewUpPlayer;
    }
}
