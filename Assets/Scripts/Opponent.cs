using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public TileController tileController;


    public int chooseTile(string sign, string oppositeSign) {
        List<int> tileIds = tileController.availableTilesId();
        
        foreach(var id in tileIds) {
            tileController.changeState(id, sign);
            if(tileController.checkIfWin(id)) {
                tileController.removeState(id);
                return id;
            }
            tileController.removeState(id);
        }

        foreach(var id in tileIds) {
            tileController.changeState(id, oppositeSign);
            if(tileController.checkIfWin(id)) {
                tileController.removeState(id);
                return id;
            }
            tileController.removeState(id);
        }
        int randInt = Random.Range(0, tileIds.Count - 1);

        return tileIds[randInt];
    }
}
