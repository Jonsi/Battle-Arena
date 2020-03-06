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

    private Vector3 _objectPos;
    private float _distance;

    public float ThrowForce = 600f;
    public bool CanPick = true; 
    public GameObject Item; 
    public GameObject TempParent; // the player module
    public bool Pickedup = false; 
    public Rigidbody Rigidbody1;

    void Update()
    {
        _distance = Vector3.Distance(Item.transform.position, TempParent.transform.position); 
        Pickup();
        if (_distance >= 30f) // if the player is farther then 30 unit away the item can not be pickedup
        {
            Pickedup = false;
        }

        if (Pickedup == true) // if the item is picked then set the object position based on player pos and movement
        {
            Rigidbody1.velocity = Vector3.zero;
            Rigidbody1.angularVelocity = Vector3.zero;
            Item.transform.SetParent(TempParent.transform);

            if (Input.GetKeyUp(KeyCode.E))
            {
                Rigidbody1.AddForce(TempParent.transform.forward * ThrowForce);
                Pickedup = false;
            }
        }
        else 
        {
            _objectPos = Item.transform.position;
            Item.transform.SetParent(null);
            Rigidbody1.useGravity = true;
            Item.transform.position = _objectPos;
        }

    }

    void Pickup()  
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (_distance <= 30f)
            {
                Pickedup = true;
                Rigidbody1.useGravity = false;
                //Rigidbody.detectcollisions = true;
            }


        }
    }

}
