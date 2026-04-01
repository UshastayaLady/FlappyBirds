using UnityEngine;
using UnityEngine.UI;

public class ViewCoins : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    private int _countCoin = 0;

    private void OnEnable()
    {
        AddCoin.tookCoin += Add;
    }
    
    private void Add()
    {
        _countCoin++;
        _coinText.text = _countCoin.ToString();
    }

    private void OnDisable()
    {
        AddCoin.tookCoin -= Add;
    }
}
