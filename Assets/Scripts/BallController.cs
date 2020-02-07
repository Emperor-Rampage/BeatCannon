using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject puff;
    public float Speed;
    int hit = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void InitialMovement(Vector3 firingAngle)
    {
        rb.velocity = firingAngle * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ++hit;
        int hitLayer = collision.gameObject.layer;
       
        if(hitLayer == 8)
        {
            collision.gameObject.GetComponent<Paddle>().ballImpact();
            //rb.velocity = Vector3.zero;
            //ContactPoint point = collision.contacts[0];
            //rb.velocity = (-point.point * Speed);
        }
        else if(hitLayer == 9)
        {
            Instantiate(puff, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if (hit >= Conductor.instance.WinBeats.Count)
        {
            Instantiate(puff, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * Speed;
    }
}
