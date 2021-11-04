using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBabyBotBase : MonoBehaviour
{
    public float _speed;
    public static int _countCubesBot;
    public static bool _goBuildCastle = false;
    public abstract void MoveBot();
    public abstract GameObject FindClosestCube();
   
}
