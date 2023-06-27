using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WheelMovement : MonoBehaviour
{
    public float R1;
    public float R2;
    public float mass1, mass2, mass3;
    public float len;


    private float delta = 0.24f;
    private float g = 9.8f;
    private float m0;
    private float h;
 
    private GameObject anWheel;
    private Rigidbody2D wheel1;
    private Rigidbody2D wheel2;

    // Start is called before the first frame update
    void Start()
    {
        anWheel = GameObject.Find("Wheel2");
        wheel1 = GetComponent<Rigidbody2D>();
        wheel2 = anWheel.GetComponent<Rigidbody2D>();
        m0 = mass1 + mass2 + mass3;
        h = m0 + (1 / 2) * mass1 + (1 / 2) * mass2;
   
    }

    // Update is called once per frame
    void Update()
    {
        float M = (float)(67 - Time.time);
        float M1 = (float)(33.5f * Math.Pow(Time.time, 2) - Math.Pow(Time.time, 3) / 6);
        

        Vector2 v1 = new Vector2((float)((1 / R1 * h) *M1 - (m0 * g * delta * (1 / R1 + 1 / R2) * Math.Pow(Time.time, 2)) / 2*h), 1);
        Vector2 v2 = new Vector2((float)((1 / R1 * h) *M1 - ((m0 * g * delta * (1 / R1 + 1 / R2) * Math.Pow(Time.time, 2)) / 2*h) + (wheel2.transform.position.x - wheel1.transform.position.x)), 1);

        
        wheel1.transform.position = v1;
        wheel2.transform.position = v2;

        
    }
}
