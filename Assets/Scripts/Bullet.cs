using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed,lifeTime;
    public Rigidbody theRigidbody;

    public int damage;

    public bool damageEnemy, damagePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRigidbody.velocity = transform.forward * bulletSpeed;

        lifeTime -= Time.deltaTime;
        
        if(lifeTime<=0){
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Enemy" && damageEnemy){
            other.gameObject.GetComponent<EnemyHealth>().DamageEnemy(damage * 2);
        }

        if(other.gameObject.tag == "Player" && damagePlayer){
            PlayerHealth.instance.DamagePlayer(damage);
        }
        Destroy(gameObject);
    }
}
