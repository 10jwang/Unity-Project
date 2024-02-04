using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterStateMachine : MonoBehaviour
{
    private ShooterState shooterState;
    public float detectionRange = 200f;
    public Sniper_move_forward movementScript;
    private Animator animator;
    private Rigidbody2D rb;
    public GameObject bullet;
    public int ShootCount = 1;
    private int ShotsFired = 0;
    public float reloadTime = 2f;
    private float reloadTimer = 0f;
    private Enemy objectToShoot;
    public float shootLagTime = 0.5f;
    private float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        shooterState = ShooterState.Walking;
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooterState == ShooterState.Reloading)
        {
            shootTimer = 0f;
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime)
            {
                shooterState = ShooterState.Walking;
                reloadTimer = 0f;
                animator.SetBool("isReloading", false);
            }
        }
        else
        {
            if (ShotsFired >= ShootCount)
            {
                ShotsFired = 0;
                shooterState = ShooterState.Reloading;
                rb.rotation = 0;
                animator.SetBool("isReloading", true);
            }
            else
            {
                objectToShoot = nextEnemy();
                if (objectToShoot != null)
                {
                    shooterState = ShooterState.Shooting;
                }
                else
                {
                    shooterState = ShooterState.Walking;
                }
            }


            if (shooterState == ShooterState.Walking)
            {
                shootTimer = 0f;
                animator.SetBool("isShooting", false);
                movementScript.enabled = true;
            }
            else if (shooterState == ShooterState.Shooting)
            {
                if (shootTimer >= shootLagTime)
                {
                    shootTimer = 0f;
                    animator.SetBool("isShooting", true);
                    Shoot(objectToShoot);
                    ShotsFired++;
                    movementScript.enabled = false;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
                
            }
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

    private void Shoot(Enemy enemy)
    {
        Vector3 direction = enemy.transform.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        GameObject newBullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
        Rigidbody2D newBullet_rb = newBullet.GetComponent<Rigidbody2D>();
        newBullet_rb.rotation = angle;

    }
}

public enum ShooterState
{
    Reloading,
    Walking,
    Shooting
};