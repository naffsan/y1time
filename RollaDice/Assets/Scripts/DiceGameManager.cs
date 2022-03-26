
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceGameManager : MonoBehaviour
{
    private int currentTileIndex;
    private int _diceNum;
    public int diceNum 
    {
        set
        {
            if (value>=0)
            {
                _diceNum = value;
                diceText.text = diceNum.ToString();
            }
        }
        get
        {
            return _diceNum;
        }
    }
    public Text diceText;
    public int diceNumInit;

    public Text goldenDiceText;
    public Text starScoreText;
    public int _starScoreNum;
    private int _goldenDiceNum;

    public int starScoreNum
    {
        set
        {
            if (value >= 0)
            {
                _starScoreNum = value;
                starScoreText.text = starScoreNum.ToString();
            }
        }
        get
        {
            return (_starScoreNum);

        }
    }

    public int goldenDiceNum
    {
        set
        {
            if(value>=0)
            {
                _goldenDiceNum = value;
                goldenDiceText.text = goldenDiceNum.ToString();
            }
        }
        get
        {
            return (_goldenDiceNum);

        }
    }
    public int goldemDiceNumInit;
    public int starScore;


    public List<Transform> mapTiles;


    private void Awake()
    {
        diceNum = diceNumInit;
        goldenDiceNum=goldemDiceNumInit;
    }

    public void RollADice()
    {
        if (diceNum < 1) return;

        diceNum--;


        int diceValue = Random.Range(1, 7);
        MovePlayer(diceValue);
    }

    private void MovePlayer(int diceValue)
    {
       
        if (currentTileIndex >= mapTiles.Count)
            currentTileIndex-=mapTiles.Count;
        Player.instance.Move(GetTilePosition(currentTileIndex));
        
    }
    private Vector3 GetTilePosition(int tileIndex)
    {
        return mapTiles[tileIndex].position;
    }
    

}