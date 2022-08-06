using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Interaction
{
    public class DoorInteraction : MonoBehaviour
    {
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SpriteRenderer _highLight;
        [SerializeField] private PolygonCollider2D _polygonCollider2D;
        private bool _inTrigger;
        private bool _isDoorOpen;


        private void Start()
        {
            _inTrigger=false;
            _isDoorOpen=false;
        }

        private void Update()
        {
            if (_inTrigger && Input.GetButtonDown("Interact"))
            {
                UseDoor();
            }

            if (_isDoorOpen)
            {
                _highLight.enabled = false;
            }
        }

        private void UseDoor()
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
            _polygonCollider2D.enabled = !_polygonCollider2D.enabled;
            _isDoorOpen = !_isDoorOpen;
            if(!_isDoorOpen)
                _highLight.enabled = true;
        }
        
        public void SwitchHighLight()
        {
            if(!_isDoorOpen)
                _highLight.enabled = !_highLight.enabled;
        }
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            
            if (col.gameObject.CompareTag("Player"))
            {
                SwitchHighLight();
                _inTrigger = true;
            }
        }
        
        public void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                SwitchHighLight();
                _inTrigger = false;
            }
        }
       
    }
}