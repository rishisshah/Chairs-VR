using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

    public GameObject projectile;
    public float projectileSpeed;

    private float fireRate = 0.25F;
    private float nextFire = 0.0F;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), GetComponent<Collider>()); //ignore collision between projectile and player
    }

    void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);

        rb.velocity = movement;
    }

    void Fire()
    {
        Transform shootPos = this.transform;
        GameObject pr = Instantiate(projectile, shootPos.position, transform.rotation);
        Physics.IgnoreCollision(pr.GetComponent<Collider>(), GetComponent<Collider>());
        if (rb.velocity.x > 0)
            pr.GetComponent<Rigidbody>().velocity = new Vector2(projectileSpeed + rb.velocity.x, 0);
        if (rb.velocity.x <= 0)
            pr.GetComponent<Rigidbody>().velocity = new Vector2(projectileSpeed, 0);
        Destroy(pr, 5.0f);

    }
}

