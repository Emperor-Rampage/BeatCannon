using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    public bool Activated = false;
    public GameObject child;

    float deltaRotation;
    float previousRotation;
    float currentRotation;
    int timer = 0;

    private void Start()
    {
        child.SetActive(false);
    }

    void Update()
    {
        if (timer >= 0)
        {
            timer--;
        } 
    }

    private void OnMouseDown()
    {

        //Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseWorldPos();

        deltaRotation = 0f;
        previousRotation = angleBetweenPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        timer += 15;
    }

    private void OnMouseUp()
    {
        if(timer > 0)
        {
            timer = 0;
            if(Activated == false)
            {
                Activated = true;
                child.SetActive(true);
            }
            else
            {
                Activated = false;
                child.SetActive(false);
            }
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        //pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate == 0 as we're only moving things on the x and y axis.
        mousePoint.z = 0;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if( Activated == false)      
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }

    public void rotatePaddle()
    {
        currentRotation = angleBetweenPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        deltaRotation = Mathf.DeltaAngle(currentRotation, previousRotation);
        previousRotation = currentRotation;
        transform.Rotate(Vector3.back, deltaRotation);
    }

    float angleBetweenPoints(Vector2 position1, Vector2 position2)
    {
        var fromLine = position2 - position1;
        var toLine = new Vector2(1, 0);

        var angle = Vector2.Angle(fromLine, toLine);
        var cross = Vector3.Cross(fromLine, toLine);

        // did we wrap around?
        if (cross.z > 0)
            angle = 360f - angle;

        return angle;
    }

}
