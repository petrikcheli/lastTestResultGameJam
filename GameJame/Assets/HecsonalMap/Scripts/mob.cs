using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;


public class mob : MonoBehaviour
{
    public Transform Vrag;

    public static HexCell Walk(HexCell[] cells, HexCoordinates coordinatePlayer, HexCoordinates coordinateVrag, Vector3 vecVrag, HexCoordinates[] coordinatesObstacles)
    {

        Vector3Int[] tempVector = new Vector3Int[6]
        {
            new Vector3Int(coordinateVrag.X - 1, coordinateVrag.Y + 1, coordinateVrag.Z),// лево 0
            new Vector3Int(coordinateVrag.X + 1, coordinateVrag.Y - 1, coordinateVrag.Z),//право 1
            new Vector3Int(coordinateVrag.X - 1, coordinateVrag.Y, coordinateVrag.Z + 1),// влево вверх 2
            new Vector3Int(coordinateVrag.X + 1, coordinateVrag.Y, coordinateVrag.Z - 1),// вниз вправо 3
            new Vector3Int(coordinateVrag.X, coordinateVrag.Y + 1, coordinateVrag.Z - 1),// вниз влево 4
            new Vector3Int(coordinateVrag.X, coordinateVrag.Y - 1, coordinateVrag.Z + 1)// ввверх право 5
        };


        for (int i = 0; i < tempVector.Length; i++)
        {
            if((coordinatePlayer.X == tempVector[i].x && coordinatePlayer.Z == tempVector[i].z && coordinatePlayer.Y == tempVector[i].y))
            {
                for (int y = 0; y < cells.Length; y++)
                {
                    Vector3Int vec2 = new Vector3Int(cells[y].coordinates.X, cells[y].coordinates.Y, cells[y].coordinates.Z);// вектор объекта массива одного блока из поля
                    if (vec2.x == coordinateVrag.X && vec2.z == coordinateVrag.Z && vec2.y == coordinateVrag.Y)
                    {
                        return cells[y];
                    }
                }
            }

        }
           
        Vector3Int NextPositionVrag = MinWalk(coordinatePlayer, coordinateVrag, tempVector);
        bool flag = true;

        for (int k = 0; k < coordinatesObstacles.Length; k++)
        {
            if (!(coordinatesObstacles[k].X == NextPositionVrag.x && coordinatesObstacles[k].Z == NextPositionVrag.z && coordinatesObstacles[k].Y == NextPositionVrag.y) )
            {
                continue;
            }
            else
            {
                flag = false;
                Debug.Log("false");
                break;
            }
        }
        HexCell result;
        for (int i = 0; i < cells.Length; i++)
        {
            Vector3Int vec = new Vector3Int(cells[i].coordinates.X, cells[i].coordinates.Y, cells[i].coordinates.Z);// вектор объекта массива одного блока из поля
            if (vec.x == NextPositionVrag.x && vec.z == NextPositionVrag.z && vec.y == NextPositionVrag.y)
            {
                for (int j = 0; j < tempVector.Length; j++)
                {
                    if ((tempVector[j].x == NextPositionVrag.x && tempVector[j].z == NextPositionVrag.z && tempVector[j].y == NextPositionVrag.y) && flag)
                    {
                        return cells[i];
                    }
                }
                break;
            }
        }
        return null;
    }

    public static Vector3Int MinWalk(HexCoordinates coordinatePlayer, HexCoordinates vecVrag, Vector3Int[] tempVector)
    {    

        for (int i = 0; i < tempVector.Length; i++)
        {
            if (coordinatePlayer.X < tempVector[i].x && coordinatePlayer.Y > tempVector[i].y && coordinatePlayer.Z == tempVector[i].z)//1
            {
                return tempVector[0];// влево
            }
            if (coordinatePlayer.X > tempVector[i].x && coordinatePlayer.Y < tempVector[i].y && coordinatePlayer.Z == tempVector[i].z)//
            {
                return tempVector[1]; // право
            }
            if (coordinatePlayer.X == tempVector[i].x && coordinatePlayer.Y < tempVector[i].y && coordinatePlayer.Z > tempVector[i].z)//
            {
                return tempVector[5]; // вправо вверх
            }
            if (coordinatePlayer.X < tempVector[i].x && coordinatePlayer.Y == tempVector[i].y && coordinatePlayer.Z > tempVector[i].z)
            {
                return tempVector[2]; // влево вверх
            }
            if (coordinatePlayer.X == tempVector[i].x && coordinatePlayer.Y > tempVector[i].y && coordinatePlayer.Z < tempVector[i].z)
            {
                return tempVector[4]; // влево вниз
            }
            if(coordinatePlayer.X > tempVector[i].x && coordinatePlayer.Y == tempVector[i].y && coordinatePlayer.Z < tempVector[i].z)
            {
                return tempVector[3]; // вправо вниз
            }
            if(coordinatePlayer.X == tempVector[i].x && coordinatePlayer.Y == tempVector[i].y && coordinatePlayer.Z == tempVector[i].z)
            {
                return tempVector[i];
            }
        }
        return tempVector[3];
        
    }
}
