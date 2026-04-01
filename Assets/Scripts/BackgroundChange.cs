using UnityEngine;
public class BackgroundChange : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _background1;
    [SerializeField] private SpriteRenderer _background2;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Transform _startPosition;

    void Update()
    {
        CycleBackgrounds();
    }       

    private void CycleBackgrounds()
    {
        // Проверяем и циклически перемещаем каждый фон
        TryCycleBackground(_background1);
        TryCycleBackground(_background2);
    }

    private void TryCycleBackground(SpriteRenderer background)
    {
        if (background == null) return;

        // Если фон достиг или прошел конечную позицию по X
        if (background.transform.position.x <= _endPosition.position.x)
        {            
            Vector2 newPosition = new Vector2(_startPosition.position.x, background.transform.position.y);
            background.transform.position = newPosition;

            // Меняем позицию колонны
            OnBackgroundChanged(background);
        }
    }

    private void OnBackgroundChanged(SpriteRenderer background)
    {
        background.GetComponentInChildren<RandСolumns>().NewTransformColumns();
    }
}
