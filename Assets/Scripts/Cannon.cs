using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Ball;
    public void FireBall()
    {
        iTween.PunchScale(gameObject, new Vector3(.1f, .1f, 0), 0.8f);
        GameObject tempBall = Instantiate(Ball, transform.localPosition, transform.rotation);
        tempBall.GetComponent<BallController>().InitialMovement(transform.up);
    }
}
