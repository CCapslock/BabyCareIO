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
            switch (other.tag)
            {
                case "PlayerFront":
                    StartCoroutine(EnemyBabyBot.TimeIdleBot());
                    Debug.Log($"FirstBotFront -> PlayerFront");
                    return;
                case "SecondBotFront":
                    StartCoroutine(EnemyBabyBot.TimeIdleBot());
                    Debug.Log($"FirstBotFront -> SecondBotFront");
                    return;
                case "PlayerBack":
                    StartCoroutine(EnemyBabyBot.TimeClapBot());
                    Debug.Log($"FirstBotFront -> PlayerBack");
                    return;
                case "SecondBotBack":
                    StartCoroutine(EnemyBabyBot.TimeClapBot());
                    Debug.Log($"FirstBotFront -> SecondBotBack");
                    return;
            }
            
            /*if (other.CompareTag("PlayerFront") || other.CompareTag("SecondBotFront"))
            {
                StartCoroutine(EnemyBabyBot.TimeClapBot());
                Debug.Log($"PlayerBack -> FirstBot front");
            }

            if (other.CompareTag("PlayerBack") || other.CompareTag("SecondBotBack"))
            {
                StartCoroutine(EnemyBabyBot.TimeClapBot());
                Debug.Log($"PlayerBack -> FirstBot back");
            }*/
        }
    }
}