using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 5f;
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.down;
        if(transform.position.y < -10) {
            transform.position += new Vector3(0, 20f, 0);
        }
    }
}
