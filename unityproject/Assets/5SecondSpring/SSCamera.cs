using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSCamera : MonoBehaviour
{
    public Transform player;
    
    
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= player.position.y)
        {
            transform.position = new Vector3(player.position.x, 0, -10f);
        }

    }
}
