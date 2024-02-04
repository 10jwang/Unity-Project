using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterStateMachine : MonoBehaviour
{
    public ShooterState shooterState;
    public float detectionRange = 6;
    public LayerMask enemyLayer;
    public Sniper_move_forward movementScript;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        shooterState = ShooterState.Walking;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooterState == ShooterState.Walking)
        {
            Enemy objectToShoot = nextEnemy();
            if (objectToShoot != null)
            {
                shooterState = ShooterState.Shooting;
            }
            movementScript.enabled = true;
            animator.speed = 0.4f;
        }
        else
        {
            movementScript.enabled = false;
            animator.speed = 0f;
        }
    }

    Enemy nextEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        if (distanceToClosestEnemy > detectionRange)
        {
            return null;
        }
        else
        {
            return closestEnemy;
        }
    }
}

public enum ShooterState
{
    Reloading,
    Walking,
    Shooting
};