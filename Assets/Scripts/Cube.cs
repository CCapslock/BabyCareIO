using System.Collections.Generic;
using UnityEngine;


public class Cube : InteractiveObject
{
    [SerializeField]
    private GameObject[] PlaceCube;
    private GameObject[] PlaceCastle;
    [SerializeField]
    private List<GameObject> CastleCube = new List<GameObject>();
    private GameObject _playerBaby;
    private GameObject _cubes;
    private bool isCube = false;

   
    private void Awake()
    {
        PlaceCube = GameObject.FindGameObjectsWithTag("PlaceCube");
        PlaceCastle = GameObject.FindGameObjectsWithTag("PlaceCastle");
        _playerBaby = GameObject.Find("ToonBabyA (2)");
        _cubes = GameObject.Find("PlaceCastle");
    }
    public override void Execute()
    {
        
    }

    protected override void Interaction()
    {
        isCube = true;
        PlayerBase._countCube++;
        Debug.Log(PlayerBase._countCube);

        if (isCube)
        {
            gameObject.transform.tag = "Cube";
            CastleCube.AddRange(GameObject.FindGameObjectsWithTag("Cube"));
            gameObject.transform.SetParent(_playerBaby.transform);
            gameObject.transform.position = PlaceCube[PlayerBase._countCube].transform.position;
        }
    }

    protected override void SecondInteraction()
    {
        isCube = false;
        PlayerBase._countCube = 0;
        gameObject.transform.SetParent(_cubes.transform);
        for (int i = 0; i < CastleCube.Count; i++)
        {
            if (i>=PlaceCastle.Length)
            {
                return; 
            }
            CastleCube[i].transform.position = Vector3.MoveTowards(transform.position, PlaceCastle[i].transform.position,10f);
        }
        CastleCube.Clear();

       
    }

}
