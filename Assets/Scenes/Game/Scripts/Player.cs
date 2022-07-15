using System;
using UnityEngine;
public class Player : MonoBehaviour
{
    public event Action OnLoseGame;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("triger");
        if(other.gameObject.CompareTag("Trap")) OnLoseGame?.Invoke();
    }
}
