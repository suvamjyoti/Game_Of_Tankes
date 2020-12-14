using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    internal int enemiesKilled;
    internal int shellsFired;
    internal float currentHealth;

    private TankShoot tankShoot;
    private PlayerHealth playerHealth;

    private void Start() {
        tankShoot = GetComponent<TankShoot>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update() {
        enemiesKilled = EnemyHealth.KillScore;
        shellsFired = tankShoot.CurrentCount;
        currentHealth = playerHealth.CurrentHealth; 
    }

    public void SaveGame(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadGame(){
        PlayerData data = SaveSystem.LoadPlayer();

        EnemyHealth.KillScore = data.enemiesKilled;
        tankShoot.CurrentCount = data.shellsFired;
        playerHealth.CurrentHealth = data.playerHealth;

        Vector3 position = new Vector3(data.position[0],data.position[1],data.position[2]);

        transform.position = position;
    }

}
