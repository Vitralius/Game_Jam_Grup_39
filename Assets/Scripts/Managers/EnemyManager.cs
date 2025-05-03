using System.Collections.Generic;

public static class EnemyManager
{
    private static Dictionary<string, Enemy> activeEnemies = new();

    public static void RegisterEnemy(Enemy enemy)
    {
        if (!activeEnemies.ContainsKey(enemy.id))
        {
            activeEnemies.Add(enemy.id, enemy);
        }
    }
    public static void UnregisterEnemy(string id)
    {
        if (activeEnemies.ContainsKey(id))
        {
            activeEnemies.Remove(id);
        }
    }

    public static Enemy GetEnemyById(string id)
    {
        return activeEnemies.TryGetValue(id, out Enemy enemy) ? enemy : null;
    }

    public static IEnumerable<Enemy> GetAllEnemies()
    {
        return activeEnemies.Values;
    }
    public static IEnumerable<string> GetAllKeys()
    {
        return activeEnemies.Keys;
    }
}