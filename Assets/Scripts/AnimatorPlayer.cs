using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorPlayer : MonoBehaviour
{
    private Animator _animator;
    private const string InputFlyingUp = nameof(InputFlyingUp);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ButtonsPlayer.clickedFlyUp += FlewUpPlayer;
    }

    private void FlewUpPlayer()
    {
        StartCoroutine("StartUpFlyAnimation");
    }

    private IEnumerator StartUpFlyAnimation()
    {
        _animator.SetBool(InputFlyingUp, true);
        yield return new WaitForSeconds(1f);
        _animator.SetBool(InputFlyingUp, false);
    }
   
    private void OnDisable()
    {
        ButtonsPlayer.clickedFlyUp -= FlewUpPlayer;
    }
}
