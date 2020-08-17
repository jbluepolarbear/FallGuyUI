using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Transform _pivotTarget;
    
    [SerializeField]
    private Transform _pivotPoint;
    
    [SerializeField]
    private Transform _aimTarget;

    [SerializeField]
    private float _offsetMin = 2.0f;
    
    [SerializeField]
    private float _offsetMax = 6.0f;

    [SerializeField]
    private float _growTime = 2.0f;

    private float _offset;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        float startTime = Time.time;
        while (Time.time - startTime < _growTime)
        {
            _offset = Mathf.Lerp(_offsetMin, _offsetMax, (Time.time - startTime) / _growTime);
            yield return null;
        }

        _offset = _offsetMax;
    }

    // Update is called once per frame
    void Update()
    {
        _pivotTarget.position = _pivotPoint.position + _pivotPoint.forward * _offset;
        _camera.transform.position = _pivotTarget.position;
        _camera.transform.forward = (_aimTarget.position - _camera.transform.position).normalized;
    }
}
