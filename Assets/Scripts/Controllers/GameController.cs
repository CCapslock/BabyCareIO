using UnityEngine;

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
    private EnemySecondBabyBotController _secondBotController;


    private void Awake()
    {
        _interactiveObject = new ListExecuteObject();
        _playerController = new PlayerController(_baby,_joystick);
        _interactiveObject.AddExecuteObject(_playerController);
        _cameraController = new CameraController(_baby.transform, _camera);
        _interactiveObject.AddExecuteObject(_cameraController);
        _botController = new EnemyBabyBotController(_babyBot);
        _interactiveObject.AddExecuteObject(_botController);
        _secondBotController = new EnemySecondBabyBotController(_babySecondBot);
        _interactiveObject.AddExecuteObject(_secondBotController);
    }

    private void FixedUpdate()
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
    }
}
