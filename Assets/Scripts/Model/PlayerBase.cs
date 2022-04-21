using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public float _speed;
    public static bool isCry = false;
    public static bool isClap = false;
    public static bool isWalk = false;
    public static bool isIdle = false;
    public static int _countCube;
    public static int _countCastlePlace;
    public abstract void Move(float x, float y, float z);
    public abstract void BabyAnim();
    public abstract void RotationMove();
}
