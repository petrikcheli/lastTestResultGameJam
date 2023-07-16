using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public Transform cell;
    public HexCoordinates coordinates;
    
    public void Start()
    {
        cell = GetComponent<Transform>();
    }
}
