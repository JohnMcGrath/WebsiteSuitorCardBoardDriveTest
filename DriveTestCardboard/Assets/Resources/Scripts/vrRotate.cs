using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrRotate : MonoBehaviour {

    //Angle at which person is rotated
    public float angleOfRotation = 45;

   public void RotateLeft()
    {
        transform.Rotate(Vector3.up, -angleOfRotation);
    }

   public void RotateRight()
    {
        transform.Rotate(Vector3.up, angleOfRotation);
    }
}
