using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollToggle : MonoBehaviour
{
    protected Animator Animator;
    protected Rigidbody Rigidbody;
    protected BoxCollider BoxCollider;
    protected MoveForward MoveForward;

    protected Collider[] ChildrenCollider;
    protected Rigidbody[] ChildrenRigidBody;


    void Awake()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        BoxCollider = GetComponent<BoxCollider>();
        MoveForward = GetComponent<MoveForward>();

        ChildrenCollider = GetComponentsInChildren<Collider>();
        ChildrenRigidBody = GetComponentsInChildren<Rigidbody>();
    }

    void Start()
    {
        RagdollActive(false);
    }

    void Update()
    {
        
    }

    public void RagdollActive(bool active)
    {
        //children
        foreach (var collider in ChildrenCollider)
            collider.enabled = active;
        foreach(var rigidbody in ChildrenRigidBody)
        {
            rigidbody.detectCollisions = active;
            rigidbody.isKinematic = !active;
        }

        //root
        Animator.enabled = !active;
        Rigidbody.detectCollisions = !active;
        Rigidbody.isKinematic = active;
        BoxCollider.enabled = !active;
        MoveForward.enabled = !active;

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.other.GetComponent<Combat_Trigger>() != null)
         {
             RagdollActive(true);
         }

         if (collision.other.gameObject.tag == "Hit")
         {
             //RagdollActive(true);
         }

         if(collision.other.gameObject.name == "Hitbox")
         {
             //RagdollActive(true);
         }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RagdollActive(true);
        }
    }
}
