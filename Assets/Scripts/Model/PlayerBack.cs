using UnityEngine;

namespace Model
{
    public class PlayerBack : MonoBehaviour
    {
        private PlayerBaby _playerBaby;

        public PlayerBack(PlayerBaby playerBaby)
        {
            _playerBaby = playerBaby;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FirstBotFront") || other.CompareTag("SecondBotFront"))
            {
                StartCoroutine(PlayerBaby.TimeCry());
                Debug.Log($"PlayerBack -> FirstBotFront || SecondBotFront");
            }

            if (other.CompareTag("FirstBotBack") || other.CompareTag("SecondBotBack"))
            {
                StartCoroutine(PlayerBaby.TimeClap());
                Debug.Log($"PlayerBack -> FirstBotBack || SecondBotBack");
            }
        }
    }
}