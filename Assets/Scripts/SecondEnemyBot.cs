using System.Collections;
using UnityEngine;

public class SecondEnemyBot : EnemyBabyBotBase
{
    
    [SerializeField]
    private bool _testFlag;

    public override void Awake()
    {
        _botCollider = GetComponent<CapsuleCollider>();
        _rigibodyBot = GetComponent<Rigidbody>();
        _botAnim = GetComponent<Animator>();
        _freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
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
            FindClosestCube();
            if (!_goBuildCastleSecondBot && _freeCubes.Contains(_seccondClosest) == true)
            {
                transform.position = Vector3.MoveTowards(this.transform.position,
                            _seccondClosest.transform.position, _speed);
                RotateCubes();
            }
            if (_countCubesSecondBot >= 6 ||_goBotTargetSecondBot)
            {
                _goBuildCastleSecondBot = true;
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
        if (!_isCrySecondBot)
        {
            _botAnim.SetBool("Walk", true);
        }
        else
        {
            _botAnim.SetBool("Walk", false);
            _botAnim.SetBool("Cry", true);
        }

        if (_goBotTargetSecondBot && transform.position == _bottarget.transform.position)
        {
            this.transform.Rotate(Vector3.up);
            _botAnim.SetBool("Clap", true);
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
        transform.LookAt(_bottarget.transform.position);
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
        Debug.Log("BotCry");
        yield return new WaitForSeconds(_timeCry);
        _isCrySecondBot = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
    }

    public override void Execute()
    {
        
    }
}
