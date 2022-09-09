using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    public Transform CameraTransfrom;
    public float SpeedForward;
    public float SpeedStrafing;
    public float SpeedBackward;
    Transform Transform;
    Animator Animator;

    void Start() {
        Animator = GetComponent<Animator>();
        Transform = GetComponent<Transform>();
    }

    void Update() {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        xMovement *= SpeedStrafing;
        if (zMovement >= 0.0f){
            zMovement *= SpeedForward;
        }
        else {
            zMovement *= SpeedBackward;
        }

        Animator.SetFloat("x", xMovement);
        Animator.SetFloat("y", zMovement);
    }

    void OnAnimatorMove() {
        Transform.position += Animator.deltaPosition;

        Vector3 vec = new Vector3 (0.0f, 2.0f, -5.0f);
        CameraTransfrom.position = Transform.position + vec;
    }
}
