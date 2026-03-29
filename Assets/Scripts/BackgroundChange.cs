using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundChange : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _background1;
    [SerializeField] private SpriteRenderer _background2;
    [SerializeField] private Transform _endMoveBackground;
    [SerializeField] private Transform _startMoveBackground;


    void Update()
    {
        ChangeBackground();
    }

    private void ChangeBackground()
    {
        if (_background1.transform.position.x <= _endMoveBackground.position.x)
        {
            _background1.transform.position = new Vector2(_startMoveBackground.position.x, transform.position.y);
        }
        else if (_background2.transform.position.x <= _endMoveBackground.position.x)
        {
            _background2.transform.position = new Vector2(_startMoveBackground.position.x, transform.position.y);
        }
    }
}
