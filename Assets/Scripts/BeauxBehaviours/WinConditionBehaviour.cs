using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject fish;

    public float endOfLvl = 0;

    // Start is called before the first frame update
    void Start()
    {
        endOfLvl += this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (fish.transform.position.x >= endOfLvl)
        {
            SceneManager.LoadScene("GameWin");
        }
    }
}
