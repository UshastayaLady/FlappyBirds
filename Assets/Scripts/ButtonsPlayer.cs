using System;
using UnityEngine;

public class ButtonsPlayer : MonoBehaviour
{

    private KeyCode flyUpButton = KeyCode.Space;

    public static event Action clickedFlyUp;

    
    void Update()
    {
        ClickedFlyUp();
    }
      
    private void ClickedFlyUp()
    {
        if (Input.GetKeyDown(flyUpButton))
        {
            clickedFlyUp?.Invoke();
        }
    }
}
