using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;
    private Transform myTransform;
    private Rigidbody rbody;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.constraints = RigidbodyConstraints.FreezeRotation;
        rbody.useGravity = false;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.AttractToPlane(gameObject);
    }
}
