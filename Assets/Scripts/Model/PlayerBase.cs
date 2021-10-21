using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public float _speed;
    public static int _countCube;
    public static int _countCastlePlace;
    public static int _counCubeBot;

    public abstract void Move(float x, float y, float z);
    public abstract void BabyAnim();
    public abstract void RotationMove();
}
