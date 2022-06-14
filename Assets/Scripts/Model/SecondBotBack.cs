using UnityEngine;

namespace Model
{
    public class SecondBotBack : MonoBehaviour
    {
        private SecondEnemyBot _secondEnemyBot;

        public SecondBotBack(SecondEnemyBot secondEnemyBot)
        {
            _secondEnemyBot = secondEnemyBot;
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "PlayerFront":
                    StartCoroutine(SecondEnemyBot.TimeCrySecondBot());
                    Debug.Log($"SecondBotBack -> PlayerFront");
                    return;
                case "FirstBotFront":
                    StartCoroutine(SecondEnemyBot.TimeCrySecondBot());
                    Debug.Log($"SecondBotBack -> FirstBotFront");
                    return;
                case "PlayerBack":
                    StartCoroutine(SecondEnemyBot.TimeIdleSecondBot());
                    Debug.Log($"SecondBotBack -> PlayerBack");
                    return;
                case "FirstBotBack":
                    StartCoroutine(SecondEnemyBot.TimeIdleSecondBot());
                    Debug.Log($"SecondBotBack -> FirstBotBack");
                    return;
            }
            
            /*if (other.CompareTag("PlayerFront") || other.CompareTag("FirstBotFront"))
            {
                StartCoroutine(SecondEnemyBot.TimeCrySecondBot());
                Debug.Log($"SecondBotBack -> PlayerFront || FirstBotFront");
            }

            if (other.CompareTag("PlayerBack") || other.CompareTag("FirstBotBack"))
            {
                StartCoroutine(SecondEnemyBot.TimeClapSecondBot());
                Debug.Log($"SecondBotBack -> PlayerBack || FirstBotBack");
            }*/
        }
    }
}