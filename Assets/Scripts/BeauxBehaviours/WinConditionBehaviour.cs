using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject fish;

    public Transform endOfLvl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fish.transform.position.x >= endOfLvl.position.x)
        {
            SceneManager.LoadScene("GameWin");
        }
    }
}
