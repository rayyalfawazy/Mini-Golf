using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    bool shoot;
    void Update()
    {
        var spaceKey = Input.GetKeyDown(KeyCode.Space);
        if (spaceKey)
        {
            shoot = true;
        }     
    }

    
    void FixedUpdate()
    {
        if (shoot)
        {
            shoot = false;
            Vector3 direction = Camera.main.transform.forward;
            direction.y = 0;
            rb.AddForce(direction * force, ForceMode.Impulse);
        }

        if (rb.velocity.sqrMagnitude < 0.01f && rb.velocity.sqrMagnitude > 0)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public bool IsMove()
    {
        return rb.velocity != Vector3.zero;
    }
}
