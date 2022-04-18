public class EnemySecondBabyBotController : IExecute
{
    private readonly EnemyBabyBotBase _enemybase;

    public EnemySecondBabyBotController(EnemyBabyBotBase enemy)
    {
        _enemybase = enemy;
    }

    public void Execute()
    {
        _enemybase.SecondExecute();
    }
}
