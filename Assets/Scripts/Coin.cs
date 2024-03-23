using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        Jump();
    }

    void Jump() {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 jumpVelocity = new(Random.Range(-2.2f, 2.2f), Random.Range(4f, 8f));
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }    
}
