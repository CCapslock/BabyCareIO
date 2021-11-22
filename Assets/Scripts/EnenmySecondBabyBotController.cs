using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmySecondBabyBotController : IExecute
{
    private readonly EnemyBabyBotBase _enemybase;

    public EnenmySecondBabyBotController(EnemyBabyBotBase enemy)
    {
        _enemybase = enemy;
    }

    public void Execute()
    {
        _enemybase.SecondExecute();
    }
}
