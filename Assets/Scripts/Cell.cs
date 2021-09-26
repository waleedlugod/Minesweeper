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
            InteractLeftClick();
        }
        // If right click is pressed
        else if (Input.GetMouseButtonDown(1))
        {
            InteractRightClick();
        }
    }

    private void InteractLeftClick()
    {
        if (!isFlagged && !isRevealed)
        {
            // Call cell manager class to reveal cell contents
            isRevealed = true;

            if (isBomb)
            {
                // Call cell manager to change graphic to bomb
                // Call cell manager class to explode all bombs
            }
        }
    }

    private void InteractRightClick()
    {
        isFlagged = !isFlagged;
        // Call cell manager to change graphic to flagged
    }
}
