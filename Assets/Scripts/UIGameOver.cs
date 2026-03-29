using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private GameObject _uiGameOver;
   
    private void OnEnable()
    {
        GameOverPlayer.gameOver += GameOver;
    }

    private void GameOver()
    {
        _uiGameOver.SetActive(true);        
    }

    private void OnDisable()
    {
        GameOverPlayer.gameOver -= GameOver;
    }
}
