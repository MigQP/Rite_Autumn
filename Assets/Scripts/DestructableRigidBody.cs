using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableRigidBody : MonoBehaviour
{
    /*Explosive force for object torn into pieces*/

    [SerializeField]
    Vector2 forceDirection;

    [SerializeField]
    int torque;

    Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(forceDirection);
        rb2D.AddTorque(torque);
    }

}
