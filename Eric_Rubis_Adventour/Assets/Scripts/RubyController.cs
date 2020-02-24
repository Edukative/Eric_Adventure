using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rubyRB2D;
    public int maxHealth = 5;
    public int currentHealth;
    public float timeInvicible = 2.0f;
    bool isInvincible;
    float InvincibleTimer;
    Animator anim;
    Vector2 lookDirection = new Vector2(1, 0);
    public GameObject projectilePrefab;
    public float projectileForce = 300;

    // Start is called before the first frame update
    void Start()
    {
        rubyRB2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; //The current health is the max health available to the player=)
        anim = GetComponent<Animator>();
    }                                   

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //Get the horizontal input
        float vertical = Input.GetAxis("Vertical"); //Get the vertical input

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        anim.SetFloat("Speed", move.magnitude);

        Vector2 position = transform.position; //Makes a vector based on current position =O
        position = position + move * speed * Time.deltaTime;

        //transform.position = position; 
        //Saves the position to the current one =(
        rubyRB2D.MovePosition(position);

        if (isInvincible) //Invincible because the player has collided with damage
        {
            InvincibleTimer -= Time.deltaTime; //Count down the timer

            if (InvincibleTimer < 0) //The timer ended
            {
                isInvincible = false; //The player is vulnerable again
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }

    public void ChangeHealth (int amount) 
    {
        if (amount < 0) //As is nferior to 0, it means damage
        {
            if (isInvincible) //Already invinvible? Don't do anything
            {
                return;
            }
            isInvincible = true; //Make the player invincible
            InvincibleTimer = timeInvicible; //Resets the timer to the public value
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); //Limits the number between 0 and the max health =x
        Debug.Log(currentHealth + "/" + maxHealth);

       
        
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rubyRB2D.position * Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, projectileForce);

        anim.SetTrigger("Launch");
    }
}

