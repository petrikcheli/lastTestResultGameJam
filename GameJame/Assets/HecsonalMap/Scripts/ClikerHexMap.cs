using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClikerHexMap : MonoBehaviour
{
    public Transform Player;
    public Transform[] Obstacles;
    public Transform NextLevel;
    public static HexCell[] cells;
    public HexMesh hexMesh;
    Canvas gridCanvas;

    public void incializate(HexCell[] hexCells)
    {
        cells = hexCells;
    }

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();


    }
    void Start()
    {
        Player = GetComponent<Transform>();
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
            Thread.Sleep(100);
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            TouchCell(hit.point);
        }
    }

    void TouchCell(Vector3 position)
    {

        position = new Vector3(position.x, position.z, position.y);//transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);//координаты гекса на который мы нажали
        HexCoordinates[] coordinatesObstacles = new HexCoordinates[31];
        for (int i = 0; i < Obstacles.Length; i++)
        {
            coordinatesObstacles[i] = HexCoordinates.FromPosition(new Vector3(Obstacles[i].position.x, Obstacles[i].position.z, Obstacles[i].position.y));
        }

        HexCoordinates obstacle1 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[0].position));
        HexCoordinates obstacle2 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[1].position));
        HexCoordinates obstacle3 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[2].position));
        HexCoordinates obstacle4 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[3].position));
        HexCoordinates obstacle5 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[4].position));
        HexCoordinates obstacle6 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[5].position));
        HexCoordinates obstacle7 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[6].position));
        HexCoordinates obstacle8 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[7].position));
        HexCoordinates obstacle9 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[8].position));
        HexCoordinates obstacle10 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[9].position));
        HexCoordinates obstacle11 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[10].position));
        HexCoordinates obstacle12 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[11].position));
        HexCoordinates obstacle13 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[12].position));
        HexCoordinates obstacle14 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[13].position));
        HexCoordinates obstacle15 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[14].position));
        HexCoordinates obstacle16 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[15].position));
        HexCoordinates obstacle17 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[16].position));
        HexCoordinates obstacle18 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[17].position));
        HexCoordinates obstacle19 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[18].position));
        HexCoordinates obstacle20 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[19].position));
        HexCoordinates obstacle21 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[20].position));
        HexCoordinates obstacle22 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[21].position));
        HexCoordinates obstacle23 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[22].position));
        HexCoordinates obstacle24 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[23].position));
        HexCoordinates obstacle25 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[24].position));
        HexCoordinates obstacle26 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[25].position));
        HexCoordinates obstacle27 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[26].position));
        HexCoordinates obstacle28 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[27].position));
        HexCoordinates obstacle29 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[28].position));
        HexCoordinates obstacle30 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[29].position));
        HexCoordinates obstacle31 = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[30].position));

        HexCoordinates nextGame = HexCoordinates.FromPosition(transform.InverseTransformPoint(NextLevel.position));

        Vector3 coordinatesPlayerVec = Player.position;
        coordinatesPlayerVec = new Vector3(coordinatesPlayerVec.x, coordinatesPlayerVec.z, coordinatesPlayerVec.y);//transform.InverseTransformPoint(coordinatesPlayerVec); // точно не знаю, что оно делает, но как то редактирует координаты, чтобы после они нормально обработались в методе FromPosition
        HexCoordinates coordinatesPlayer = HexCoordinates.FromPosition(coordinatesPlayerVec);


        Vector3Int[] tempVector = new Vector3Int[6]
        {
            new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y + 1, coordinatesPlayer.Z),
            new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y - 1, coordinatesPlayer.Z),
            new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y, coordinatesPlayer.Z + 1),
            new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y, coordinatesPlayer.Z - 1),
            new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y + 1, coordinatesPlayer.Z - 1),
            new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y - 1, coordinatesPlayer.Z + 1)
        };
        

        bool flag = true;

        for (int i = 0; i < cells.Length; i++)
        {
            Vector3 vec = new Vector3(cells[i].coordinates.X, cells[i].coordinates.Y, cells[i].coordinates.Z);// вектор "массива" всех координат
            if (vec.x == coordinates.X && vec.z == coordinates.Z && vec.y == coordinates.Y)
            {
                for (int j = 0; j < 6; j++)
                {
                    for(int k = 0;  k < coordinatesObstacles.Length; k++)
                    {
                        if ((tempVector[j].x == coordinates.X && tempVector[j].z == coordinates.Z && tempVector[j].y == coordinates.Y)
                        && !(coordinatesObstacles[i].X == coordinates.X && coordinatesObstacles[i].Z == coordinates.Z && coordinatesObstacles[i].Y == coordinates.Y))
                        {
                            continue;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    /*
                    if ((tempVector[j].x == coordinates.X && tempVector[j].z == coordinates.Z && tempVector[j].y == coordinates.Y)
                        && !(obstacle1.X == coordinates.X && obstacle1.Z == coordinates.Z && obstacle1.Y == coordinates.Y)
                        && !(obstacle2.X == coordinates.X && obstacle2.Z == coordinates.Z && obstacle2.Y == coordinates.Y)
                        && !(obstacle3.X == coordinates.X && obstacle3.Z == coordinates.Z && obstacle3.Y == coordinates.Y)
                        && !(obstacle4.X == coordinates.X && obstacle4.Z == coordinates.Z && obstacle4.Y == coordinates.Y)
                        && !(obstacle5.X == coordinates.X && obstacle5.Z == coordinates.Z && obstacle5.Y == coordinates.Y)
                        && !(obstacle6.X == coordinates.X && obstacle6.Z == coordinates.Z && obstacle6.Y == coordinates.Y)
                        && !(obstacle7.X == coordinates.X && obstacle7.Z == coordinates.Z && obstacle7.Y == coordinates.Y)
                        && !(obstacle8.X == coordinates.X && obstacle8.Z == coordinates.Z && obstacle8.Y == coordinates.Y)
                        && !(obstacle9.X == coordinates.X && obstacle9.Z == coordinates.Z && obstacle9.Y == coordinates.Y)
                        && !(obstacle10.X == coordinates.X && obstacle10.Z == coordinates.Z && obstacle10.Y == coordinates.Y)
                        && !(obstacle11.X == coordinates.X && obstacle11.Z == coordinates.Z && obstacle11.Y == coordinates.Y)
                        && !(obstacle12.X == coordinates.X && obstacle12.Z == coordinates.Z && obstacle12.Y == coordinates.Y)
                        && !(obstacle13.X == coordinates.X && obstacle13.Z == coordinates.Z && obstacle13.Y == coordinates.Y)
                        && !(obstacle14.X == coordinates.X && obstacle14.Z == coordinates.Z && obstacle14.Y == coordinates.Y)
                        && !(obstacle15.X == coordinates.X && obstacle15.Z == coordinates.Z && obstacle15.Y == coordinates.Y)
                        && !(obstacle16.X == coordinates.X && obstacle16.Z == coordinates.Z && obstacle16.Y == coordinates.Y)
                        && !(obstacle17.X == coordinates.X && obstacle17.Z == coordinates.Z && obstacle17.Y == coordinates.Y)
                        && !(obstacle18.X == coordinates.X && obstacle18.Z == coordinates.Z && obstacle18.Y == coordinates.Y)
                        && !(obstacle19.X == coordinates.X && obstacle19.Z == coordinates.Z && obstacle19.Y == coordinates.Y)
                        && !(obstacle20.X == coordinates.X && obstacle20.Z == coordinates.Z && obstacle20.Y == coordinates.Y)
                        && !(obstacle21.X == coordinates.X && obstacle21.Z == coordinates.Z && obstacle21.Y == coordinates.Y)
                        && !(obstacle22.X == coordinates.X && obstacle22.Z == coordinates.Z && obstacle22.Y == coordinates.Y)
                        && !(obstacle23.X == coordinates.X && obstacle23.Z == coordinates.Z && obstacle23.Y == coordinates.Y)
                        && !(obstacle24.X == coordinates.X && obstacle24.Z == coordinates.Z && obstacle24.Y == coordinates.Y)
                        && !(obstacle25.X == coordinates.X && obstacle25.Z == coordinates.Z && obstacle25.Y == coordinates.Y)
                        && !(obstacle26.X == coordinates.X && obstacle26.Z == coordinates.Z && obstacle26.Y == coordinates.Y)
                        && !(obstacle27.X == coordinates.X && obstacle27.Z == coordinates.Z && obstacle27.Y == coordinates.Y)
                        && !(obstacle28.X == coordinates.X && obstacle28.Z == coordinates.Z && obstacle28.Y == coordinates.Y)
                        && !(obstacle29.X == coordinates.X && obstacle29.Z == coordinates.Z && obstacle29.Y == coordinates.Y)
                        && !(obstacle30.X == coordinates.X && obstacle30.Z == coordinates.Z && obstacle30.Y == coordinates.Y)
                        && !(obstacle31.X == coordinates.X && obstacle31.Z == coordinates.Z && obstacle31.Y == coordinates.Y)
                        )
                    */
                    if(flag)
                    {
                        Player.position = cells[i].transform.position;
                        if (nextGame.X == coordinates.X && nextGame.Z == coordinates.Z && nextGame.Y == coordinates.Y)
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;
                    }
                }
                break;
            }
        }
        Debug.Log("touched at " + coordinates.ToString());
    }

}

