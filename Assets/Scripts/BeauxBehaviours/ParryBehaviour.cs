using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryBehaviour : MonoBehaviour
{
    [SerializeField]
    float activeTime;

    public float parryFrames = 0;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (activeTime == null)
            activeTime = 1;
        parryFrames = activeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (parryFrames > 0)
        {
            parryFrames -= (Time.fixedDeltaTime);
        }
        else
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
            FishLifeBehaviour parryReset = GetComponent<FishLifeBehaviour>();
            parryReset.isParrying = false;
            this.enabled = false;
        }
    }
}
