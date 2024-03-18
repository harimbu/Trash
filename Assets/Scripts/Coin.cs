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
        Rigidbody2D rgbody = GetComponent<Rigidbody2D>();
        float randomJump = Random.Range(4f, 8f);
        Vector2 jumpVelocity = Vector2.up * randomJump;
        jumpVelocity.x = Random.Range(-2f, 2f);
        rgbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    void Update() {
        if(transform.position.y < -7) {
            Destroy(gameObject);
        }
    }
}
