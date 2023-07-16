using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kosti : MonoBehaviour
{
    int count;
    public Vector3Int[] RandomKosti(HexCoordinates coordinatesPlayer)
    {
        System.Random random = new System.Random();
        count = random.Next(1, 3);
        //Vector3 coordinatesPlayerVec = Player.position;
        //coordinatesPlayerVec = transform.InverseTransformPoint(coordinatesPlayerVec); // точно не знаю, что оно делает, но как то редактирует координаты, чтобы после они нормально обработались в методе FromPosition
        //HexCoordinates coordinatesPlayer = HexCoordinates.FromPosition(coordinatesPlayerVec);
        Vector3Int[] resultVector = new Vector3Int[(6*(count+1)) - 1];

        if (count == 1)
        {
            Vector3Int[] tempVector1 = new Vector3Int[6]
            {
                new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y + 1, coordinatesPlayer.Z),
                new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y - 1, coordinatesPlayer.Z),
                new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y, coordinatesPlayer.Z + 1),
                new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y, coordinatesPlayer.Z - 1),
                new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y + 1, coordinatesPlayer.Z - 1),
                new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y - 1, coordinatesPlayer.Z + 1)
            };
            resultVector = tempVector1;
        }
        if (count == 2)
        {
            resultVector = count2(coordinatesPlayer);
        }
        if(count == 3)
        {
            resultVector = count3(coordinatesPlayer); 
        }
        return resultVector;

    }

    Vector3Int[] count2(HexCoordinates coordinatesPlayer)
    {
        Vector3Int[] resultVector = new Vector3Int[18];
        for (int i = 0; i < count; i++)
        {
            if (count == 1)
            {
                Vector3Int[] tempVector1 = new Vector3Int[6]
                {
                    new Vector3Int(coordinatesPlayer.X - i, coordinatesPlayer.Y + i, coordinatesPlayer.Z),
                    new Vector3Int(coordinatesPlayer.X + i, coordinatesPlayer.Y - i, coordinatesPlayer.Z),
                    new Vector3Int(coordinatesPlayer.X - i, coordinatesPlayer.Y, coordinatesPlayer.Z + i),
                    new Vector3Int(coordinatesPlayer.X + i, coordinatesPlayer.Y, coordinatesPlayer.Z - i),
                    new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y + i, coordinatesPlayer.Z - i),
                    new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y - i, coordinatesPlayer.Z + i)
                };
                for (int y = 0; y < 6 * count; y++)
                {
                    resultVector[y] = tempVector1[y];
                }
            }
            if (count == 2)
            {
                Vector3Int[] tempVector1 = new Vector3Int[6]
                 {
                    new Vector3Int(coordinatesPlayer.X - i, coordinatesPlayer.Y + i, coordinatesPlayer.Z),
                    new Vector3Int(coordinatesPlayer.X + i, coordinatesPlayer.Y - i, coordinatesPlayer.Z),
                    new Vector3Int(coordinatesPlayer.X - i, coordinatesPlayer.Y, coordinatesPlayer.Z + i),
                    new Vector3Int(coordinatesPlayer.X + i, coordinatesPlayer.Y, coordinatesPlayer.Z - i),
                    new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y + i, coordinatesPlayer.Z - i),
                    new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y - i, coordinatesPlayer.Z + i)
                };
                for (int y = 0; y < 6 * count; y++)
                {
                    if (i == 2)
                    {
                        resultVector[y] = tempVector1[y - 6];
                        continue;
                    }
                    resultVector[y] = tempVector1[y];
                }
                if (i == 2)
                {
                    Vector3Int[] tempVector2 = new Vector3Int[6]
                    {
                    new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y + 2, coordinatesPlayer.Z - 1),
                    new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y - 2, coordinatesPlayer.Z + 1),
                    new Vector3Int(coordinatesPlayer.X + 2, coordinatesPlayer.Y - 1, coordinatesPlayer.Z - 1),
                    new Vector3Int(coordinatesPlayer.X - 2, coordinatesPlayer.Y + 1, coordinatesPlayer.Z + 1),
                    new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y + 1, coordinatesPlayer.Z - 2),
                    new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y - 1, coordinatesPlayer.Z + 2)
                    };
                    for (int y = 0; y < 6; y++)
                    {
                        resultVector[y + 13] = tempVector2[y];
                    }
                }
            }
        }
        return resultVector;
    }

    Vector3Int[] count3(HexCoordinates coordinatesPlayer)
    {
        Vector3Int[] tempVector1 = new Vector3Int[18]
        {
                    new Vector3Int(coordinatesPlayer.X - 3, coordinatesPlayer.Y + 1, coordinatesPlayer.Z + 2),
                    new Vector3Int(coordinatesPlayer.X - 3, coordinatesPlayer.Y + 2, coordinatesPlayer.Z + 1),
                    new Vector3Int(coordinatesPlayer.X - 2, coordinatesPlayer.Y + 3, coordinatesPlayer.Z - 1),
                    new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y + 3, coordinatesPlayer.Z - 2),
                    new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y + 2, coordinatesPlayer.Z - 3),
                    new Vector3Int(coordinatesPlayer.X + 2, coordinatesPlayer.Y + 1, coordinatesPlayer.Z - 3),


                    new Vector3Int(coordinatesPlayer.X + 3, coordinatesPlayer.Y - 1, coordinatesPlayer.Z - 2),
                    new Vector3Int(coordinatesPlayer.X + 3, coordinatesPlayer.Y - 2, coordinatesPlayer.Z - 1),
                    new Vector3Int(coordinatesPlayer.X + 2, coordinatesPlayer.Y - 3, coordinatesPlayer.Z + 1),
                    new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y - 3, coordinatesPlayer.Z + 2),
                    new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y - 2, coordinatesPlayer.Z + 3),
                    new Vector3Int(coordinatesPlayer.X - 2, coordinatesPlayer.Y - 1, coordinatesPlayer.Z + 3),

                    new Vector3Int(coordinatesPlayer.X - 3, coordinatesPlayer.Y + 3, coordinatesPlayer.Z),
                    new Vector3Int(coordinatesPlayer.X + 3, coordinatesPlayer.Y - 3, coordinatesPlayer.Z),
                    new Vector3Int(coordinatesPlayer.X - 3, coordinatesPlayer.Y, coordinatesPlayer.Z + 3),
                    new Vector3Int(coordinatesPlayer.X + 3, coordinatesPlayer.Y, coordinatesPlayer.Z - 3),
                    new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y + 3, coordinatesPlayer.Z - 3),
                    new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y - 3, coordinatesPlayer.Z + 3)

        };

        Vector3Int[] resultVector = count2(coordinatesPlayer);

        for (int j = 0; j < tempVector1.Length; j++)
        {
            resultVector[j + 19] = tempVector1[j];
        }
        return resultVector;
    }

}
