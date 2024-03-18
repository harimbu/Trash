using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject boss;
    private float[] arrPosX = {-2.2f, -1.1f, 0, 1.1f, 2.2f};
    [SerializeField] float enemyInterval = 1.5f;

    void Start()
    {
        StartCoroutine("EnemyRoutine");
    }

    public void StopEnemyRoutine() {
        StopCoroutine("EnemyRoutine");
    }


    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3f);
        
        int enemyIndex = 0;
        int enemyCount = 0;
        float moveSpeed = 5f;

        while(true) {
            foreach(float posX in arrPosX) {
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            enemyCount++;
            if(enemyCount % 10 == 0) {
                enemyIndex++;
                moveSpeed += 1;
            }

            if(enemyIndex >= enemies.Length) {
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }            

            yield return new WaitForSeconds(enemyInterval);
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

    void SpawnBoss() {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
    
}
