using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IExecute
{
    public static bool _isPlayerTakeCube = true;
    public static bool _isFirstBotTakeCube = true;
    public static bool _isSecondBotTakeCube = true;
    

    protected abstract void PlayerTakesCube();
    protected abstract void PlayerBuildCastle();
    protected abstract void FirstBotTakesCube();
    protected abstract void FirstBotBuildCastle();
    protected abstract void SecondBotTakesCube();
    protected abstract void SecondBotBuildCastle();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isPlayerTakeCube)
            {
                return;
            }
            PlayerTakesCube();
        }
        else if (other.CompareTag("PlacePlayer"))
        {
            PlayerBuildCastle();
        }
        else if (other.CompareTag("FirstEnemyBabyBot"))
        {
            if (!_isFirstBotTakeCube)
            {
                return;
            }
            FirstBotTakesCube();
        }
        else if (other.CompareTag("PlaceFirstBot"))
        {
            FirstBotBuildCastle();
        }
        else if (other.CompareTag("SecondEnemyBabyBot"))
        {
            if (!_isSecondBotTakeCube)
            {
                return;
            }
            SecondBotTakesCube();
        }
        else if (other.CompareTag("PlaceSecondBot"))
        {
            SecondBotBuildCastle();
        }
    }
    public abstract void Execute();

}
