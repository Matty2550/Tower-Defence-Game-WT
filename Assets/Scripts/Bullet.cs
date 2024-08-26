using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float damage = 10;
    [SerializeField] private float lifetime = 10;

    public void Init(Vector2 dir)
    {
        rb.velocity = dir * speed;
        //lifetime *= Time.deltaTime;
    }

    private void unused()
    {
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.transform.GetComponent<enemy_1>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
