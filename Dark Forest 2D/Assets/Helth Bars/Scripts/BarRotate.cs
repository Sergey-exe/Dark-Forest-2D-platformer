using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarRotate : MonoBehaviour
{
    private Quaternion _startQuaternion;

    private void Awake()
    {
        _startQuaternion = transform.rotation;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.rotation = _startQuaternion;
    }
}
