using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Collider myCollider;
    public int damage = 1;
    public ParticleSystem Explotion;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        if (myRigidbody != null)
        {
            Invoke("AutoDestroy", 10F);

            myCollider = GetComponent<Collider>();

            if (myCollider != null)
            {
                myCollider.isTrigger = false;
            }
        }
        else
        {
            AutoDestroy();
        }
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" 
            || col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Character>().ApplyDamage(damage);
        }

        if (Explotion != null)
        {
            (Instantiate<ParticleSystem>(Explotion, transform.position, Explotion.transform.rotation)).Play();
        }
            AutoDestroy();
    }
}