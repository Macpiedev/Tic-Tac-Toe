using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public TileModel[] tiles;
    public bool gameOver = false;
    private string currentMove = "O";
    private int moveCount = 0;
    private int gridWidth = 3;

    void Start() {
        foreach (var tile in tiles) 
        {
            tile.changeText("");
        }
    }

    public void move(string tileName) {
        int tileIndex = tileName[tileName.Length-1] - '0';
        if(tiles[tileIndex - 1].getText() == "") {
            Debug.Log("Current move: " + currentMove);
            tiles[tileIndex - 1].changeText(currentMove);
            updateMove();
            updateGameStatus(tileIndex - 1);
            moveCount++;
        }
    }
    
    private string stateAt(int x, int y)
    {
        return tiles[x + gridWidth*y].getText();
    }


    private void updateGameStatus(int tileIndex) {
        int x = tileIndex % gridWidth;
        int y = tileIndex / gridWidth;
        

        checkColumns(x);
        checkRows(y);
        if(x == y) {
            checkDiagonal();
        }

        if(x + y == gridWidth - 1) {
            checkAntiDiagonal();
        }
          
    }

    private void checkColumns(int x) {
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
                gameOver = true;
                Debug.Log(gameOver);
            }
        }  
    }

    private void checkRows(int y) {
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
                gameOver = true;
                Debug.Log(gameOver);
            }
        }  
    }

    private void checkDiagonal() {
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
                gameOver = true;
                Debug.Log(gameOver);
            }
        }
    }

    private void checkAntiDiagonal() {
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
                gameOver = true;
                Debug.Log(gameOver);
            }
        }
    }

    private void updateMove() {
        if (currentMove == "O") {
            currentMove = "X";
        } else {
            currentMove = "O";
        }
    }
}
