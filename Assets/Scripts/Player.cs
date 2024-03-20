using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    private int weaponIndex = 0;
    [SerializeField] private Transform shootTransform;
    [SerializeField] private float shootInterval = 0.05f;
    float lastShotTime = 0;

    void Update()
    {
        Vector3 mousePox = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float moveX = Mathf.Clamp(mousePox.x, -2.3f, 2.3f);
        transform.position = new Vector3(moveX, transform.position.y, 0);     

        Shoot();           
    }

    void Shoot() {
        if(Time.time - lastShotTime > shootInterval) {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss")) {
            Destroy(gameObject);
            GameManager.instance.SetGameOver();
        }

        if(other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            GameManager.instance.IncreaseCoin();
        }
    }

    public void Upgrade() {
        weaponIndex++;
        if(weaponIndex >= weapons.Length) {
            weaponIndex = weapons.Length - 1;
        }
    }
}
