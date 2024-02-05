using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionScript : MonoBehaviour
{
    public GameObject explosion;
    public float ExplosionRange = 4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Instantiate(explosion, this.transform.position + (transform.right * 1.5f), Quaternion.identity);
        }
        Player[] allEnemies = GameObject.FindObjectsOfType<Player>();

        foreach (Player currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < (ExplosionRange * ExplosionRange))
            {
                collision.gameObject.GetComponent<Health>().health -= 15;

            }
        }

    }
}

