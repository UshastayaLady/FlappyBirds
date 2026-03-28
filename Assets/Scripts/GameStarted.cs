using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStarted : MonoBehaviour
{
    private Button _start;
    private int _idScene;

    private void Awake()
    {
        _start = GetComponent<Button>();
    }
    private void OnEnable()
    {
        _start.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_idScene);
    }

    public void SetIdScene(int id)
    {
        _idScene = id;
    }

    private void OnDisable()
    {
        _start.onClick.RemoveListener(LoadScene);
    }
}
