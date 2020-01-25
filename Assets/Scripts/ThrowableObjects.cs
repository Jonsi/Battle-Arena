using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObjects : InteractableObjects
{
    // the objects needs to be iteractable by clicking a key, being picked up  V
    // when he is picked up cannot be iteractble by other players
    // needs to have weight parameter for physics - using rigidbody for mass calc  V
    // speed parameter of moving changed by player stats V
    // needs to have a direction of throw V

    float ThrowForce = 600f; 
    Vector3 objectPos;
    float Distance; 

    public bool canPick = true; 
    public GameObject item; 
    public GameObject tempParent; // the player module
    public bool pickedup = false; 
    public Rigidbody Rigidbody1;

    void Update()
    {
        Distance = Vector3.Distance(item.transform.position, tempParent.transform.position); 
        Pickup();
        if (Distance >= 30f) // if the player is farther then 30 unit away the item can not be pickedup
        {
            pickedup = false;
        }

        if (pickedup == true) // if the item is picked then set the object position based on player pos and movement
        {
            Rigidbody1.velocity = Vector3.zero;
            Rigidbody1.angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetKeyUp(KeyCode.E))
            {
                Rigidbody1.AddForce(tempParent.transform.forward * ThrowForce);
                pickedup = false;
            }
        }
        else 
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            Rigidbody1.useGravity = true;
            item.transform.position = objectPos;
        }

    }

    void Pickup()  
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Distance <= 30f)
            {
                pickedup = true;
                Rigidbody1.useGravity = false;
                //Rigidbody.detectcollisions = true;
            }


        }
    }

}
