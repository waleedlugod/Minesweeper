using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public Sprite bombSprite;
    public Sprite cellSprite;
    public Sprite backgroundSprite;

    public Vector2 dimensions;
    public ushort bombAmount;

    [SerializeField]
    private Dictionary<Vector2, Cell> coordsToCell;
    [SerializeField]
    private List<Cell> bombs;

    // Create singleton
    private CellManager() {}
    public static CellManager Instance { get { return Singleton.instance; } }

    private void Start()
    {
        GenerateBoard();
    }

    public void ExplodeAllBombs()
    {
        foreach (Cell bomb in bombs)
        {
            ChangeCell(bomb, "bomb");
        }

        // Game is lost
    }

    public void ChangeCell(Cell cell, string type)
    {
        switch (type)
        {
            case "radar":
                break;
            case "flag":
                break;
            case "bomb":
                cell.GetComponent<SpriteRenderer>().sprite = bombSprite;
                break;
        }
    }

    public void RevealCell(Cell cell)
    {
        // Reveal amount of adjacent bombs
        // If no bombs are adjacent, reveal all surrounding cells
    }

    private void GenerateBoard()
    {
        coordsToCell = new Dictionary<Vector2, Cell>();
        for (int x = 0; x < dimensions.x; x++)
        {
            for (int y = 0; y < dimensions.y; y++)
            {
                // Create cell sprite with offsets
                GameObject cellObject = Instantiate(cellPrefab, transform, true);

                // Offset the cells so that the edges are touching and none are overlapping.
                Vector3 cellSize = cellObject.GetComponent<SpriteRenderer>().bounds.size;
                cellObject.transform.position = new Vector2(
                    cellObject.transform.position.x + x * cellSize.x
                    , cellObject.transform.position.y + y * cellSize.y);

                coordsToCell.Add(new Vector2(x, y), cellObject.GetComponent<Cell>());
            }
        }
    }

    private void GenerateBombs()
    {
        Vector2 coordinate = new Vector2();

        for (int i = 0; i < bombAmount; i++)
        {
            Cell cell;
            do
            {
                do
                {
                    // Generate random coordinate

                    coordsToCell.TryGetValue(coordinate, out cell);
                } while (cell == null);
            } while (cell.isBomb);
            

            cell.isBomb = true;
            ChangeCell(cell, "bomb");

            bombs.Add(cell);
        }
    }

    // Create singleton
    private class Singleton
    {
        // Explicit static constructor to tell C# compiler not to mark types as beforefieldinit
        static Singleton() {}
        internal static readonly CellManager instance = new CellManager();
    }
}
