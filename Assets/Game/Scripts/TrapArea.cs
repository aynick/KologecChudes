using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapArea : MonoBehaviour
{
    [SerializeField] private TrapGenerator _trapGenerator;
    [SerializeField] private float _speed;
    [SerializeField] private float _decrementStep;
    private float _coolDown;
    private void FixedUpdate()
    {
       MoveArea();
       IncrementSpeed();
    }

    private void MoveArea()
    {
        transform.Translate(Vector3.up * ( _speed * Time.fixedDeltaTime));
    }

    private void IncrementSpeed()
    {
        if (_coolDown <= 0)
        {
            _speed += Time.fixedDeltaTime;
            _coolDown = _decrementStep;
        }
        _coolDown -= Time.fixedDeltaTime;
    }
}
