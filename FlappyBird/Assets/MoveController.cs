using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float Speed;
    public float XDespawnPoint;
    public float XSpawnPoint;


    public float YMin;
    public float YMax;

    public bool ShouldRandomizeY;

    void Start()
    {
        if (ShouldRandomizeY)
        {
            transform.position = new Vector3(transform.position.x,
                Random.Range(YMin, YMax), transform.position.z);
        }
    }
    
    void Update()
    {
        //They only move if GameOver == false and HasStarted == true
        if (BirdController.GameOver || !BirdController.HasStarted)
            return;

        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime,
            transform.position.y, transform.position.z);

        if (transform.position.x < XDespawnPoint)
        {
            if (ShouldRandomizeY)
            {
                transform.position = new Vector3(XSpawnPoint,
                    Random.Range(YMin, YMax), transform.position.z);
            }
            else
            {
                transform.position = new Vector3(XSpawnPoint,
                    transform.position.y, transform.position.z);
            }
        }
    }
}
