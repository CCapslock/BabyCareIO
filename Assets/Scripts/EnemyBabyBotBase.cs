using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBabyBotBase : MonoBehaviour, IExecute
{
    public float _speed;
    public static bool _isCryBot = false;
    public static bool _isCrySecondBot = false;
    public static int _countCubesBot;
    public static int _countCubesSecondBot;
    public static bool _goBotTarget = false;
    public static bool _goBuildCastle = false;
    public static bool _goBuildCastleSecondBot = false;
    public float _minDistance;
    public Rigidbody _rigibodyBot;
    public CapsuleCollider _botCollider;
    public Animator _botAnim;
    public static GameObject _closest;

    public static List<GameObject> _freeCubes = new List<GameObject>();
    public static List<GameObject> _freeCubesSecondBot = new List<GameObject>();


    public GameObject _bottarget;

    
    public float _timeCry = 3;


    public abstract void Awake();
    public abstract void MoveBot();
    public abstract void AnimBot();
    public abstract void OnTriggerEnter(Collider other);
    public abstract IEnumerator TimeCryBot();
    public abstract GameObject FindClosestCube();
    public abstract void RotateBotTarget();
    public abstract void RotateCubes();

    public abstract void Execute();
    
}


