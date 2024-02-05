using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 3f;
    public int damage = 10;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

private void OnCollisionEnter2D(Collision2D collision)
{
    RedSafeHealth redSafeHealth = collision.gameObject.GetComponent<RedSafeHealth>();

    if (redSafeHealth != null)
    {
        // Assuming RedSafeHealth has a 'health' variable
        redSafeHealth.health -= damage;

        Destroy(gameObject);
    }
}

}
