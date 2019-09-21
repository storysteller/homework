using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Transform center;    
    public float revolution;        
    public float rotation;        
    public float ry, rz;        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 axis = new Vector3(0, ry, rz);    
        this.transform.RotateAround(center.position, axis, revolution * Time.deltaTime); 
        this.transform.Rotate(Vector3.up * rotation * Time.deltaTime);    
    } 

}
