using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy_1 : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private float health = 50;
    [SerializeField] private float enemySpeed = 5;

    public void Init()
    {

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), enemySpeed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}
