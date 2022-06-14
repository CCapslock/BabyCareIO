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
            switch (other.tag)
            {
                case "PlayerFront":
                    StartCoroutine(EnemyBabyBot.TimeCryBot());
                    Debug.Log($"FirstBotBack -> PlayerFront");
                    return;
                case "SecondBotFront":
                    StartCoroutine(EnemyBabyBot.TimeCryBot());
                    Debug.Log($"FirstBotBack -> SecondBotFront");
                    return;
                case "PlayerBack":
                    StartCoroutine(EnemyBabyBot.TimeIdleBot());
                    Debug.Log($"FirstBotBack -> PlayerBack");
                    return;
                case "SecondBotBack":
                    StartCoroutine(EnemyBabyBot.TimeIdleBot());
                    Debug.Log($"FirstBotBack -> SecondBotBack");
                    return;
            }
            
            /*if (other.CompareTag("PlayerFront") || other.CompareTag("SecondBotFront"))
            {
                StartCoroutine(EnemyBabyBot.TimeCryBot());
                Debug.Log($"FirstBot front -> PlayerFront || SecondBotFront");
            }

            if (other.CompareTag("PlayerBack") || other.CompareTag("SecondBotBack"))
            {
                StartCoroutine(EnemyBabyBot.TimeClapBot());
                Debug.Log($"SecondBotFront -> PlayerBack || SecondBotBack");
            }*/
        }
    }
}