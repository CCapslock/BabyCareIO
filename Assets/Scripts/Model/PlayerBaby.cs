using System.Collections;
using UnityEngine;

public class PlayerBaby : PlayerBase
{
    private Rigidbody _rigidbodyBaby;
    private Animator _babyAnim;
    private CapsuleCollider _collider;
    [SerializeField]
    private Joystick _joystick;
    

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbodyBaby = GetComponent<Rigidbody>();
        _babyAnim = GetComponent<Animator>();
    }
    public override void Move(float x, float y, float z)
    {
        _rigidbodyBaby.velocity = new Vector3(x, y, z) * _speed;  
    }
    public override void BabyAnim()
    {
        if (!isCry)
        {
            _babyAnim.SetBool("Cry", false);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                _babyAnim.SetBool("Walk", true);
            }
            if (_joystick.Horizontal == 0 || _joystick.Vertical == 0)
                _babyAnim.SetBool("Walk", false);
        }
        else
        {
            _babyAnim.SetBool("Walk", false);
            _babyAnim.SetBool("Cry",true);
        }
    }

    public override void RotationMove()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbodyBaby.velocity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FirstEnemyBabyBot")|| other.CompareTag("SecondEnemyBabyBot"))
        {
            StartCoroutine(TimeCry());
        }
    }
    private IEnumerator TimeCry()
    {
        isCry = true;
        _collider.isTrigger = false;
        yield return new WaitForSeconds(3);
        isCry = false;
        yield return new WaitForSeconds(0.5f);
        _collider.isTrigger = true;
    }
}
