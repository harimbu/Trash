using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject boss;
    private float[] arrPosX = {-2.2f, -1.1f, 0, 1.1f, 2.2f};
    [SerializeField] private float spawnInterval = 1.5f;
    private float moveSpeed = 5f;

    void Start() {
        StartCoroutine(EnemyRoutine());
    }

    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3f);

        int enemyIndex = 0;
        int spawnCount = 0;

        while (true) {
            foreach(float posX in arrPosX) {                
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }
            spawnCount++;

            if(spawnCount % 10 == 0) {
                enemyIndex++;
                moveSpeed += 2; 
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed) {
        Vector3 spawnPos = new(posX, transform.position.y, 0);
        
        if(Random.Range(0, 5) == 0) {
            index++;
        }

        if(index >= enemies.Length) {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }
}
