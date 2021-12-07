using UnityEngine;

public sealed class SpawnCubes : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private Transform _freeCubes;
    [SerializeField] private int _numberCubes;
    private void Awake()
    {
        Spawn();
    }
    private void Spawn()
    {
        for (int i = 0; i < _numberCubes; i++)
        {
            Instantiate(_cube,new Vector3(Random.Range(-7,6),1, Random.Range(-7, 8)),Quaternion.Euler(0, Random.Range(0, 360),0),_freeCubes);
    
        }
    }
}
