using System;
using UnityEngine;

public class GameOverPlayer : MonoBehaviour
{
    public static event Action gameOver;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<FlyingPlayer>())
        {
            gameOver?.Invoke();
            Time.timeScale = 0;
            this.gameObject.SetActive(false);
        }
    }
}
