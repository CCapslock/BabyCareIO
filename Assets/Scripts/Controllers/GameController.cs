using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Joystick _joystick;
    [SerializeField]
    private PlayerBaby _baby;
    [SerializeField]
    private EnemyBabyBot _babyBot;
    [SerializeField]
    private SecondEnemyBot _babySecondBot;
    [SerializeField]
    private Transform _camera;
    private ListExecuteObject _interactiveObject;
    private PlayerController _playerController;
    private CameraController _cameraController;
    private EnemyBabyBotController _botController;
    private EnenmySecondBabyBotController _secondBotController;
    private RestartScene _restart;
    private EnemyBabyBotBase _firstBot, _secondBot;
    private PlayerBase _player;
    private SpawnCubes _spawnCubes;


    private void Awake()
    {
        _interactiveObject = new ListExecuteObject();
        _playerController = new PlayerController(_baby, _joystick);
        _interactiveObject.AddExecuteObject(_playerController);
        _cameraController = new CameraController(_baby.transform, _camera);
        _interactiveObject.AddExecuteObject(_cameraController);
        _botController = new EnemyBabyBotController(_babyBot);
        _interactiveObject.AddExecuteObject(_botController);
        _secondBotController = new EnenmySecondBabyBotController(_babySecondBot);
        _interactiveObject.AddExecuteObject(_secondBotController);
        _restart = new RestartScene();
        _firstBot = FindObjectOfType < EnemyBabyBot >();
        _secondBot = FindObjectOfType<SecondEnemyBot>();
        _player = FindObjectOfType < PlayerBase >();
        

    }

    private void Update()
    {
        
        for (var i = 0; i < _interactiveObject.Length; i++)
        {
            var interactiveObject = _interactiveObject[i];

            if (interactiveObject == null)
            {
                continue;
            }
            interactiveObject.Execute();
        }
        if (_player._castleBuiltPlayer || _firstBot._castleBuilt || _secondBot._castleBuiltSecondBot)
        {
            StartCoroutine(Restart());
        }
    }
    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        _restart.RestartFirstBot(_firstBot);
        _restart.RestartSecondBot(_secondBot);
        _restart.RestartPlayer(_player);
        SceneManager.LoadScene(0);
        
        
        

    }
}
