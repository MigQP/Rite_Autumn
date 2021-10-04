using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : MonoBehaviour
{
    /*Leg IK SYSTEM FOR ANT
     
    It moves the individual target for each IK a certain amount once a distance has been covered*/

    public Transform limbSolverTarget;
    public float moveDistance;
    public LayerMask groundLayer;

    void Update()
    {
        CheckGround();

        if (Vector2.Distance(limbSolverTarget.position, transform.position) > moveDistance)
        {
            limbSolverTarget.position = transform.position;
 
        }

    }



    public void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector3.down, 5, groundLayer);

        if (hit.collider != null)
        {
            Vector3 point = hit.point;
            point.y += .1f;
            transform.position = point;

        }
    }
}