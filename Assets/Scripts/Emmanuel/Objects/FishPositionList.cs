using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/PositionList")]
public class FishPositionList : ScriptableObject
{
    //positional offsets from the main fish
    [SerializeField]
    public List<Vector3> fishOffsets;
}
