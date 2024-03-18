using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private TextMeshProUGUI text;
    private int coin = 0;    
    [HideInInspector] public bool isGameOver = false;
    [SerializeField] GameObject gameOverPanel;

    void Awake()
    {
        if(instance == null) {
            instance = this;
        }        
    }

    public void IncreaseCoin() {
        coin++;
        text.SetText(coin.ToString());

        if(coin % 30 == 0) {
            Player player = FindAnyObjectByType<Player>();
            if(player != null) {
                player.Upgrade();
            }
        }
    }

    public void setGameOver() {
        isGameOver = true;

        EnemySpawner enemySpawner = FindAnyObjectByType<EnemySpawner>();
        if(enemySpawner != null) {
            enemySpawner.StopEnemyRoutine();
        }
        
        Invoke("ShowGameOverPanel", 1f);
    }

    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}
