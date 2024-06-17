using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private float _radius;

    public List<Health> SearchEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);
        List<Health> list = new();

        foreach (Collider2D hit in hits)
        {
            Health enemy;

            if (hit.GetComponent<Enemy>())
                if(enemy = hit.GetComponent<Health>())
                    if(enemy.CurrentHealth > 0)
                        list.Add(enemy);
        }
        
        return list;
    }
}
