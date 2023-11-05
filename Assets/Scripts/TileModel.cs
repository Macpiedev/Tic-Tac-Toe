using TMPro;
using System;
using UnityEngine;

public class TileModel : MonoBehaviour
{
    public TMP_Text text;

    public void changeText(string text_) {
        text.text = text_;
    }

    public string getText() {
        return text.text;
    }
}
