using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform shootTransform;
    [SerializeField] private float shootInterval = 0.05f;
    private float lastShotTime = 0;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float moveX = Mathf.Clamp(mousePos.x, -2.3f, 2.3f);
        transform.position = new Vector3(moveX, transform.position.y, 0); 

        Shoot();
    }

    void Shoot() {
        if(Time.time - lastShotTime > shootInterval) {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Coin")) {
            Debug.Log("coin + 1");
            Destroy(other.gameObject);
        }
    }
}
