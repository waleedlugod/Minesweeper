using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public Texture2D bombTexture;

    public Vector2 dimensions;

    private Dictionary<Vector2, Cell> positionToCell;
    private List<Cell> bombs;

    private CellManager() {}
    public static CellManager Instance { get { return Singleton.instance; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplodeAllBombs()
    {

    }

    public void Reveal(Cell cell)
    {

    }

    private void GenerateBoard()
    {

    }

    private void ChangeGraphic(Cell cell)
    {

    }

    private class Singleton
    {
        // Explicit static constructor to tell C# compiler not to mark types as beforefieldinit
        static Singleton() {}
        internal static readonly CellManager instance = new CellManager();
    }
}
