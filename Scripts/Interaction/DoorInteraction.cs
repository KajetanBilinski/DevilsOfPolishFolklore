using System;
using UnityEngine;

namespace Interaction
{
    public class DoorInteraction : Interaction
    {
        
        private SpriteRenderer _spriteRenderer;

        public void Start()
        {
            gameObject.GetComponent<SpriteRenderer>();
        }

        public override void Use()
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
        }
    }
}