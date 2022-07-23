using System;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;
public class Player : MonoBehaviour
{
    public event Action OnLoseGame;
    private Dictionary<Type, IPlayerBehavior> _playerBehaviors;
    private IPlayerBehavior _currentBehavior;
    [SerializeField]private PlayerKnock _playerKnock;
    [SerializeField]private PlayerRotate _playerRotate;
    [SerializeField]private int healthPoint;

    private void Start()
    {
        InitBehaviors();
        SetBehaviorByDefault();
    }

    private void FixedUpdate()
    {
        _currentBehavior.Update();
    }

    void InitBehaviors()
    {
        _playerBehaviors = new Dictionary<Type, IPlayerBehavior>();
        _playerBehaviors[typeof(PlayerKnockState)] = new PlayerKnockState(_playerKnock);
        _playerBehaviors[typeof(PlayerMoveState)] = new PlayerMoveState(_playerRotate);
    }

    void SetBehavior(IPlayerBehavior newBehavior)
    {
        if(_currentBehavior != null) _currentBehavior.Exit();
        _currentBehavior = newBehavior;
        _currentBehavior.Enter();
    }

    void SetBehaviorByDefault()
    {
        SetBehavior(GetBehavior<PlayerMoveState>());
    }

    IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior
    {
        return _playerBehaviors[typeof(T)];
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Trap"))
        {
            healthPoint--;
            SetBehavior(GetBehavior<PlayerKnockState>());
            Invoke("SetMoveBehavior", 2f);
            if ((healthPoint) <= 0)
            {
                OnLoseGame?.Invoke();
            }

        }
    }

    void SetMoveBehavior()
    {
        SetBehavior(GetBehavior<PlayerMoveState>());
    }
}
