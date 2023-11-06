using TMPro;
using UnityEngine;

public class MatchScore : MonoBehaviour
{
    public TMP_Text wins;
    public TMP_Text loses;

    void Start() {
        wins.text = "Wins: " + PlayerPrefs.GetInt("wins").ToString();
        loses.text = "Loses: " + PlayerPrefs.GetInt("loses").ToString();
    }

    public void newWin() {
        PlayerPrefs.SetInt("wins", PlayerPrefs.GetInt("wins") + 1);
    }

    public void newLose() {
        PlayerPrefs.SetInt("loses", PlayerPrefs.GetInt("loses") + 1);
    }
}
