using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("object that entered the trigger: " + other);

        RubyController controller = other.GetComponent<RubyController>();
        //Get the player controller from the other thing collided with the trigger :v
        if (controller != null) //If the controller is not empty also, THE EXCLAMATION IS A NEGATION VALUE =O
        {   
            controller.ChangeHealth(-1); //Call the health function and rest 1 to the health of the 
        }
    }
}
