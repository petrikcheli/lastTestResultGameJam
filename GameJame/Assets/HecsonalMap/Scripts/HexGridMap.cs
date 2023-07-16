using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HexGridMap: MonoBehaviour
{
    public int width = 8;
    public int height = 10;

    public Transform[] NextLevel; // клетка при которой перебрасывает на следующий уровень

    public Transform[] Obstacles; // препядствия

    public Transform Player;

    //public Transform Vrag;

    public HexCell cellPrefab; // префаб клетки

    public HexMesh hexMesh; // 

    //public ClikerHexMap cliker;

    public TMP_Text cellLabelPrefab;

    Canvas gridCanvas;

    public static HexCell[] cells;

    static Vector3 LastPlayer;
    static Vector3 NewPlayer;

    int NextGameCount = 4;

    static Vector3 LastVrag;
    static Vector3 NewVrag;

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();

        cells = new HexCell[height * width];

        hexMesh = GetComponentInChildren<HexMesh>();

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void Start()
    {
        hexMesh.Triangulate(cells);
        //cliker.incializate(cells);
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

        TMP_Text label = Instantiate<TMP_Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeparateLines();
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
            Thread.Sleep(200);
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

        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);//координаты гекса на который мы нажали

        HexCoordinates[] coordinatesObstacles = new HexCoordinates[104];

        for (int i = 0; i < Obstacles.Length; i++)
        {
            coordinatesObstacles[i] = HexCoordinates.FromPosition(transform.InverseTransformPoint(Obstacles[i].position));
        }
        HexCoordinates[] nextGame = new HexCoordinates[16];
        for (int i = 0; i < NextLevel.Length; i++)
        {
            nextGame[i] = HexCoordinates.FromPosition(transform.InverseTransformPoint(NextLevel[i].position));
        }

        Vector3 lastPlayerPosition1 = Player.position;
        lastPlayerPosition1 = transform.InverseTransformPoint(lastPlayerPosition1);
        HexCoordinates lastPlayerPosition = HexCoordinates.FromPosition(lastPlayerPosition1);



        //Vector3 coordinatesVragVec = Vrag.position;
        //coordinatesVragVec = transform.InverseTransformPoint(coordinatesVragVec);
        //HexCoordinates coordinateVrag = HexCoordinates.FromPosition(coordinatesVragVec);
        //LastVrag = NewVrag;

        Vector3 coordinatesPlayerVec = Player.position;
        coordinatesPlayerVec = transform.InverseTransformPoint(coordinatesPlayerVec); // точно не знаю, что оно делает, но как то редактирует координаты, чтобы после они нормально обработались в методе FromPosition
        HexCoordinates coordinatesPlayer = HexCoordinates.FromPosition(coordinatesPlayerVec);
        LastPlayer = NewPlayer;

        //Kosti countWalk = new Kosti();
        //Vector3Int[] tempVector = countWalk.RandomKosti(coordinatesPlayer);

        Vector3Int[] tempVector = new Vector3Int[6]
        {
            new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y + 1, coordinatesPlayer.Z),
            new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y - 1, coordinatesPlayer.Z),
            new Vector3Int(coordinatesPlayer.X - 1, coordinatesPlayer.Y, coordinatesPlayer.Z + 1),
            new Vector3Int(coordinatesPlayer.X + 1, coordinatesPlayer.Y, coordinatesPlayer.Z - 1),
            new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y + 1, coordinatesPlayer.Z - 1),
            new Vector3Int(coordinatesPlayer.X, coordinatesPlayer.Y - 1, coordinatesPlayer.Z + 1)
        };


        bool flag2 = true;
        for (int k = 0; k < nextGame.Length; k++)
        {
            if (!(nextGame[k].X == coordinates.X && nextGame[k].Z == coordinates.Z && nextGame[k].Y == coordinates.Y))
            {
                continue;
            }
            else
            {
                flag2 = false;
                Debug.Log("false");
                break;
            }
        }


        bool flag = true;

        for (int k = 0; k < coordinatesObstacles.Length; k++)
        {
            if (!(coordinatesObstacles[k].X == coordinates.X && coordinatesObstacles[k].Z == coordinates.Z && coordinatesObstacles[k].Y == coordinates.Y))
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

        for (int i = 0; i < cells.Length; i++)
        {
            Vector3Int vec = new Vector3Int(cells[i].coordinates.X, cells[i].coordinates.Y, cells[i].coordinates.Z);// вектор объекта массива одного блока из поля
            if (vec.x == coordinates.X && vec.z == coordinates.Z && vec.y == coordinates.Y)
            {
                for (int j = 0; j < tempVector.Length; j++)
                {
                    if ((tempVector[j].x == coordinates.X && tempVector[j].z == coordinates.Z && tempVector[j].y == coordinates.Y) && flag)
                    {
                        Player.position = cells[i].transform.position;

                        NewPlayer = Player.position;
                        Vector3 newVectorPlayer = Player.position;
                        newVectorPlayer = transform.InverseTransformPoint(newVectorPlayer);
                        HexCoordinates newCoordinatePlayer = HexCoordinates.FromPosition(newVectorPlayer);
                        if (newCoordinatePlayer.X == lastPlayerPosition.X && newCoordinatePlayer.Y == lastPlayerPosition.Y && newCoordinatePlayer.Z == lastPlayerPosition.Z)
                        {
                            Heath.heath = Heath.heath - 1;
                            Debug.Log("lolololo");
                        }
                        //Vrag.position = mob.Walk(cells, newCoordinatePlayer, coordinateVrag, Vrag.position, coordinatesObstacles).transform.position;
                        //Vrag.position = //mob.Walk(cells, newCoordinatePlayer, coordinateVrag, Vrag.position, coordinatesObstacles).transform.position;
                        //NewVrag = Vrag.position;
                        if (flag2)
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;
                    }
                }
                break;
            }
        }
        //if (LastVrag == NewVrag && !(NewPlayer == LastPlayer))
        //{
        //    Vrag.gameObject.SetActive(false);
        //}
        if (NewPlayer == LastPlayer)
        {
            Heath.heath = Heath.heath - 1;
        }
        Debug.Log("touched at " + coordinates.ToString());
    }
}
