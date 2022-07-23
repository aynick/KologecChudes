using UnityEngine;
public class PlayerMoveState :  IPlayerBehavior
{
    private PlayerRotate _playerRotate;

    public PlayerMoveState(PlayerRotate playerRotate)
    {
        _playerRotate = playerRotate;
    }
    public void Enter()
    {
        _playerRotate.SetIsMove(true);
    }

    public void Exit()
    {
        _playerRotate.SetIsMove(false);    
    }

    public void Update()
    {
        _playerRotate.Move();
    }
}