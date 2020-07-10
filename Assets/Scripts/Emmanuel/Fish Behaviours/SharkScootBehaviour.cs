
using System.Collections;

using UnityEngine;

public class SharkScootBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartScoot();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ScootUpCoroutine()
    {
        var time = 0f;
        while (time <= 6)
        {
            transform.localPosition += 0.2f * Time.deltaTime * new Vector3(5, 0, 0);
            time += Time.deltaTime;
            
            yield return 0;
        }


        
    }

    public void StartScoot()
    {
        StartCoroutine(ScootUpCoroutine());
    }
    
}
