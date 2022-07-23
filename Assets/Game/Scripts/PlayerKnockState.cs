using Game.Scripts;
using UnityEngine;
public class PlayerKnockState : IPlayerBehavior
{
    private PlayerKnock _playerKnock;

    public PlayerKnockState(PlayerKnock playerKnock)
    {
        _playerKnock = playerKnock;
    }
    public void Enter()
    {
        _playerKnock.SetIsKnock(true);
    }

    public void Exit()
    {
        _playerKnock.SetIsKnock(false);
        _playerKnock.ResetRotate();
    }

    public void Update()
    {
        _playerKnock.Knock();
    }
}