using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pusher : MonoBehaviour
{
    [SerializeField]
    private float _pushSpeed = 1f;

    [SerializeField]
    private Transform _pusherCube = null;

    [SerializeField]
    private Transform _pusherEnd = null;

    [SerializeField]
    private float _maxTimeToWait = 2.0f;

    [ColorUsageAttribute(true, true)]
    [SerializeField]
    private Color _failedColor;

    [ColorUsageAttribute(true, true)]
    [SerializeField]
    private Color _successColor;
    [SerializeField]
    private Renderer _renderer;

    public void StartPush(Action onPushComplete)
    {
        _onPushComplete = onPushComplete;
        float randomWaitTime = Mathf.Max(_maxTimeToWait * 0.1f, Random.value * _maxTimeToWait);
        StartCoroutine(PushCoroutine(randomWaitTime));
    }

    public void ShowSuccess()
    {
        _renderer.material.SetColor("_Color", _successColor);
    }

    private IEnumerator PushCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _renderer.material.SetColor("_Color", _failedColor);
        Vector3 startPosition = _pusherCube.position;
        Vector3 direction = _pusherEnd.position - startPosition;
        float timeToPush = direction.magnitude / _pushSpeed;
        float start = Time.time;
        while (Time.time - start < timeToPush)
        {
            Vector3 travel = (Time.time - start) / timeToPush * direction;
            _pusherCube.position = startPosition + travel;
            yield return null;
        }
        _pusherCube.position = _pusherEnd.position;
        _onPushComplete();
    }

    private Action _onPushComplete;
}
