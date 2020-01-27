using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2D;
    public bool isVertical;

    //timer
    float timer;
    int direction = 1;
    public float changeTime = 3.0f;

    //Animator Values
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rb2D.position;

        if (isVertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; //Same as isVertical == true; 

            anim.SetFloat("Move X", 0);
            anim.SetFloat("Move Y", direction);
        }

        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;

            anim.SetFloat("Move X", direction);
            anim.SetFloat("Move Y", 0);
        }

        rb2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

}