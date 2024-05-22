using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GridManager : MonoBehaviour
{
    public int gridSize = 5;
    private GameObject[,] grid;
    private float cellSize;
    private List<GameObject> markedCells = new List<GameObject>();
    private int matchCount = 0; // Eşleşme sayısını takip etmek için

    [Inject]
    private Cell.Factory cellFactory;

    public int MatchCount
    {
        get { return matchCount; }
    }

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        matchCount = 0; // Yeni grid oluşturulurken eşleşme sayısını sıfırlayın
        if (grid != null)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float cellSize = Mathf.Min(cameraWidth / gridSize, cameraHeight / gridSize);

        float gridWidth = gridSize * cellSize;
        float gridHeight = gridSize * cellSize;

        float offsetX = -cameraWidth / 2f + cellSize / 2f + (cameraWidth - gridWidth) / 2f;
        float offsetY = -cameraHeight / 2f + cellSize / 2f + (cameraHeight - gridHeight) / 2f;

        grid = new GameObject[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                float posX = x * cellSize + offsetX;
                float posY = y * cellSize + offsetY;

                Cell cell = cellFactory.Create();
                cell.transform.position = new Vector3(posX, posY, 0);
                cell.transform.parent = transform;
                cell.SetPosition(x, y);

                float cellPrefabWidth = cell.GetComponent<SpriteRenderer>().bounds.size.x;
                float cellPrefabHeight = cell.GetComponent<SpriteRenderer>().bounds.size.y;
                cell.transform.localScale = new Vector3(cellSize / cellPrefabWidth, cellSize / cellPrefabHeight, 1f);

                grid[x, y] = cell.gameObject;
            }
        }

        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -Camera.main.transform.position.z));
    }

    public void CellClicked(int x, int y)
    {
        GameObject cell = grid[x, y];
        if (!cell.GetComponent<Cell>().isMarked)
        {
            cell.GetComponent<Cell>().MarkCell();
            markedCells.Add(cell);
            CheckForMatches();
        }
    }

    void CheckForMatches()
    {
        List<GameObject> cellsToClear = new List<GameObject>();
        bool foundMatch = false; // Yeni bir eşleşme bulunduğunu takip etmek için

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                if (grid[x, y].GetComponent<Cell>().isMarked)
                {
                    List<GameObject> matches = GetMatches(x, y);
                    if (matches.Count >= 3)
                    {
                        foundMatch = true; // Yeni bir eşleşme bulundu
                        cellsToClear.AddRange(matches);
                    }
                }
            }
        }

        if (foundMatch)
        {
            matchCount++; // Yeni bir eşleşme bulunduysa sayaç artırılır
        }

        foreach (GameObject cell in cellsToClear)
        {
            cell.GetComponent<Cell>().UnmarkCell();
            markedCells.Remove(cell);
        }
    }

    List<GameObject> GetMatches(int startX, int startY)
    {
        List<GameObject> matches = new List<GameObject>();
        matches.Add(grid[startX, startY]);

        Vector2[] directions = { Vector2.right, Vector2.left, Vector2.up, Vector2.down };

        foreach (Vector2 dir in directions)
        {
            int x = startX + (int)dir.x;
            int y = startY + (int)dir.y;

            while (x >= 0 && x < gridSize && y >= 0 && y < gridSize && grid[x, y].GetComponent<Cell>().isMarked)
            {
                matches.Add(grid[x, y]);
                x += (int)dir.x;
                y += (int)dir.y;
            }
        }

        return matches;
    }
}
