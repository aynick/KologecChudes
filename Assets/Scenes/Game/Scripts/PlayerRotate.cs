using System;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform _ropeTransform;
    [SerializeField] private float _sensivity;

    private void FixedUpdate()
    {
        RotateRope();
    }

    void RotateRope()
    {
        if (_ropeTransform.rotation.z > 20 || _ropeTransform.rotation.z < -20) return;
        var Rotate = Input.acceleration.x * _sensivity;
        var euler = Quaternion.Euler(0,0,Rotate);
        _ropeTransform.localRotation = Quaternion.Lerp(_ropeTransform.rotation,euler ,_sensivity/3 * Time.fixedDeltaTime);
    }
}
