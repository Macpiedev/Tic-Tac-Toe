using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public TileController tileController;


    public int chooseTile() {
        List<int> tileIds = tileController.availableTilesId();
        int randInt = Random.Range(0, tileIds.Count - 1);
        StartCoroutine(ExecuteAfterTime(2));

        return tileIds[randInt];
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

    }   
}
