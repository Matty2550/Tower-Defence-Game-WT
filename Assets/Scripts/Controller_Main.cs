using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Main : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float turretCooldown;
    [SerializeField] private Bullet spawnedBullet;
    [SerializeField] private enemy_1 enemyClone;
    [SerializeField] private Transform spawnPoint;
    private float spawnInterval;
    private Vector2 spawnEnemy;
    public Transform turret_main;


    void Start()
    {
        
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        turret_main.transform.up = Vector2.MoveTowards(turret_main.transform.up, mousePos, rotationSpeed * Time.deltaTime);

        //Mouse input
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(spawnedBullet, spawnPoint.position, Quaternion.identity).Init(turret_main.transform.up);
        }

        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        {
            spawnEnemy.x = Random.Range(-0.5f,0.5f);
            if (spawnEnemy.x <= 0) spawnEnemy.x -= 4;
            else spawnEnemy.x += 4;
            spawnEnemy.y = Random.Range(-0.5f, 0.5f);
            if (spawnEnemy.y <= 0) spawnEnemy.y -= 3;
            else spawnEnemy.y += 3;
            Instantiate(enemyClone).transform.position = spawnEnemy;
            spawnInterval = Random.Range(1f, 3f);
        }
    }
}
