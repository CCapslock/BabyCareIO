using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cube : InteractiveObject
{
    private List<GameObject> PlaceCube = new List<GameObject>();
    private List<GameObject> PlaceCastle = new List<GameObject>();
    private List<GameObject> CastleCube = new List<GameObject>();
    private List<GameObject> CubeScatterPlayer = new List<GameObject>();

    private List<GameObject> PlaceCubeBot = new List<GameObject>();
    private List<GameObject> PlaceCastleBot = new List<GameObject>();
    public List<GameObject> CastleCubeBot = new List<GameObject>();
    public List<GameObject> CubeScatterBot = new List<GameObject>();

    private List<GameObject> PlaceCubeSecondBot = new List<GameObject>();
    private List<GameObject> PlaceCastleSecondBot = new List<GameObject>();
    private List<GameObject> CastleCubeSecondBot = new List<GameObject>();
    private List<GameObject> CubeScatterSecondBot = new List<GameObject>();
    private List<int> _anglerotationCube = new List<int> { 0, 90, 180, 270 };


    private GameObject _playerBaby;
    private GameObject _babyBot;
    private GameObject _babySecondBot;
    private GameObject _cubes;
    private GameObject _cubesFirstBot;
    private GameObject _cubesSecondBot;
    private GameObject _freeCubes;

    private Rigidbody _rigidbodyCubes;

    private EnemyBabyBotBase _firstBot, _secondBot;
    private PlayerBase _player;
    private RestartScene _restart;

    private bool _isCube = false;
    private bool _isCubeBot = false;
    private bool _isCubeSecondBot = false;
    private bool _botHaveCube = false;
    private bool _playerHaveCube = false;
    private bool _secondBotHaveCube = false;
    private float _speedFlyCube = 0.02f;


    private void Start()
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
        _cubes = GameObject.Find("CubeCastle");
        _cubesFirstBot = GameObject.Find("BotCube");
        _cubesSecondBot = GameObject.Find("SecondBotCubes");
        _freeCubes = GameObject.Find("FreeCubes");
        _rigidbodyCubes = GetComponent<Rigidbody>();

        _player = FindObjectOfType<PlayerBase>();
        _firstBot = FindObjectOfType<EnemyBabyBot>();
        _secondBot = FindObjectOfType<SecondEnemyBot>();

        _restart = new RestartScene();
    }
    public  void Update()
    {
        
        if (_cubes.transform.childCount == PlaceCastle.Count)
        {
            _player._castleBuiltPlayer = true;
        }
        if (CastleCube.Count == PlaceCastle.Count)
        {
            _isPlayerTakeCube = false;
        }
        if (CastleCubeBot.Count == PlaceCastleBot.Count)
        {
            _isFirstBotTakeCube = false;
            _firstBot._goBotTarget = true;
            if (_cubesFirstBot.transform.childCount == PlaceCastleBot.Count)
            {
                _firstBot._castleBuilt = true;
            }
        }
        if (CastleCubeSecondBot.Count == PlaceCastleSecondBot.Count)
        {
            _isSecondBotTakeCube = false;
            _secondBot._goBotTargetSecondBot = true;

            if (_cubesSecondBot.transform.childCount == PlaceCastleSecondBot.Count)
            {
                _secondBot._castleBuiltSecondBot = true;
            }
        }
        if (_isCube == true)
        {
            MoveCubesPlayer();
        }
        if (_isCubeBot == true)
        {
            MoveCubesFirstBot();
        }
        if (_isCubeSecondBot == true)
        {
            MoveCubesSecondBot();
        }
        if (CubeScatterBot.Contains(_firstBot._closest))
        {
            EnemyBabyBotBase._freeCubes.Remove(_firstBot._closest);
        }
        if (CubeScatterSecondBot.Contains(_secondBot._seccondClosest))
        {
            EnemyBabyBotBase._freeCubes.Remove(_secondBot._seccondClosest);
        }
        if (_player.isCry)
        {
            ScatterPlayeer();
        }
        if (_firstBot._isCryBot)
        {
            ScatterBot();
        }
        if (_secondBot._isCrySecondBot)
        {
            ScatterSecondBot();
        }
    }
    protected override void PlayerTakesCube()
    {
        if (_botHaveCube || _playerHaveCube)
        {
            return;
        }
        else
        {
            CubeScatterPlayer.Clear();
            _rigidbodyCubes.constraints = RigidbodyConstraints.FreezeAll;
            _playerHaveCube = true;
            EnemyBabyBotBase._freeCubes.Remove(gameObject);
            _player._countCube++;
            gameObject.transform.tag = "Cube";
            gameObject.transform.SetParent(_playerBaby.transform);
            transform.localRotation = Quaternion.Euler(_anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)]);
            CastleCube.AddRange(GameObject.FindGameObjectsWithTag("Cube"));
            for (int i = 0; i < _playerBaby.transform.childCount; i++)
            {
                CubeScatterPlayer.Add(_playerBaby.transform.GetChild(i).gameObject);
            }
            gameObject.transform.position = PlaceCube[_player._countCube].transform.position;
        }
    }

    protected override void PlayerBuildCastle()
    {
        if (_botHaveCube || _secondBotHaveCube)
        {
            return;
        }
        else
        {
            _isCube = true;
            _player._countCube = 0;
            transform.rotation = Quaternion.Euler(_anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)]);
            gameObject.transform.SetParent(_cubes.transform);
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
            _firstBot._countCubesBot++;
            gameObject.transform.tag = "CubeFirstBot";
            CastleCubeBot.AddRange(GameObject.FindGameObjectsWithTag("CubeFirstBot"));
            gameObject.transform.SetParent(_babyBot.transform);
            transform.localRotation = Quaternion.Euler(_anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)]);
            for (int i = 0; i < _babyBot.transform.childCount; i++)
            {
                CubeScatterBot.Add(_babyBot.transform.GetChild(i).gameObject);
            }
            gameObject.transform.position = PlaceCubeBot[_firstBot._countCubesBot].transform.position;
        }
    }

    protected override void FirstBotBuildCastle()
    {
        if (_playerHaveCube || _secondBotHaveCube)
        {
            return;
        }
        else
        {
            _isCubeBot = true;
            _firstBot._goBuildCastle = false;
            _firstBot._countCubesBot = 0;
            for (int i = 0; i < CubeScatterBot.Count; i++)
            {
                CubeScatterBot[i].transform.SetParent(_cubesFirstBot.transform);
                EnemyBabyBotBase._freeCubes.Remove(CubeScatterBot[i]);
            }
            transform.localRotation = Quaternion.Euler(_anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)]);
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
            EnemyBabyBotBase._freeCubes.Remove(gameObject);
            _secondBot._countCubesSecondBot++;
            gameObject.transform.tag = "CubeSecondBot";
            CastleCubeSecondBot.AddRange(GameObject.FindGameObjectsWithTag("CubeSecondBot"));
            gameObject.transform.SetParent(_babySecondBot.transform);
            transform.localRotation = Quaternion.Euler(_anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)]);
            for (int i = 0; i < _babySecondBot.transform.childCount; i++)
            {
                CubeScatterSecondBot.Add(_babySecondBot.transform.GetChild(i).gameObject);
            }
            gameObject.transform.position = PlaceCubeSecondBot[_secondBot._countCubesSecondBot].transform.position;
        }
    }

    protected override void SecondBotBuildCastle()
    {
        if (_playerHaveCube || _botHaveCube)
        {
            return;
        }
        else
        {
            _isCubeSecondBot = true;
            _secondBot._goBuildCastleSecondBot = false;
            _secondBot._countCubesSecondBot = 0;
            transform.rotation = Quaternion.Euler(_anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)], _anglerotationCube[Random.Range(0, 3)]);
            for (int i = 0; i < CubeScatterSecondBot.Count; i++)
            {
                CubeScatterSecondBot[i].transform.SetParent(_cubesSecondBot.transform);
                EnemyBabyBotBase._freeCubes.Remove(CubeScatterSecondBot[i]);
            }
            CubeScatterSecondBot.Clear();
            EnemyBabyBotBase._freeCubes.Clear();
            EnemyBabyBotBase._freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));

        }
    }
    private void MoveCubesPlayer()
    {
        for (int i = 0; i < CastleCube.Count; i++)
        {
            if (CastleCube[i] != null)
            {
                CastleCube[i].transform.position = Vector3.MoveTowards(CastleCube[i].transform.position,
               PlaceCastle[i].transform.position, _speedFlyCube);

                if (CastleCube[CastleCube.IndexOf(gameObject)].transform.position == PlaceCastle[CastleCube.IndexOf(gameObject)].transform.position)
                {
                    _isCube = false;
                }
            }

        }




    }
    private void MoveCubesFirstBot()
    {
        for (int i = 0; i < CastleCubeBot.Count; i++)
        {
            if (CastleCubeBot[i] != null)
            {
                CastleCubeBot[i].transform.position = Vector3.MoveTowards(CastleCubeBot[i].transform.position,
               PlaceCastleBot[i].transform.position, _speedFlyCube);

                if (CastleCubeBot[CastleCubeBot.IndexOf(gameObject)].transform.position == PlaceCastleBot[CastleCubeBot.IndexOf(gameObject)].transform.position)
                {
                    _isCubeBot = false;
                }
            }
        }




    }

    private void MoveCubesSecondBot()
    {
        for (int i = 0; i < CastleCubeSecondBot.Count; i++)
        {
            if (CastleCubeSecondBot[i] != null)
            {
                CastleCubeSecondBot[i].transform.position = Vector3.MoveTowards(CastleCubeSecondBot[i].transform.position,
                PlaceCastleSecondBot[i].transform.position, _speedFlyCube);

                if (CastleCubeSecondBot[CastleCubeSecondBot.IndexOf(gameObject)].transform.position ==
                           PlaceCastleSecondBot[CastleCubeSecondBot.IndexOf(gameObject)].transform.position)
                {
                    _isCubeSecondBot = false;
                }
            }

        }




    }
    private void ScatterPlayeer()
    {
        if (CubeScatterPlayer.Count <= 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < CubeScatterPlayer.Count; i++)
            {
                CubeScatterPlayer[i].transform.tag = "FreeCube";
                CubeScatterPlayer[i].transform.SetParent(_freeCubes.transform);
                CubeScatterPlayer[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                CubeScatterPlayer[i].GetComponent<Cube>()._playerHaveCube = false;
                _player._countCube = 0;
                EnemyBabyBotBase._freeCubes.Clear();
                EnemyBabyBotBase._freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
                EnemyBabyBotBase._freeCubes.Add(CubeScatterPlayer[i]);
                CastleCube.AddRange(GameObject.FindGameObjectsWithTag("Cube"));
                _isPlayerTakeCube = true;
            }
            CubeScatterPlayer.Clear();
            CastleCube.Clear();
        }

    }
    private void ScatterBot()
    {
        if (CubeScatterBot.Count <= 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < CubeScatterBot.Count; i++)
            {
                CubeScatterBot[i].transform.tag = "FreeCube";
                CubeScatterBot[i].transform.SetParent(_freeCubes.transform);
                CubeScatterBot[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                CubeScatterBot[i].GetComponent<Cube>()._botHaveCube = false;
                _firstBot._countCubesBot = 0;
                EnemyBabyBotBase._freeCubes.Clear();
                EnemyBabyBotBase._freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
                EnemyBabyBotBase._freeCubes.Add(CubeScatterBot[i]);
                CastleCubeBot.AddRange(GameObject.FindGameObjectsWithTag("CubeFirstBot"));
                _isFirstBotTakeCube = true;
            }
            _firstBot._goBotTarget = false;
            CubeScatterBot.Clear();
            CastleCubeBot.Clear();
        }
    }

    private void ScatterSecondBot()
    {
        if (CubeScatterSecondBot.Count <= 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < CubeScatterSecondBot.Count; i++)
            {
                CubeScatterSecondBot[i].transform.tag = "FreeCube";
                CubeScatterSecondBot[i].transform.SetParent(_freeCubes.transform);
                CubeScatterSecondBot[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                CubeScatterSecondBot[i].GetComponent<Cube>()._secondBotHaveCube = false;
                _secondBot._countCubesSecondBot = 0;
                EnemyBabyBotBase._freeCubes.Clear();
                EnemyBabyBotBase._freeCubes.AddRange(GameObject.FindGameObjectsWithTag("FreeCube"));
                EnemyBabyBotBase._freeCubes.Add(CubeScatterSecondBot[i]);
                CastleCubeSecondBot.AddRange(GameObject.FindGameObjectsWithTag("CubeSecondBot"));
                _isSecondBotTakeCube = true;
            }
            _secondBot._goBotTargetSecondBot = false;
            CubeScatterSecondBot.Clear();
            CastleCubeSecondBot.Clear();
        }

    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        //Time.timeScale = 0;
        CastleCube.Clear();
        CastleCubeBot.Clear();
        CastleCubeSecondBot.Clear();


    }
}