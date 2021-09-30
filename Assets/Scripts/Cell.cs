using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isBomb = false;

    // Flagged cells cannot be interacted with
    private bool isFlagged = false;
    private bool isRevealed = false;

    private void OnMouseDown()
    {
        // If left click is pressed
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftClick();
        }
        // If right click is pressed
        else if (Input.GetMouseButtonDown(1))
        {
            HandleRightClick();
        }
    }

    private void HandleLeftClick()
    {
        if (!isFlagged && !isRevealed)
        {
            CellManager.Instance.ChangeCell(this, "radar");
            isRevealed = true;

            if (isBomb)
            {
                CellManager.Instance.ExplodeAllBombs();
            }
        }
    }

    private void HandleRightClick()
    {
        isFlagged = !isFlagged;
        CellManager.Instance.ChangeCell(this, "flag");
    }
}
