using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public FixedJoystick Joystick;

    public float Speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            var velocity = new Vector3(Joystick.Horizontal * Speed, Rigidbody.velocity.y, Joystick.Vertical * Speed);
            Rigidbody.velocity = velocity;

            transform.rotation = Quaternion.LookRotation(Rigidbody.velocity);
        }

    }
}
