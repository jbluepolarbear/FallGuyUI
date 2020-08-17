using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallGuy : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Renderer _renderer;
    void Start()
    {
        int animation = Random.Range(1, 5);
        _animator.SetInteger("stage", animation);
        _renderer.material.SetColor("_Color", new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F)));
    }
}
