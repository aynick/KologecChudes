using System;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerKnock : MonoBehaviour
    {
        private bool _isKnock;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetIsKnock(bool isKnock)
        {
            _isKnock = isKnock;
        }

        public void ResetRotate()
        {
            transform.localRotation = Quaternion.identity;
        }
        
        public void Knock()
        {
            if (!_isKnock) return;
            var knockDir = new Vector2(_rigidbody2D.velocity.x, -2);
            _rigidbody2D.velocity = knockDir;
        }
    }
}