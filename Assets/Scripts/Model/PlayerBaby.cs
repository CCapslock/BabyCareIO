using System.Collections;
using UnityEngine;

public class PlayerBaby : PlayerBase
{
    private Rigidbody _rigidbodyBaby;
    private Animator _babyAnim;
    private static CapsuleCollider _collider;
    [SerializeField]
    private Joystick _joystick;
    

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbodyBaby = GetComponent<Rigidbody>();
        _babyAnim = GetComponent<Animator>();
        isIdle = true;
        isCry = false;
        isClap = false;
        isWalk = false;
    }
    public override void Move(float x, float y, float z)
    {
        _rigidbodyBaby.velocity = new Vector3(x, y, z) * _speed;  
    }
    public override void BabyAnim()
    {
        if (isIdle)
        {
            _babyAnim.SetBool("Clap", false);
            _babyAnim.SetBool("Walk", false);
            _babyAnim.SetBool("Cry", false);
            if (_joystick.Horizontal == 0 || _joystick.Vertical == 0)
                _babyAnim.SetBool("Idle", true);
        }
        
        if (isCry)
        {
            _babyAnim.SetBool("Idle", false);
            _babyAnim.SetBool("Clap", false);
            _babyAnim.SetBool("Walk", false);
            _babyAnim.SetBool("Cry", true);
        }

        if (isClap)
        {
            _babyAnim.SetBool("Idle", false);
            _babyAnim.SetBool("Clap", true);
            _babyAnim.SetBool("Walk", false);
            _babyAnim.SetBool("Cry",false);
        }

        if (!isWalk)
        {
            return;
        }
        _babyAnim.SetBool("Idle", false);
        _babyAnim.SetBool("Clap", false);
        _babyAnim.SetBool("Cry",false);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _babyAnim.SetBool("Walk", true);
        }
        
        /*if (!isCry)
        {
            _babyAnim.SetBool("Cry", false);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                _babyAnim.SetBool("Walk", true);
            }
            if (_joystick.Horizontal == 0 || _joystick.Vertical == 0)
                _babyAnim.SetBool("Walk", false);
        }
        if (isClap)
        {
            _babyAnim.SetBool("Clap", true);
            _babyAnim.SetBool("Walk", false);
            _babyAnim.SetBool("Cry",false);
        }
        else
        {
            _babyAnim.SetBool("Clap", false);
            _babyAnim.SetBool("Walk", false);
            _babyAnim.SetBool("Cry",false);
        }*/
    }

    public override void RotationMove()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbodyBaby.velocity);
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirstEnemyBabyBot")|| other.CompareTag("SecondEnemyBabyBot"))
        {
            StartCoroutine(TimeCry());
        }
    }*/
    public static IEnumerator TimeCry()
    {
        isIdle = false;
        isWalk = false;
        isCry = true;
        isClap =false;
        _collider.isTrigger = false;
        yield return new WaitForSeconds(3);
        isCry = false;
        yield return new WaitForSeconds(0.5f);
        _collider.isTrigger = true;
    }
    
    public static IEnumerator TimeClap()
    {
        isIdle = false;
        isWalk = false;
        isCry = false;
        isClap = true;
        _collider.isTrigger = false;
        yield return new WaitForSeconds(3);
        isClap = false;
        yield return new WaitForSeconds(0.5f);
        _collider.isTrigger = true;
    }
    
    public static IEnumerator TimeIdle()
    {
        isIdle = true;
        isWalk = false;
        isCry = false;
        isClap = false;
        _collider.isTrigger = false;
        yield return new WaitForSeconds(3);
        isIdle = false;
        yield return new WaitForSeconds(0.5f);
        _collider.isTrigger = true;
    }
}
