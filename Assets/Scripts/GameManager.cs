
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string currentMove = "O";
    public float restartDelay = 1f;
    public TileController tileController;
    public Opponent opponent;
    public bool isPlayerMove = true;
    private int movesCounter = 0;

    public void playerMove(int tileId) {
        movesCounter++;
        if(movesCounter == 9) {
            gameOver();
        }
        isPlayerMove = false;
        tileController.move(tileId, currentMove);
        if(tileController.win) {
            gameOver();
        }
        updateMove();
        Invoke("opponentMove", 1.5f);
    }

    public void opponentMove() {
        movesCounter++;
        if(movesCounter == 9) {
            gameOver();
        }
        tileController.move(opponent.chooseTile(), currentMove);
        if(tileController.win) {
            gameOver();
        }
        updateMove();

        isPlayerMove = true;
    }

    public void updateMove() {
        if (currentMove == "O") {
            currentMove = "X";
        } else {
            currentMove = "O";
        }
    }

    public void gameOver() {
        Invoke("Restart", restartDelay);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
