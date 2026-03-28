using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private Image _uiGameOver;
   
    private void OnEnable()
    {
        GameOverPlayer.gameOver += GameOver;
    }

    private void GameOver()
    {
        _uiGameOver.enabled = true;
    }

    private void OnDisable()
    {
        GameOverPlayer.gameOver -= GameOver;
    }
}
