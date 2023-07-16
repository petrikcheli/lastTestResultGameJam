using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCoordinate : MonoBehaviour
{
    public Transform[] Obstacles;
    public HexCoordinates[] hexCoordinateInMap;


    void Start()
    {

        for(int i = 0; i < Obstacles.Length; i++)
        {
            Vector3 positionHex = transform.InverseTransformPoint(Obstacles[i].position);
            hexCoordinateInMap[i] = HexCoordinates.FromPosition(positionHex);
        }
    }

    
}
