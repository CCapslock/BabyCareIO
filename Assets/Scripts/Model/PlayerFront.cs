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
            switch (other.tag)
            {
                case "FirstBotFront":
                    StartCoroutine(PlayerBaby.TimeIdle());
                    Debug.Log($"PlayerFront -> FirstBotFront");
                    return;
                case "SecondBotFront":
                    StartCoroutine(PlayerBaby.TimeIdle());
                    Debug.Log($"PlayerFront -> SecondBotFront");
                    return;
                case "FirstBotBack":
                    StartCoroutine(PlayerBaby.TimeClap());
                    Debug.Log($"PlayerFront -> FirstBotBack");
                    return;
                case "SecondBotBack":
                    StartCoroutine(PlayerBaby.TimeClap());
                    Debug.Log($"PlayerFront -> SecondBotBack");
                    return;
            }
            
            /*if (other.CompareTag("FirstBotFront") || other.CompareTag("SecondBotFront"))
            {
                StartCoroutine(PlayerBaby.TimeClap());
                Debug.Log($"PlayerFront -> FirstBotFront || SecondBotFront");
            }
            
            if (other.CompareTag("FirstBotBack") || other.CompareTag("SecondBotBack"))
            {
                StartCoroutine(PlayerBaby.TimeClap());
                Debug.Log($"PlayerFront -> FirstBotBack || SecondBotBack");
            }*/
        }
    }
}