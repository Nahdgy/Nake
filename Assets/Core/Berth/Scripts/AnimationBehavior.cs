using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehavior : MonoBehaviour
{
    public Animator animator;
    public AnimationClip clip;

    public void Failed()
    {
       animator.SetBool("WaitToFailed", true);

    }
    public void FadeIn()
    {
       animator.SetBool("WaitToFade", true);
    } 
    public void FadeIn()
    {
       animator.SetBool("WaitToFade", true);
    }
}
