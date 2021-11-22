using System.Collections;
using UnityEngine;

public class SecondEnemyBot : EnemyBabyBotBase
{
    public static GameObject _seccondClosest;
    [SerializeField]
    private bool _testFlag;

    public override void Awake()
    {
        _botCollider = GetComponent<CapsuleCollider>();
        _rigibodyBot = GetComponent<Rigidbody>();
        _botAnim = GetComponent<Animator>();
        _freeCubesSecondBot.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
    }

    public override void Execute()
    {
        MoveBot();
    }

    public override GameObject FindClosestCube()
    {
        if (_freeCubesSecondBot.Count <= 0 || _goBotTarget)
        {
            _seccondClosest = _bottarget;

        }
        _minDistance = 10000f;
        for (int i = 0; i < _freeCubesSecondBot.Count; i++)
        {
            if (_minDistance > Vector3.Distance(gameObject.transform.position, _freeCubesSecondBot[i].transform.position))
            {
                _minDistance = Vector3.Distance(gameObject.transform.position, _freeCubesSecondBot[i].transform.position);
                _seccondClosest = _freeCubesSecondBot[i];

            }
        }
        return _closest;
    }

    public override void MoveBot()
    {
        if (!_isCryBot)
        {
            FindClosestCube();
            if (!_goBuildCastle && _freeCubes.Contains(_closest) == true)
            {
                transform.position = Vector3.MoveTowards(this.transform.position,
                            _closest.transform.position, _speed);
                RotateCubes();
            }
            if (_countCubesBot >= 6 || _freeCubes.Count <= 0)
            {
                _goBuildCastle = true;
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                             _bottarget.transform.position, _speed);
                RotateBotTarget();
            }
        }
        else
        {
            _rigibodyBot.velocity = new Vector3(0, 0, 0);
        }
    }

    public override void AnimBot()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void RotateBotTarget()
    {
        throw new System.NotImplementedException();
    }

    public override void RotateCubes()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator TimeCryBot()
    {
        throw new System.NotImplementedException();
    }
}
