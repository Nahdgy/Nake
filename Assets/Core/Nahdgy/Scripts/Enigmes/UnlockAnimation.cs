using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAnimation : MonoBehaviour
{

    [SerializeField]
    private string _animName;
    [SerializeField]
    private bool _canAnime;
    [SerializeField]
    private float _timing;
    [SerializeField]
    private AnimationClip _anim;
    [SerializeField]
    private Animator _animator;
}
