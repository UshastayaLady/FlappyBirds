using System;
using UnityEngine;

public class ButtonsPlayer : MonoBehaviour
{

    private KeyCode _flyUpButton = KeyCode.Space;

    public static event Action clickedFlyUp;

    
    void Update()
    {
        ClickedFlyUp();
    }
      
    private void ClickedFlyUp()
    {
        if (Input.GetKeyDown(_flyUpButton))
        {
            clickedFlyUp?.Invoke();
        }
    }
}
