using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rubyRB2D;
    
    // Start is called before the first frame update
    void Start()
    {
        rubyRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //Get the horizontal input
        float vertical = Input.GetAxis("Vertical"); //Get the vertical input

        Vector2 position = transform.position; //Makes a vector based on current position :O

        position.x = position.x + speed * horizontal * Time.deltaTime; //The position is equal to the same position but a little bit bigger XD
        position.y = position.y + speed * vertical * Time.deltaTime; //Called each second instead of each frame

        //transform.position = position; //Saves the position to the current one =(
        rubyRB2D.MovePosition(position);

        Debug.Log("horizontal" + horizontal); //See the values are you sending when pressing the key :))))
        Debug.Log("vertical" + vertical);
    }
}
