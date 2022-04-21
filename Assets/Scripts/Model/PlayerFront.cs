using UnityEngine;

namespace Model
{
    public class PlayerFront : MonoBehaviour
    {
        private PlayerBaby _playerBaby;

        public PlayerFront(PlayerBaby playerBaby)
        {
            _playerBaby = playerBaby;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FirstBotFront") || other.CompareTag("SecondBotFront"))
            {
                StartCoroutine(PlayerBaby.TimeClap());
                Debug.Log($"PlayerFront -> FirstBotFront || SecondBotFront");
            }
            
            if (other.CompareTag("FirstBotBack") || other.CompareTag("SecondBotBack"))
            {
                StartCoroutine(PlayerBaby.TimeClap());
                Debug.Log($"PlayerFront -> FirstBotBack || SecondBotBack");
            }
        }
    }
}