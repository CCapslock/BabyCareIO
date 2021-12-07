using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SecondEnemyBot : EnemyBabyBotBase
{
    
    [SerializeField]
    private bool _testFlag;
    private NavMeshAgent _agent;
    public override void Awake()
    {
        
    }
    private void Start()
    {
        _botCollider = GetComponent<CapsuleCollider>();
        _rigibodyBot = GetComponent<Rigidbody>();
        _botAnim = GetComponent<Animator>();
        _freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
        _agent = GetComponent<NavMeshAgent>();
        StartPoint();
    }

    public override void SecondExecute()
    {
        if (_testFlag)
        {
            MoveBot();
            AnimBot();
           
        }
    }

    public override GameObject FindClosestCube()
    {
        if (_goBotTargetSecondBot)
        {
            _seccondClosest = _startPointBot;

        }
        _minDistance = 10000f;
        for (int i = 0; i < _freeCubes.Count; i++)
        {
            if (_freeCubes[i]!=null)
            {
                if (_minDistance > Vector3.Distance(gameObject.transform.position, _freeCubes[i].transform.position))
                {
                    _minDistance = Vector3.Distance(gameObject.transform.position, _freeCubes[i].transform.position);
                    _seccondClosest = _freeCubes[i];
                }
            }
            
        }
        return _seccondClosest;
    }

    public override void MoveBot()
    {
        if (!_isCrySecondBot)
        {
            _agent.isStopped = false;
            FindClosestCube();
            if (!_goBuildCastleSecondBot && _freeCubes.Contains(_seccondClosest) == true)
            {
                _agent.destination = _seccondClosest.transform.position;
                RotateCubes();
            }
            if (_countCubesSecondBot >= 6 ||_goBotTargetSecondBot)
            {
                _goBuildCastleSecondBot = true;
                _agent.destination = _startPointBot.transform.position;
                RotateBotTarget();
            }
        }
        else
        {
            _agent.isStopped = true;
        }
    }

    public override void AnimBot()
    {
        if (!_isCrySecondBot)
        {
            _botAnim.SetBool("Walk", true);
        }
        else
        {
            _botAnim.SetBool("Walk", false);
            _botAnim.SetBool("Cry", true);
        }

        if (_goBotTargetSecondBot && _castleBuiltSecondBot)
        {
            transform.Rotate(Vector3.up);
            _botAnim.SetBool("Clap", true);
            _agent.isStopped = true;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("FirstEnemyBabyBot"))
        {
            StartCoroutine(TimeCryBot());
        }
    }

    public override void RotateBotTarget()
    {
        transform.LookAt(_startPointBot.transform.position);
    }
    public override void RotateCubes()
    {
        transform.LookAt(_seccondClosest.transform.position);
    }

    public override IEnumerator TimeCryBot()
    {
        _isCrySecondBot = true;
        _botCollider.isTrigger = false;
        _goBuildCastleSecondBot = false;
        yield return new WaitForSeconds(_timeCry);
        _isCrySecondBot = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
    }

    public override void Execute()
    {
        
    }

    public override void StartPoint()
    {
        transform.position = _startPointBot.transform.position;
    }
}
