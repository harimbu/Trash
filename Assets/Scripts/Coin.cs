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
        Vector2 jumpVelocity = new Vector2(Random.Range(-2f, 2f), Random.Range(4f, 8f));
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(transform.position.y < -7) {
            Destroy(gameObject);
        }        
    }

}
