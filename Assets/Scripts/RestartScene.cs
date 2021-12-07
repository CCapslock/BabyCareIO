public class RestartScene
{
    public void RestartFirstBot(EnemyBabyBotBase firstBot)
    {
        firstBot.StartPoint();
        
        firstBot._isCryBot = false;
        firstBot._countCubesBot = 0;
        firstBot._goBotTarget = false;
        firstBot._castleBuilt = false;
        firstBot._goBuildCastle = false;
        firstBot.FindClosestCube();
        InteractiveObject._isFirstBotTakeCube = true;
    }

    public void RestartSecondBot(EnemyBabyBotBase secondBot)
    {
        secondBot.StartPoint();
        secondBot._isCrySecondBot =  false;
        secondBot._countCubesSecondBot = 0;
        secondBot._goBotTargetSecondBot = false;
        secondBot._castleBuiltSecondBot = false;
        secondBot._goBuildCastleSecondBot = false;
        InteractiveObject._isSecondBotTakeCube = true;
    }
    public void RestartPlayer(PlayerBase player)
    {
        player.StartPoint();
        player.isCry = false;
        player._countCube = 0;
        player._castleBuiltPlayer = false;
        InteractiveObject._isPlayerTakeCube = true;
    }
    
}
