using UnityEngine;

namespace Model
{
    public class SecondBotFront : MonoBehaviour
    {
        private SecondEnemyBot _secondEnemyBot;

        public SecondBotFront(SecondEnemyBot secondEnemyBot)
        {
            _secondEnemyBot = secondEnemyBot;
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "PlayerFront":
                    StartCoroutine(SecondEnemyBot.TimeIdleSecondBot());
                    Debug.Log($"SecondBotFront -> PlayerFront");
                    return;
                case "FirstBotFront":
                    StartCoroutine(SecondEnemyBot.TimeIdleSecondBot());
                    Debug.Log($"SecondBotFront -> FirstBotFront");
                    return;
                case "PlayerBack":
                    StartCoroutine(SecondEnemyBot.TimeClapSecondBot());
                    Debug.Log($"SecondBotFront -> PlayerBack");
                    return;
                case "FirstBotBack":
                    StartCoroutine(SecondEnemyBot.TimeClapSecondBot());
                    Debug.Log($"SecondBotFront -> FirstBotBack");
                    return;
            }
            
            /*if (other.CompareTag("PlayerFront") || other.CompareTag("FirstBotFront"))
            {
                StartCoroutine(SecondEnemyBot.TimeClapSecondBot());
                Debug.Log($"SecondBotFront -> PlayerFront || FirstBotFront");
            }
            
            if (other.CompareTag("PlayerBack") || other.CompareTag("FirstBotBack"))
            {
                StartCoroutine(SecondEnemyBot.TimeClapSecondBot());
                Debug.Log($"SecondBotFront -> PlayerBack || FirstBotBack");
            }*/
        }
    }
}