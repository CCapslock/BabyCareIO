using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBabyBot : EnemyBabyBotBase
{   
    public static  List<GameObject> _freeCubes = new List<GameObject>();
    public static GameObject _closest;
    float min;
    [SerializeField]
    private GameObject _bottarget;



    private void Awake()
    {
        _freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
       
        
    }
    public override void MoveBot()
    {
        if (!_goBuildCastle)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                        FindClosestCube().transform.position, _speed);

        }

        if (_countCubesBot>=3)
        {
            _goBuildCastle = true;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                         _bottarget.transform.position, _speed);
        }
            
        
        
    }

    public override GameObject FindClosestCube()
    {
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
