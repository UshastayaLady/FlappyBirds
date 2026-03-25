using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AnimatorPlayer))]
[RequireComponent(typeof(ButtonsPlayer))]
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
        rigbody.AddForce(Vector2.up * forceUp, ForceMode2D.Impulse);
        
    }

    private void FlewPlayer()
    {
        rigbody.linearVelocityX = speedFly * Time.fixedDeltaTime;
    }

    private void OnDisable()
    {
        ButtonsPlayer.clickedFlyUp -= FlewUpPlayer;
    }
}
