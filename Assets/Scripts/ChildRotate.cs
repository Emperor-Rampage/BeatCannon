using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRotate : MonoBehaviour
{

    private DragObject DO;
    private Paddle paddle;
    private void Start()
    {
        DO = GetComponentInParent<DragObject>();
        paddle = GetComponentInParent<Paddle>();
    }

    private void OnMouseDrag()
    {
        if(DO.Activated == true)
        {
            DO.rotatePaddle();
            paddle.SetHue();
        }
    }

    private void OnMouseUp()
    {
        DO.Activated = false;
        gameObject.SetActive(false);
    }
}
