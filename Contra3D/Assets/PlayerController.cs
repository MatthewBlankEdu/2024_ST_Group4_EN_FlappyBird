using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public Transform GroundCheckOrigin;
    public LayerMask GroundLayers;

    public Transform GunOrigin;
    public Transform ShootingPoint;
    public Transform Capsule;

    public ProjectileController BulletPrefab;

    private float horizontal;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, horizontal * Speed);

        if(horizontal > 0.01f)
            Capsule.localScale = new Vector3(1, 1, 1);
        else if(horizontal < -0.01f)
            Capsule.localScale = new Vector3(1, 1, -1);
    }



    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(GroundCheckOrigin.position, Vector3.down, 0.05f, GroundLayers);
    }

    void Shoot()
    {
        var projectile = Instantiate(BulletPrefab, ShootingPoint.position, Quaternion.identity);
      
        if (Capsule.localScale.z > 0.01f)
            projectile.SetProjectile(ShootingPoint.forward);
        else if (Capsule.localScale.z < -0.01f)
            projectile.SetProjectile(-ShootingPoint.forward);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }
}