using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAboutY : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.0f;

    private void Update()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        euler.y += _speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(euler);
    }
}
