using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBabyBotBase : MonoBehaviour, IExecute
{
 
    public  bool _isCryBot = false;
    public int _countCubesBot;
    public bool _goBotTarget = false;
    public bool _castleBuilt = false;
    public bool _goBuildCastle = false;
    public GameObject _closest;

    public  bool _isCrySecondBot = false;
    public  int _countCubesSecondBot;
    public  bool _castleBuiltSecondBot = false;
    public  bool _goBotTargetSecondBot = false;
    public  bool _goBuildCastleSecondBot = false;
    public GameObject _seccondClosest;


    public float _minDistance;
    public float _timeCry = 3;

    public Rigidbody _rigibodyBot;
    public CapsuleCollider _botCollider;
    public Animator _botAnim;
    public GameObject _startPointBot;



    public static List<GameObject> _freeCubes = new List<GameObject>();


    public abstract void Awake();
    public abstract void MoveBot();
    public abstract void AnimBot();
    public abstract void OnTriggerEnter(Collider other);
    public abstract IEnumerator TimeCryBot();
    public abstract GameObject FindClosestCube();
    public abstract void RotateBotTarget();
    public abstract void RotateCubes();

    public abstract void Execute();
    public abstract void SecondExecute();
    public abstract void StartPoint();


}


