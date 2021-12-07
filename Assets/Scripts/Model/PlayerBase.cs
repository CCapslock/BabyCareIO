using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public float _speed;
    public  bool isCry = false;
    public  int _countCube;
    public bool _castleBuiltPlayer = false;
    public abstract void Move(float x, float y, float z);
    public abstract void BabyAnim();
    public abstract void RotationMove();
    public abstract void StartPoint();
}
