using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button _restart;

    private void Awake()
    {
        _restart = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _restart.onClick.AddListener(NewGame);
    }

    private void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(NewGame);
    }
}