using UnityEngine;

public class Player : Character
{
    public float movementSpeed = 5F;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            FireBullet();
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(
                transform.right * Input.GetAxis("Horizontal")
                * movementSpeed * Time.deltaTime);
        }
    }    
}