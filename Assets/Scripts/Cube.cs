using System.Collections.Generic;
using System.Threading.Tasks;
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
    private  float _speedFlyCube = 0.02f;
    private Collider _cubeCollider;
    



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
        _cubeCollider = GetComponent<Collider>();
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

    }
    protected override void Interaction() //Игрок подбирает кубик
    {
      
        transform.rotation = _playerBaby.transform.rotation;
        PlayerBase._countCube++;
        gameObject.transform.tag = "Cube";
        CastleCube.AddRange(GameObject.FindGameObjectsWithTag("Cube"));
        gameObject.transform.SetParent(_playerBaby.transform);
        gameObject.transform.position = PlaceCube[PlayerBase._countCube].transform.position;
        Debug.Log($"Count = {CastleCube.Count}");
        Debug.Log($"LastindexOf = {CastleCube.LastIndexOf(gameObject)}");
        Debug.Log($"PlaceCastle = {PlaceCastle.Count}");
    }

    protected override void SecondInteraction() // Игрок принес кубик на свое место
    {
        isCube = true;
        PlayerBase._countCube = 0;
        gameObject.transform.SetParent(_cubes.transform);
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    protected override void ThirdInteraction() // Первый бот подбирает кубик
    {
        transform.rotation = _babyBot.transform.rotation;
        PlayerBase._counCubeBot++;
        gameObject.transform.tag = "CubeFirstBot";
        CastleCubeBot.AddRange(GameObject.FindGameObjectsWithTag("CubeFirstBot"));
        gameObject.transform.SetParent(_babyBot.transform);
        gameObject.transform.position = PlaceCubeBot[PlayerBase._counCubeBot].transform.position;
        
    }

    protected override void FourthInteraction() // Первый бот принес кубик насвое место
    {
        isCubeBot = true;
        PlayerBase._counCubeBot = 0;
        gameObject.transform.SetParent(_cubesBot1.transform);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private   void MoveCubesPlayer()
    {
        for (int i = 0; i < CastleCube.Count; i++)
        {
            CastleCube[i].transform.position = Vector3.MoveTowards(CastleCube [i].transform.position,
               PlaceCastle[i].transform.position, _speedFlyCube);
            if (CastleCube[CastleCube.IndexOf(gameObject)].transform.position == PlaceCastle[CastleCube.IndexOf(gameObject)].transform.position)
            {
                
                Debug.Log(CastleCube.Count);
                isCube = false;
            }  
        }
    }

    private void MoveCubesFirstBot()
    {
        for(int i = 0; i < CastleCubeBot.Count; i++)
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
    
    
