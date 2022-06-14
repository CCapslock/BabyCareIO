using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBabyBot : EnemyBabyBotBase
{
    
    [SerializeField]
    private bool _testFlag;
    private NavMeshAgent _agent;
    
    public override void Awake()
    {
        _botCollider = GetComponent<CapsuleCollider>();
        _rigibodyBot = GetComponent<Rigidbody>();
        _freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
        _botAnim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        isIdle = true;
        isCry = false;
        isClap = false;
        isWalk = false;
    }

    public override void Execute()
    {
        if (_testFlag)
        {
            MoveBot();

            AnimBot();
        }
    }
    public override void MoveBot()
    {
        if (!isCry)
        {
            _agent.isStopped = false;
            FindClosestCube();
            if (!_goBuildCastle && _freeCubes.Contains(_closest) == true)
            {
                _agent.destination = _closest.transform.position;
                RotateCubes();
            }
            if (_countCubesBot >= 6 || _goBotTarget)
            {
                _goBuildCastle = true;
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
    }
    
    /*public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("SecondEnemyBabyBot"))
        {
            StartCoroutine(TimeCryBot());
        }
    }*/

    public static IEnumerator TimeCryBot()
    {
        isIdle = false;
        isWalk = false;
        isCry = true;
        isClap =false;
        _botCollider.isTrigger = false;
        _goBuildCastle = false;
        yield return new WaitForSeconds(_timeCry);
        isCry = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
    }
    
    public static IEnumerator TimeClapBot()
    {
        isIdle = false;
        isWalk = false;
        isCry = false;
        isClap = true;
        _botCollider.isTrigger = false;
        yield return new WaitForSeconds(_timeCry);
        isClap = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
    }
    
    public static IEnumerator TimeIdleBot()
    {
        isIdle = true;
        isWalk = false;
        isCry = false;
        isClap = false;
        _botCollider.isTrigger = false;
        yield return new WaitForSeconds(_timeCry);
        isIdle = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
    }
    
    public override void RotateBotTarget()
    {
        transform.LookAt(_bottarget.transform.position);
    }
    public override void RotateCubes()
    {
        transform.LookAt(_closest.transform.position);
    }
    public override GameObject FindClosestCube()
    {

        if ( _goBotTarget)
        {
            _closest = _bottarget;
        }
        else
        {
            _minDistance = 10000f;
            for (int i = 0; i < _freeCubes.Count; i++)
            {
                if (_minDistance > Vector3.Distance(gameObject.transform.position, _freeCubes[i].transform.position))
                {
                    _minDistance = Vector3.Distance(gameObject.transform.position, _freeCubes[i].transform.position);
                    _closest = _freeCubes[i];
                }
            }
        }
        return _closest;
    }

    public override void SecondExecute()
    {
        
    }
}
