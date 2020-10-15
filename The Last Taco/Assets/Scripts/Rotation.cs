using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotz;
    public float RotationSpeed;
    public bool ClockWiseeRotation;

    void Update()
    {
        if(ClockWiseeRotation == false)
        {
            rotz += Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotz += -Time.deltaTime * RotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0,0,rotz);

    }
}
