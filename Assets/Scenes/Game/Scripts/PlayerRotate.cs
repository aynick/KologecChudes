using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRotate : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private Transform _ropeTransform;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        RotateRope();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void RotateRope()
    {
        if (_ropeTransform.rotation.z > 20 || _ropeTransform.rotation.z < -20) return;
        var moveSpeed = Mathf.Clamp(Input.acceleration.normalized.x,-1,1) * _speed;
        var direction = new Vector2(moveSpeed, -2);
        _rigidbody2D.velocity = direction;
    }
}
