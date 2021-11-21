using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBabyBot : EnemyBabyBotBase
{
    public static List<GameObject> _freeCubes = new List<GameObject>();
    public  GameObject _closest;
    private Rigidbody _rigibodyBot;
    private CapsuleCollider _botCollider;
    private Animator _botAnim;
    private float _timeCry = 3;
    public bool _testFlag;
    float min;
    [SerializeField]
    private GameObject _bottarget;

    private void Awake()
    {
        _botCollider = GetComponent<CapsuleCollider>();
        _rigibodyBot = GetComponent<Rigidbody>();
        _freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
        _botAnim = GetComponent<Animator>();
    }
    public override void MoveBot()
    {
        if (_testFlag)
        {
            if (!isCryBot)
            {
                FindClosestCube();
                if (!_goBuildCastle && _freeCubes.Contains(_closest) == true)
                {   
                        transform.position = Vector3.MoveTowards(this.transform.position,
                                    FindClosestCube().transform.position, _speed);
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

            AnimBot();
        }
    }
    private void AnimBot()
    {
        if (!isCryBot)
        {
            _botAnim.SetBool("Walk", true);
        }
        else
        {
            _botAnim.SetBool("Walk", false);
            _botAnim.SetBool("Cry", true);
        }
        
       
        if (_freeCubes.Count <= 0 && this.transform.position == _bottarget.transform.position)
        {
            this.transform.Rotate(Vector3.up);
            _botAnim.SetBool("Clap", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TimeCryBot());
        }
    }

    private  IEnumerator TimeCryBot()
    {
        isCryBot = true;
        _botCollider.isTrigger = false;
        Debug.Log("BotCry");
        yield return new WaitForSeconds(_timeCry);
        isCryBot = false;
        yield return new WaitForSeconds(0.5f);
        _botCollider.isTrigger = true;
    }
    private void RotateBotTarget()
    {
        transform.LookAt(_bottarget.transform.position);
    }
    private void RotateCubes()
    {
        transform.LookAt(_closest.transform.position);
    }
    public override GameObject FindClosestCube()
    {

        if (_freeCubes.Count <= 0 || _goBotTarget)
        {
            _closest = _bottarget;

        }
            min = 10000f;
            for (int i = 0; i < _freeCubes.Count; i++)
            {
                if (min > Vector3.Distance(gameObject.transform.position, _freeCubes[i].transform.position))
                {
                    min = Vector3.Distance(gameObject.transform.position, _freeCubes[i].transform.position);
                    _closest = _freeCubes[i];

                }
            }
        return _closest;
    }
}
