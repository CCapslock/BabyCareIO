using System.Collections.Generic;
using UnityEngine;
public class Cube : InteractiveObject
{
    private List<GameObject> PlaceCube = new List<GameObject>();
    private List<GameObject> PlaceCastle = new List<GameObject>();
    private List<GameObject> CastleCube = new List<GameObject>();
    private List<GameObject> PlaceCubeBot = new List<GameObject>();
    private List<GameObject> PlaceCastleBot = new List<GameObject>();
    private List<GameObject> CastleCubeBot = new List<GameObject>();
    private GameObject _playerBaby;
    private GameObject _babyBot;
    private GameObject _cubes;
    private GameObject _cubesBot1;
    private bool isCube = false;
    private bool isCubeBot = false;
    private bool _botHaveCube = false;
    private bool _playerHaveCube = false;
    private float _speedFlyCube = 0.02f;





    private void Awake()
    {
        PlaceCube.AddRange(GameObject.FindGameObjectsWithTag("PlaceCube"));
        PlaceCastle.AddRange(GameObject.FindGameObjectsWithTag("PlaceCastle"));
        PlaceCubeBot.AddRange(GameObject.FindGameObjectsWithTag("PlaceCubeFirstBot"));
        PlaceCastleBot.AddRange(GameObject.FindGameObjectsWithTag("PlaceCastleFirstBot"));
        _playerBaby = GameObject.Find("Player");
        _babyBot = GameObject.Find("ToonBabyABot1");
        _cubes = GameObject.Find("PlaceCastle");
        _cubesBot1 = GameObject.Find("PlaceCastleBot1");

    }
    public override void Execute()
    {
        if (CastleCube.Count == PlaceCastle.Count)
        {
            isInteraction = false;
        }
        if (CastleCubeBot.Count == PlaceCastleBot.Count)
        {
            isThirdInteraction = false;
        }
        if (isCube == true)
        {
            MoveCubesPlayer();
        }
        if (isCubeBot == true)
        {
            MoveCubesFirstBot();
        }
        if (EnemyBabyBotBase._countCubesInCastel == PlaceCastleBot.Count)
        {
            EnemyBabyBot._freeCubes.Clear();

        }

    }
    protected override void Interaction()
    {
        if (_botHaveCube)
        {
            return;
        }
        else
        {
            _playerHaveCube = true;
            EnemyBabyBot._freeCubes.Remove(gameObject);
            EnemyBabyBot._closest = null;
            transform.rotation = _playerBaby.transform.rotation;
            PlayerBase._countCube++;
            gameObject.transform.tag = "Cube";
            CastleCube.AddRange(GameObject.FindGameObjectsWithTag("Cube"));
            gameObject.transform.SetParent(_playerBaby.transform);
            gameObject.transform.position = PlaceCube[PlayerBase._countCube].transform.position;
            if (EnemyBabyBot._freeCubes.Contains(EnemyBabyBot._closest))
            {
                Debug.Log("True");
            }
            Debug.Log("False");
        }


    }

    protected override void SecondInteraction()
    {
        if (_botHaveCube)
        {
            return;
        }
        else
        {
            isCube = true;
            PlayerBase._countCube = 0;
            gameObject.transform.SetParent(_cubes.transform);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    protected override void ThirdInteraction()
    {
        if (_playerHaveCube)
        {
            return;
        }
        else
        {

            _botHaveCube = true;
            EnemyBabyBot._freeCubes.Remove(EnemyBabyBot._closest);
            transform.rotation = _babyBot.transform.rotation;
            EnemyBabyBotBase._countCubesBot++;
            gameObject.transform.tag = "CubeFirstBot";
            CastleCubeBot.AddRange(GameObject.FindGameObjectsWithTag("CubeFirstBot"));
            gameObject.transform.SetParent(_babyBot.transform);
            gameObject.transform.position = PlaceCubeBot[EnemyBabyBotBase._countCubesBot].transform.position;
            EnemyBabyBotBase._countCubesInCastel++;
          
        }


    }

    protected override void FourthInteraction() 
    {
        isCubeBot = true;
        EnemyBabyBotBase._goBuildCastle = false;
        EnemyBabyBotBase._countCubesBot = 0;
        gameObject.transform.SetParent(_cubesBot1.transform);
        transform.rotation = Quaternion.Euler(0, 0, 0);
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
}