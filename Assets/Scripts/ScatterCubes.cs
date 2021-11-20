using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterCubes : MonoBehaviour
{
    private Rigidbody _rigidbodyCube;
    
    void Awake()
    {
        _rigidbodyCube = GetComponent<Rigidbody>();
        
    }
    private  void ScatterCube()
    {
        if (EnemyBabyBotBase.isCryBot || PlayerBase.isCry)
        {
            StartCoroutine(Scatter());
        }
    }
    private void Update()
    {
        ScatterCube();
    }

    private IEnumerator Scatter()
    {
        _rigidbodyCube.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        _rigidbodyCube.constraints = RigidbodyConstraints.FreezeAll;
    }


}
