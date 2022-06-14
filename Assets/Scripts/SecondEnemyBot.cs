using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SecondEnemyBot : EnemyBabyBotBase
{
    
    [SerializeField]
    private bool _testFlag;
    private static NavMeshAgent _agent;
    public override void Awake()
    {
        _botCollider = GetComponent<CapsuleCollider>();
        _rigibodyBot = GetComponent<Rigidbody>();
        _botAnim = GetComponent<Animator>();
        _freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
        _agent = GetComponent<NavMeshAgent>();
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
            _seccondClosest = _bottarget;
        }
        _minDistance = 10000f;
        for (int i = 0; i < _freeCubes.Count; i++)
        {
            if (_minDistance > Vector3.Distance(gameObject.transform.position, _freeCubes[i].transform.position))
            {
                _minDistance = Vector3.Distance(gameObject.transform.position, _freeCubes[i].transform.position);
                _seccondClosest = _freeCubes[i];
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
            if (_countCubesSecondBot >= 6 || _goBotTargetSecondBot)
            {
                _goBuildCastleSecondBot = true;
                _agent.destination = _bottarget.transform.position;
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
        if (isIdle)
        {
            _botAnim.SetBool("Idle", true);
            _botAnim.SetBool("Clap", false);
            _botAnim.SetBool("Walk", false);
            _botAnim.SetBool("Cry", false);
        }
        
        if (isCry)
        {
            _botAnim.SetBool("Idle", false);
            _botAnim.SetBool("Clap", false);
            _botAnim.SetBool("Walk", false);
            _botAnim.SetBool("Cry", true);
        }

        if (isClap)
        {
            _botAnim.SetBool("Idle", false);
            _botAnim.SetBool("Clap", true);
            _botAnim.SetBool("Walk", false);
            _botAnim.SetBool("Cry",false);
        }

        if (isWalk)
        {
            _botAnim.SetBool("Idle", false);
            _botAnim.SetBool("Clap", false);
            _botAnim.SetBool("Cry",false);
            _botAnim.SetBool("Walk", true);
        }

        if (_goBotTargetSecondBot && _castleBuiltSecondBot)
        {
            transform.Rotate(Vector3.up);
            _botAnim.SetBool("Clap", true);
            _agent.isStopped = true;
        }
    }

    /*public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("FirstEnemyBabyBot"))
        {
            StartCoroutine(TimeCryBot());
        }
    }*/

    public override void RotateBotTarget()
    {
        transform.LookAt(_bottarget.transform.position);
    }
    public override void RotateCubes()
    {
        transform.LookAt(_seccondClosest.transform.position);
    }

    public static IEnumerator TimeCrySecondBot()
    {
        _isCrySecondBot = true;
        _botCollider.isTrigger = false;
        _goBuildCastleSecondBot = false;
        _agent.isStopped = true;
        yield return new WaitForSeconds(3);
        _isCrySecondBot = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
        _agent.isStopped = false;
    }
    
    public static IEnumerator TimeClapSecondBot()
    {
        isClap = true;
        _botCollider.isTrigger = false;
        _agent.isStopped = true;
        yield return new WaitForSeconds(_timeCry);
        isClap = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
        _agent.isStopped = false;
    }
    
    public static IEnumerator TimeIdleSecondBot()
    {
        isClap = true;
        _botCollider.isTrigger = false;
        _agent.isStopped = true;
        yield return new WaitForSeconds(_timeCry);
        isClap = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
        _agent.isStopped = false;
    }

    public override void Execute()
    {
        
    }
}
