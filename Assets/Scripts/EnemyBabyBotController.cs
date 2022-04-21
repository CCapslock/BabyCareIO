public class EnemyBabyBotController : IExecute
{
    private readonly EnemyBabyBotBase _enemybase;
    
    public EnemyBabyBotController(EnemyBabyBotBase enemy)
    {
        _enemybase = enemy;
    }
    public void Execute()
    {
        _enemybase.Execute();
    }
}
