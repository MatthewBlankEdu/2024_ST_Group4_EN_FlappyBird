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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x,
            Random.Range(YMin, YMax), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime,
            transform.position.y, transform.position.z);
    
        if(transform.position.x < XDespawnPoint)
        {
            transform.position = new Vector3(XSpawnPoint, 
                Random.Range(YMin, YMax), transform.position.z);
        }
    }
}
