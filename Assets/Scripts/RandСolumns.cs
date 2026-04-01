using UnityEngine;

public class Rand—olumns : MonoBehaviour
{
    [SerializeField] private float _minTransformY = -4;
    [SerializeField] private float _maxTransformY = 2;
    private AddCoin _coin;

    private void Awake()
    {
        _coin = GetComponentInChildren<AddCoin>();
    }
    public void NewTransformColumns()
    {
        if (!_coin.gameObject.activeSelf)
        {           
            _coin.gameObject.SetActive(true);
        }
        ChangeTransform();
    }

    private void ChangeTransform()
    {
        float randomY = Random.Range(_minTransformY, _maxTransformY);
        transform.position = new Vector3(transform.position.x, randomY, transform.position.y);
    }

}
