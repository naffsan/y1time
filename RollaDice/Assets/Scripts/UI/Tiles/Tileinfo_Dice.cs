using System;
using UnityEngine;

public class Tileinfo_Dice : TileInfo
{

    
    public override void TlieEvent()
    {
        Debug.Log($"Index of the tile: {index}, Increase star value +1");
        DiceGameManager.instance.diceNum++;
    }
}
