using System;
using UnityEngine;

namespace Interaction
{
    public class Interaction : MonoBehaviour
    {

        [SerializeField] private SpriteRenderer highLight;
        public virtual void Use()
        {
            highLight.enabled = true;
        }

        public void TurnOff()
        {
            highLight.enabled = false;
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (gameObject.CompareTag("Player"))
            {
                Use();
            }
            if (Input.GetButtonDown("Interact") && gameObject.CompareTag("Player"))
            {
                Debug.Log("Used");                
            }
        }

        private void OnTriggerStay2D(Collider2D col) => OnTriggerEnter2D(col);

        private void OnTriggerExit2D(Collider2D col)
        {
            TurnOff();
        }
    }
}