
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string currentMove = "O";
    public float restartDelay = 1f;

    public string getCurrentMove() {
        return currentMove;
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
