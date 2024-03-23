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

    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    public void IncreaseCoin() {
        coin++;
        text.SetText(coin.ToString());

        if(coin % 10 == 0) {
            Player player = FindAnyObjectByType<Player>();
            player.Upgrade();
        }
    }

    public void SetGameOver() {
        EnemySpawner enemySpawner = FindAnyObjectByType<EnemySpawner>();
        if(enemySpawner != null) {
            enemySpawner.StopEnemyRoutine();
        }
        
        Invoke("ShowGamePanel", 1f);
    }

    void ShowGamePanel() {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}
