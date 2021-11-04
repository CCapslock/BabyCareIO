using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBabyBot : EnemyBabyBotBase
{
    private List<GameObject> _freeCubes = new List<GameObject>();
    private GameObject _closest;
    float _distance = Mathf.Infinity;


    private void Awake()
    {
        _freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
    }

    public override GameObject FindClosestCube()
    {
   
        foreach (var item in _freeCubes)
        {
            Vector3 diff = item.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance<_distance)
            {
                _closest = item;
                _distance = curDistance;
            }
        }
        return _closest;
    }
    public override void MoveBot()
    {
        if (_distance!=1)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, FindClosestCube().transform.position, _speed);
        }_freeCubes.Remove(_closest);
            
    }
}
