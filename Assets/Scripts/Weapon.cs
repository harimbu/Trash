using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] public float damage = 1f;

    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.up;
        if(transform.position.y > 6) {
            Destroy(gameObject);
        }        
    }    
}
