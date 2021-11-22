﻿using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Cube : InteractiveObject
{
    private List<GameObject> PlaceCube = new List<GameObject>();
    private List<GameObject> PlaceCastle = new List<GameObject>();
    private List<GameObject> CastleCube = new List<GameObject>();
    private List<GameObject>  CubeScatterPlayer = new List<GameObject>();

    private List<GameObject> PlaceCubeBot = new List<GameObject>();
    private List<GameObject> PlaceCastleBot = new List<GameObject>();
    private List<GameObject> CastleCubeBot = new List<GameObject>();
    private List<GameObject>  CubeScatterBot = new List<GameObject>();

    private List<GameObject> PlaceCubeSecondBot = new List<GameObject>();
    private List<GameObject> PlaceCastleSecondBot = new List<GameObject>();
    private List<GameObject> CastleCubeSecondBot = new List<GameObject>();
    private List<GameObject> CubeScatterSecondBot = new List<GameObject>();


    private GameObject _playerBaby;
    private GameObject _babyBot;
    private GameObject _babySecondBot;
    private GameObject _cubes;
    private GameObject _cubesFirstBot;
    private GameObject _cubesSecondBot;
    private GameObject _freeCubes;

    private Rigidbody _rigidbodyCubes;

    private bool isCube = false;
    private bool isCubeBot = false;
    private bool _botHaveCube = false;
    private bool _playerHaveCube = false;
    private bool _secondBotHaveCube = false;
    private float _speedFlyCube = 0.02f;





    private void Awake()
    {
        PlaceCube.AddRange(GameObject.FindGameObjectsWithTag("PlaceCube"));
        PlaceCastle.AddRange(GameObject.FindGameObjectsWithTag("PlaceCastle"));
        PlaceCubeBot.AddRange(GameObject.FindGameObjectsWithTag("PlaceCubeFirstBot"));
        PlaceCastleBot.AddRange(GameObject.FindGameObjectsWithTag("PlaceCastleFirstBot"));
        PlaceCubeSecondBot.AddRange(GameObject.FindGameObjectsWithTag("PlaceCubeSecondBot"));
        PlaceCastleSecondBot.AddRange(GameObject.FindGameObjectsWithTag("PlaceCastleSecondBot"));
        _playerBaby = GameObject.Find("Cubes");
        _babyBot = GameObject.Find("CubesBot");
        _babySecondBot = GameObject.Find("CubesSecondBot");
        _cubes = GameObject.Find("PlaceCastle");
        _cubesFirstBot = GameObject.Find("PlaceCastleCubefirstBot");
        _cubesSecondBot = GameObject.Find("PlaceCastleSecondBot");
        _freeCubes = GameObject.Find("FreeCubes");
        _rigidbodyCubes = GetComponent<Rigidbody>();
    }
    public override void Execute()
    {
        if (CastleCube.Count == PlaceCastle.Count)
        {
            _isPlayerTakeCube = false;
        }
        if (CastleCubeBot.Count == PlaceCastleBot.Count)
        {
            EnemyBabyBotBase._freeCubes.Clear();
            _isFirstBotTakeCube = false;

        }
        if (isCube == true)
        {
            MoveCubesPlayer();
        }
        if (isCubeBot == true)
        {
            MoveCubesFirstBot();
        }
        if (CubeScatterBot.Contains(EnemyBabyBotBase._closest))
        {
            EnemyBabyBotBase._freeCubes.Remove(EnemyBabyBotBase._closest);
        }
        if (CubeScatterSecondBot.Contains(EnemyBabyBotBase._seccondClosest))
        {
            EnemyBabyBotBase._freeCubes.Remove(EnemyBabyBotBase._seccondClosest);
        }
        if (PlayerBase.isCry)
        {
            ScatterPlayeer();
        }
        if (EnemyBabyBotBase._isCryBot)
        {
            ScatterBot();
        }
    }
    protected override void PlayerTakesCube()
    {
        if (_botHaveCube||_playerHaveCube)
        {
            return;
        }
        else
        {
            CubeScatterPlayer.Clear();
            _rigidbodyCubes.constraints = RigidbodyConstraints.FreezeAll;
            _playerHaveCube = true;
            EnemyBabyBotBase._freeCubes.Remove(gameObject);
            transform.rotation = _playerBaby.transform.rotation;
            PlayerBase._countCube++;
            gameObject.transform.tag = "Cube";
            gameObject.transform.SetParent(_playerBaby.transform);
            CastleCube.AddRange(GameObject.FindGameObjectsWithTag("Cube"));
            for (int i = 0; i < _playerBaby.transform.childCount; i++)
            {
                CubeScatterPlayer.Add(_playerBaby.transform.GetChild(i).gameObject);
            }
            gameObject.transform.position = PlaceCube[PlayerBase._countCube].transform.position;
            
        }
    }

    protected override void PlayerBuildCastle()
    {
        if (_botHaveCube)
        {
            return;
        }
        else
        {
            isCube = true;
            PlayerBase._countCastlePlace = PlayerBase._countCastlePlace + PlayerBase._countCube;
            PlayerBase._countCube = 0;
            gameObject.transform.SetParent(_cubes.transform);
            transform.rotation = Quaternion.Euler(0, 0, 0);      
            for (int i = 0; i < CubeScatterPlayer.Count; i++)
            {
                EnemyBabyBotBase._freeCubes.Remove(CubeScatterPlayer[i]);
            }
            CubeScatterPlayer.Clear();
        }

    }

    protected override void FirstBotTakesCube()
    {
        if (_botHaveCube || _playerHaveCube || _secondBotHaveCube)
        {
            return;
        }
        else
        {
            _rigidbodyCubes.constraints = RigidbodyConstraints.FreezeAll;
            _botHaveCube = true;
            EnemyBabyBotBase._freeCubes.Remove(gameObject);
            transform.rotation = _babyBot.transform.rotation;
            EnemyBabyBotBase._countCubesBot++;
            gameObject.transform.tag = "CubeFirstBot";
            CastleCubeBot.AddRange(GameObject.FindGameObjectsWithTag("CubeFirstBot"));
            gameObject.transform.SetParent(_babyBot.transform);
            for (int i = 0; i < _babyBot.transform.childCount; i++)
            {
                CubeScatterBot.Add(_babyBot.transform.GetChild(i).gameObject);
            }
            gameObject.transform.position = PlaceCubeBot[EnemyBabyBotBase._countCubesBot].transform.position;
        }
    }

    protected override void FirstBotBuildCastle()
    {
        if (_playerHaveCube)
        {
            return;
        }
        else
        { 
            isCubeBot = true;
            EnemyBabyBotBase._goBuildCastle = false;
            EnemyBabyBotBase._countCubesBot = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            for (int i = 0; i < CubeScatterBot.Count; i++)
            {
                CubeScatterBot[i].transform.SetParent(_cubesFirstBot.transform);
                EnemyBabyBotBase._freeCubes.Remove(CubeScatterBot[i]);
            }
            CubeScatterBot.Clear();
            EnemyBabyBotBase._freeCubes.Clear();
            EnemyBabyBotBase._freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
        }
    }

    protected override void SecondBotTakesCube()
    {
        if (_botHaveCube || _playerHaveCube || _secondBotHaveCube)
        {
            return;
        }
        else
        {
            _rigidbodyCubes.constraints = RigidbodyConstraints.FreezeAll;
            _secondBotHaveCube = true;
            EnemyBabyBotBase._freeCubes.Remove(this.gameObject);
            transform.rotation = _babySecondBot.transform.rotation;
            EnemyBabyBotBase._countCubesSecondBot++;
            gameObject.transform.tag = "CubeSecondBot";
            CastleCubeSecondBot.AddRange(GameObject.FindGameObjectsWithTag("CubeSecondBot"));
            gameObject.transform.SetParent(_babySecondBot.transform);
            for (int i = 0; i < _babySecondBot.transform.childCount; i++)
            {
                CubeScatterSecondBot.Add(_babySecondBot.transform.GetChild(i).gameObject);
            }
            gameObject.transform.position = PlaceCubeSecondBot[EnemyBabyBotBase._countCubesSecondBot].transform.position;
        }
    }

    protected override void SecondBotBuildCastle()
    {
        Debug.Log("SecondBotBuildCastle");
    }
    private void MoveCubesPlayer()
    {
        for (int i = 0; i < CastleCube.Count; i++)
        {
            CastleCube[i].transform.position = Vector3.MoveTowards(CastleCube[i].transform.position,
               PlaceCastle[i].transform.position, _speedFlyCube);
            if (CastleCube[CastleCube.IndexOf(gameObject)].transform.position == PlaceCastle[CastleCube.IndexOf(gameObject)].transform.position)
            {
                isCube = false;
            }
        }
    }
    private void MoveCubesFirstBot()
    {
        for (int i = 0; i < CastleCubeBot.Count; i++)
        {
            CastleCubeBot[i].transform.position = Vector3.MoveTowards(CastleCubeBot[i].transform.position,
               PlaceCastleBot[i].transform.position, _speedFlyCube);
            if (CastleCubeBot[CastleCubeBot.IndexOf(gameObject)].transform.position == PlaceCastleBot[CastleCubeBot.IndexOf(gameObject)].transform.position)
            {
                isCube = false;
            }
        }
    }
    private void ScatterPlayeer()
    {

        for (int i = 0; i < CubeScatterPlayer.Count; i++)
        {
            CubeScatterPlayer[i].transform.tag = "FreeCube";
            CubeScatterPlayer[i].transform.SetParent(_freeCubes.transform);
            CubeScatterPlayer[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            CubeScatterPlayer[i].GetComponent<Cube>()._playerHaveCube = false;
            PlayerBase._countCube = 0;
            EnemyBabyBotBase._freeCubes.Clear();
            EnemyBabyBotBase._freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
            EnemyBabyBotBase._freeCubes.Add(CubeScatterPlayer[i]);
            CastleCube.AddRange(GameObject.FindGameObjectsWithTag("Cube"));
            _isPlayerTakeCube = true;
        }
        CubeScatterPlayer.Clear();
        CastleCube.Clear();
    }
    private void ScatterBot()
    {

        for (int i = 0; i < CubeScatterBot.Count; i++)
        {
            CubeScatterBot[i].transform.tag = "FreeCube";
            CubeScatterBot[i].transform.SetParent(_freeCubes.transform);
            CubeScatterBot[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            CubeScatterBot[i].GetComponent<Cube>()._botHaveCube = false;
            EnemyBabyBotBase._countCubesBot = 0;
            EnemyBabyBotBase._freeCubes.Clear();
            EnemyBabyBotBase._freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
            EnemyBabyBotBase._freeCubes.Add(CubeScatterBot[i]);
            CastleCubeBot.AddRange(GameObject.FindGameObjectsWithTag("CubeFirstBot"));
            _isFirstBotTakeCube = true;
        }
        CubeScatterBot.Clear();
        CastleCubeBot.Clear();
    }

    
}