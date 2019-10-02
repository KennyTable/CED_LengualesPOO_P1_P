using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Transform spawnPosition;
    public Rigidbody cannonBall;
    public float force = 5F;    
    public int hp;
    public Text life;

    void Update()
    {
       life.text = "Life: " + hp.ToString();

       if (hp < 1)
       {
            life.text = "You die";
       }
    }   
    protected void FireBullet()
    {
        Rigidbody cannonBallClone =
            Instantiate<Rigidbody>(
                cannonBall, spawnPosition.position, spawnPosition.rotation);

        cannonBallClone.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    public void ApplyDamage(int damageValue)
    {
        hp -= damageValue;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }


}
