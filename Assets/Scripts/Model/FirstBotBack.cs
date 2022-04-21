using UnityEngine;

namespace Model
{
    public class FirstBotBack : MonoBehaviour
    {
        private EnemyBabyBot _enemyBabyBot;

        public FirstBotBack(EnemyBabyBot enemyBabyBot)
        {
            _enemyBabyBot = enemyBabyBot;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerFront") || other.CompareTag("SecondBotFront"))
            {
                StartCoroutine(EnemyBabyBot.TimeCryBot());
                Debug.Log($"FirstBot front -> PlayerFront || SecondBotFront");
            }

            if (other.CompareTag("PlayerBack") || other.CompareTag("SecondBotBack"))
            {
                StartCoroutine(EnemyBabyBot.TimeClapBot());
                Debug.Log($"SecondBotFront -> PlayerBack || SecondBotBack");
            }
        }
    }
}