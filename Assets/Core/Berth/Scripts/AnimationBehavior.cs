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
        animator.SetBool("InToOut", false); ;
        animator.SetBool("OutToIn", true);
    } 
    public void FadeOut()
    {
       animator.SetBool("WaitToOut", true); 
       animator.SetBool("InToOut", true);
       animator.SetBool("OutToIn", false);
    }

    public void Wait()
    {
        animator.SetBool("WaitToOut", false);
        animator.SetBool("WaitToFade", false);
    }
}
