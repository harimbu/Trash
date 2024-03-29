using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float hp = 1f;
    [SerializeField] private GameObject coin;

    public void SetMoveSpeeed(float moveSpeed) {
        this.moveSpeed = moveSpeed;
    }

    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.down;
        if(transform.position.y < -7) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Weapon")) {
            Weapon weapon = FindAnyObjectByType<Weapon>();
            hp -= weapon.damage;
            if(hp <= 0) {
                if(gameObject.CompareTag("Boss")) {
                    GameManager.instance.SetGameOver();                    
                    Player player = FindAnyObjectByType<Player>();
                    player.StopGame();
                }
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);            
        }
    }
}
