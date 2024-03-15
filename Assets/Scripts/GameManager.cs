using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private TextMeshProUGUI text;
    private int coin = 0;

    void Awake() {
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
}
