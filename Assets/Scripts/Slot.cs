using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private Transform _fallGuyTarget = null;
    [SerializeField]
    private Pusher _pusher = null;

    public Transform FallGuyTarget => _fallGuyTarget;

    private bool _isPusher = false;
    public bool IsPusher
    {
        get
        {
            return _isPusher;
        }
        set
        {
            _isPusher = true;
            _pusher.StartPush(OnPushComplete);
        }
    }

    private void OnPushComplete()
    {
        OnPushCompleteCallback();
    }

    public Action OnPushCompleteCallback;

    public void ShowSuccess()
    {
        _pusher.ShowSuccess();
    }
}
