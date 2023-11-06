using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public TileModel[] tiles;
    private int moveCount = 0;
    private int gridWidth = 3;
    public bool win = false;

    void Start() {
        foreach (var tile in tiles) 
        {
            tile.changeText("");
        }
    }

    public void move(int tileId, string currentMove) {
        if(tiles[tileId].getText() == "") {
            changeState(tileId, currentMove);
            if(checkIfWin(tileId)) {
                win = true;
            }
            moveCount++;
        }
    }

    public void changeState(int tileId, string currentMove) {
        tiles[tileId].changeText(currentMove);
    }

    public void removeState(int tileId) {
        tiles[tileId].changeText("");
    }
    
    private string stateAt(int x, int y)
    {
        return tiles[x + gridWidth*y].getText();
    }

    public List<int> availableTilesId() {
        List<int> result = new List<int>();
        for(int i = 0; i < tiles.Length; i++ ) {
            if(tiles[i].getText() == "") {
                result.Add(i);
            }
        }

        return result;
    }

    public bool checkIfWin(int tileIndex) {
        int x = tileIndex % gridWidth;
        int y = tileIndex / gridWidth;
        
        bool result;
        result = checkColumns(x) || checkRows(y);

        if(x == y) {
            result = result || checkDiagonal();
        }

        if(x + y == gridWidth - 1) {
            result = result || checkAntiDiagonal();
        } 

        return result;
    }

    private bool checkColumns(int x) {
        string columnPreviousValue = stateAt(x,0);
        string columnNextValue;

        for(int i = 1; i < gridWidth; i++ ) {
            columnNextValue = stateAt(x,i);
            if  (columnNextValue != columnPreviousValue) {
                break;
            } else {
                columnPreviousValue = columnNextValue;
            }

            if (i == gridWidth - 1) {
                return true;
            }
        }  

        return false;
    }

    private bool checkRows(int y) {
        string rowPreviousValue = stateAt(0,y);
        string rowNextValue;

        for(int i = 1; i < gridWidth; i++ ) {
            rowNextValue = stateAt(i,y);
            if  (rowNextValue != rowPreviousValue) {
                break;
            } else {
                rowPreviousValue = rowNextValue;
            }

            if (i == gridWidth - 1) {
                return true;
            }
        }  
        
        return false;
    }

    private bool checkDiagonal() {
        string previousValue = stateAt(0, 0);
        string nextValue;

        for(int i = 1; i < gridWidth; i++ ) {
            nextValue = stateAt(i,i);
            if  (nextValue != previousValue) {
                break;
            } else {
                previousValue = nextValue;
            }

            if (i == gridWidth - 1) {
                return true;
            }
        }
        
        return false;
    }

    private bool checkAntiDiagonal() {
        string previousValue = stateAt(0, gridWidth - 1);
        string nextValue;

        for(int i = 1; i < gridWidth; i++ ) {
            nextValue = stateAt(i,  gridWidth - 1 - i);
            if  (nextValue != previousValue) {
                break;
            } else {
                previousValue = nextValue;
            }

            if (i == gridWidth - 1) {
                return true;
            }
        }
        
        return false;
    }
}
