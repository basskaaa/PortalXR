using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWallAnim : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRise()
    {
        _animator.SetTrigger("Rise");
    }
}
