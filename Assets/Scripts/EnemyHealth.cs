using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(gameObject);

            UI.instance.killedEnemies++;

            UI.instance.killedEnemiesText.text = "Killed Enemies: " + UI.instance.killedEnemies;
        }
    }
}
