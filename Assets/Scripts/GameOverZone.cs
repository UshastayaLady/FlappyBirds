using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GameOverPlayer : MonoBehaviour
{
    public static event Action gameOver;
    
    private void OnEnable()
    {
        gameOver += DisableScript;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FlyingPlayer>())
        {
            gameOver?.Invoke();            
        }
    }
   
    private void DisableScript()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        gameOver -= DisableScript;
    }
}
