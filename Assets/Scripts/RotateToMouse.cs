using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateToMouse : MonoBehaviour
{

    public Transform cube;
    public bool Activated = false;

    float deltaRotation;
    float previousRotation;
    float currentRotation;

    void Update()
    {
        if (Activated)
        { 
            if (Input.GetMouseButtonDown(0))
            {
                deltaRotation = 0f;
                previousRotation = angleBetweenPoints(cube.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Input.GetMouseButton(0))
            {
                currentRotation = angleBetweenPoints(cube.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                deltaRotation = Mathf.DeltaAngle(currentRotation, previousRotation);
                previousRotation = currentRotation;
                cube.Rotate(Vector3.back, deltaRotation);
            }
        }
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
