using UnityEngine;

public abstract class EnemyBabyBotBase : MonoBehaviour
{
    public float _speed;
    public static bool isCryBot = false;
    public static int _countCubesBot;
    public static int _countCubesInCastel;
    public static bool _goBotTarget = false;
    public static bool _goBuildCastle = false;
    public abstract void MoveBot();
    public abstract GameObject FindClosestCube();
   
}
