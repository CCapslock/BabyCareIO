using UnityEngine;

namespace Model
{
    public class FirstBotFront : MonoBehaviour
    {
        private EnemyBabyBot _enemyBabyBot;

        public FirstBotFront(EnemyBabyBot enemyBabyBot)
        {
            _enemyBabyBot = enemyBabyBot;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerFront") || other.CompareTag("SecondBotFront"))
            {
                StartCoroutine(EnemyBabyBot.TimeClapBot());
                Debug.Log($"PlayerBack -> FirstBot front");
            }

            if (other.CompareTag("PlayerBack") || other.CompareTag("SecondBotBack"))
            {
                StartCoroutine(EnemyBabyBot.TimeClapBot());
                Debug.Log($"PlayerBack -> FirstBot back");
            }
        }
    }
}