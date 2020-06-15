using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpringAdjustBehaviour : MonoBehaviour
{
    // what the variance will gravitate towards
    public float SpringForceMedian;

    public float SpringForceVariance;

    public float damper;
    public List<SpringJoint> springJoints;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var joint in springJoints)
        {
            joint.anchor = Vector3.zero;
            joint.connectedAnchor = joint.GetComponent<Rigidbody>().position;

            joint.spring = SpringForceMedian + Random.Range(-SpringForceVariance, SpringForceVariance);

        }
    }
}
