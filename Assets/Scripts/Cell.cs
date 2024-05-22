using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Cell : MonoBehaviour
{
    public bool isMarked = false;
    public int posX;
    public int posY;

    [Inject]
    private GridManager gridManager;

    [Inject]
    public void Construct(GridManager gridManager)
    {
        this.gridManager = gridManager;
    }

    void OnMouseDown()
    {
        gridManager.CellClicked(posX, posY);
    }

    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }

    public void MarkCell()
    {
        isMarked = true;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void UnmarkCell()
    {
        isMarked = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public class Factory : PlaceholderFactory<Cell> { }
}
