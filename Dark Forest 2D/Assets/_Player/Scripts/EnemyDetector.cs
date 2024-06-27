using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{ 
    [field: SerializeField] public float Radius { get; private set; }

    public List<Health> SearchEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, Radius);
        List<Health> list = new();

        foreach (Collider2D hit in hits)
        {
            Health enemy;

            if (hit.GetComponent<Enemy>())
                if(enemy = hit.GetComponent<Health>())
                    if(enemy.CurrentHealth > 0)
                        list.Add(enemy);
        }

        return SortEnemy(list);
    }

    private List<Health> SortEnemy(List<Health> enemies)
    {
        var filteredEnemies = enemies.OrderBy(enemy => Vector2.Distance(transform.position, enemy.transform.position)).ToList();

        return filteredEnemies;
    }
}
