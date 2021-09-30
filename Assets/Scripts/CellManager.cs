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

    private Dictionary<Vector2, Cell> positionToCell;
    private List<Cell> bombs;

    private CellManager() {}
    public static CellManager Instance { get { return Singleton.instance; } }

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
                break;
        }
    }

    private void GenerateBoard()
    {
        for (int x = 0; x < dimensions.x; x++)
        {
            for (int y = 0; y < dimensions.y; y++)
            {
                // Create cell sprite with offsets
                // Add cell to positionToCell
                // Create background with -1 less rendering order
                // Make background child of cell
            }
        }
    }

    private void GenerateBombs()
    {
        Vector2 position = new Vector2();

        for (int i = 0; i < bombAmount; i++)
        {
            Cell cell;

            do
            {
                // Generate random position
                positionToCell.TryGetValue(position, out cell);
            } while (cell.isBomb || cell == null);

            cell.isBomb = true;
            ChangeCell(cell, "bomb");
        }
    }

    private class Singleton
    {
        // Explicit static constructor to tell C# compiler not to mark types as beforefieldinit
        static Singleton() {}
        internal static readonly CellManager instance = new CellManager();
    }
}
