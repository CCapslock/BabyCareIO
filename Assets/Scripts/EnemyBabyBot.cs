using System.Collections;
using UnityEngine;

public class EnemyBabyBot : EnemyBabyBotBase
{
    
    [SerializeField]
    private bool _testFlag;
    
    public override void Awake()
    {
        _botCollider = GetComponent<CapsuleCollider>();
        _rigibodyBot = GetComponent<Rigidbody>();
        _freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
        _botAnim = GetComponent<Animator>();
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
            if (!_isCryBot)
            {
                FindClosestCube();
                if (!_goBuildCastle && _freeCubes.Contains(_closest) == true)
                {   
                        transform.position = Vector3.MoveTowards(this.transform.position,
                                    _closest.transform.position, _speed);
                        RotateCubes();
                }
                if (_countCubesBot >= 6 || _goBotTarget)
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
        if (!_isCryBot)
        {
            _botAnim.SetBool("Walk", true);
        }
        else
        {
            _botAnim.SetBool("Walk", false);
            _botAnim.SetBool("Cry", true);
        }
        
        if (_goBotTarget && transform.position == _bottarget.transform.position)
        {
            transform.Rotate(Vector3.up);
            _botAnim.SetBool("Clap", true);
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("SecondEnemyBabyBot"))
        {
            StartCoroutine(TimeCryBot());
        }
    }

    public override IEnumerator TimeCryBot()
    {
        _isCryBot = true;
        _botCollider.isTrigger = false;
        _goBuildCastle = false;
        Debug.Log("BotCry");
        yield return new WaitForSeconds(_timeCry);
        _isCryBot = false;
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
