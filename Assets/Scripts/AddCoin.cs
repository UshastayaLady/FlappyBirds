using System;
using UnityEngine;

public class AddCoin : MonoBehaviour
{
    public static event Action tookCoin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tookCoin?.Invoke();
        gameObject.SetActive(false);
    }
}
