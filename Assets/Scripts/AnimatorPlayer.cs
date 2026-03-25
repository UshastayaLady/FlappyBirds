using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorPlayer : MonoBehaviour
{
    private Animator animator;
    private const string InputFlyingUp = nameof(InputFlyingUp);

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
        animator.SetBool(InputFlyingUp, true);
        yield return new WaitForSeconds(1f);
        animator.SetBool(InputFlyingUp, false);
    }

    private void OnDisable()
    {
        ButtonsPlayer.clickedFlyUp -= FlewUpPlayer;
    }
}
