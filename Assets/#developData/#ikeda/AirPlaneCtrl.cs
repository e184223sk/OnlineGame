﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneCtrl : MonoBehaviour
{
    Rigidbody rigidbody_;
    public float Accel, Buoyancy;

    public float spin;

    public float a;

    [Range(-1,1)]
    public float b;
    public float c;


    [Range(-1, 1)]
    public float d;
    void Start()
    {
        rigidbody_ = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Key.JoyStickL.Get;
        Buoyancy += Time.deltaTime * Key.JoyStickR.Get.y;
       
        Accel += input.y * Time.deltaTime *a;
        if (-0.03 < Accel && Accel < 0.03) Accel = 0;
        if (Accel < -1000) Accel = -1000;
        if (Accel > 3000) Accel = 3000;
        Accel *= 0.97f;
        Buoyancy *= 0.97f;

        // 
        rigidbody_.AddRelativeTorque
        (
           Time.deltaTime * new Vector3
            (
                -Buoyancy * (Accel < 0 ? 0 : Accel) * c * (90 - Mathf.Abs(-transform.rotation.eulerAngles.x)) / 90,
                input.y * spin,
                0
            )
            , ForceMode.Impulse
        );
        ///  float xxx = -transform.rotation.eulerAngles.x; 
        /// Buoyancy += Time.deltaTime * (Mathf.Abs(xxx) > 45 ? xxx%45 : xxx); 
        rigidbody_.AddRelativeForce(new Vector3(0, 0, 1)* Accel * Time.deltaTime, ForceMode.Acceleration);
        rigidbody_.AddRelativeTorque(d * -Vector3.Scale(transform.rotation.ToEuler(), new Vector3(1, 0, 1)) * Accel * Time.deltaTime, ForceMode.Acceleration); //

    }
}
