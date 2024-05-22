using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Cell : MonoBehaviour
{
    public bool isMarked = false;
    public int posX;
    public int posY;

    [SerializeField] private Sprite mainSprite;
    [SerializeField] private Sprite XSprite;


    [Inject]
    private GridManager gridManager;

    [Inject]
    public void Construct(GridManager gridManager)
    {
        this.gridManager = gridManager;
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = mainSprite;
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
        //GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<SpriteRenderer>().sprite = XSprite;
    }

    public void UnmarkCell()
    {
        isMarked = false;
        //GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<SpriteRenderer>().sprite = mainSprite;
    }

    public class Factory : PlaceholderFactory<Cell> { }
}
