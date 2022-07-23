using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRotate : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private bool _isMove;
    [SerializeField] private float _speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void SetIsMove(bool isMove)
    {
        _isMove = isMove;
    }

    public void Move()
    {
        if(!_isMove) return;
        var xDirection = Mathf.Clamp(Input.GetAxis("Horizontal"),-1,1) * _speed;
        // var xDirection = Mathf.Clamp(Input.acceleration.normalized.x,-1,1) * _speed;
        var direction = new Vector2(xDirection, -2);
        _rigidbody2D.velocity = direction;
    }
}
