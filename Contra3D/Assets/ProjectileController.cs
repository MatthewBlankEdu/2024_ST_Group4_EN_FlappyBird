using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float Speed;

    private Vector3 shootingDirection;

    public void SetProjectile(Vector3 direction)
    {
        shootingDirection = direction;
    }

    void FixedUpdate()
    {
        transform.position = transform.position + Speed * Time.fixedDeltaTime * shootingDirection;
    }
}
