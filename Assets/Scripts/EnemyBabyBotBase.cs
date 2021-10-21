using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBabyBotBase : MonoBehaviour
{
    public float _speed;
    public abstract void MoveBot();
    public abstract GameObject FindClosestCube();
}
