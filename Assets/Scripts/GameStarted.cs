using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStarted : MonoBehaviour
{
    private Button start;
    private int idScene;

    private void Awake()
    {
        start = GetComponent<Button>();
    }
    private void OnEnable()
    {
        start.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(idScene);
    }

    public void SetIdScene(int id)
    {
        idScene = id;
    }

    private void OnDisable()
    {
        start.onClick.RemoveListener(LoadScene);
    }
}
