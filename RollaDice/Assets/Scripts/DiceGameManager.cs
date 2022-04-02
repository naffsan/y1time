
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceGameManager : MonoBehaviour
{
    public static DiceGameManager instance;

    private int currentTileIndex;//현재 칸 인덱스

    private int _diceNum;//남은 주사위 총 갯수
    public int diceNum 
    {
        set
        {
            if (value>=0)//남은 주사위 수를 0 이상으로만 세팅 가능


            {
                _diceNum = value;
                diceText.text = diceNum.ToString();//Text 업데이트
            }
        }
        get
        {
            return _diceNum;
        }
    }
    public Text diceText;//남은 주사위 개수 UI
    public int diceNumInit;//주사위 초기값

    public Text goldenDiceText;
    public Text starScoreText;
    public int _starScoreNum;
    private int _goldenDiceNum;//황금주사의 남은 갯수


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

    public int goldenDiceNum//황금주사위 프로퍼티
        //프로퍼티: 영희 주머니에서 돈을 꺼내는 게 아닌 물어봐서 돈을 꾸는 것과 비슷
        //-다른 객체 멤버를 수정하고싶으면 그 함수를 호출해서 수정해야 함
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

    public Coroutine animationCoroutine=null;


    private void Awake()
    {
        instance = this;
        diceNum = diceNumInit;
        goldenDiceNum=goldemDiceNumInit;
        starScore = 0;
    }

    public void RollADice()
    {
        if (diceNum < 1) return;
        if (animationCoroutine != null) return;
        diceNum--;


        int diceValue = Random.Range(1, 7);//최대값은 7로 설정되어있으나 구현 시에는 -1 된 다음 구현되므로
        //애초에 의도값보다 1 크게 집어넣어야 
        animationCoroutine= StartCoroutine(DicdAnimationUI.instance.E_DiceAnimation(diceValue,this,MovePlayer));
        MovePlayer(diceValue);
    }
    public void RollAGoldenDice(int diceValue)
    {
        if (goldenDiceNum < 1) return;
        if (animationCoroutine!=null) return;   
        goldenDiceNum--;
        animationCoroutine = StartCoroutine(DicdAnimationUI.instance.E_DiceAnimation(diceValue, this, MovePlayer));
        MovePlayer(diceValue);
    }
    private void MovePlayer(int diceValue)
    {
        int previousTileIndex = currentTileIndex;
        currentTileIndex += diceValue;

        CheckPlayerPassedStarTile(previousTileIndex,currentTileIndex);
        if (currentTileIndex >= mapTiles.Count)
            currentTileIndex-=mapTiles.Count;
        Player.instance.Move(GetTilePosition(currentTileIndex));
        mapTiles[currentTileIndex].GetComponent<TileInfo>().TlieEvent();
    }

    private void CheckPlayerPassedStarTile(int previousIndex, int currentIndex)
    {
        for (int i = previousIndex+1;i<currentIndex;i++)
        {
            
            if (mapTiles[i].TryGetComponent(out Tileinfo_Star tmpStarTile))
                starScore += tmpStarTile.starValue;
        }
    }
    private Vector3 GetTilePosition(int tileIndex)
    {
        return mapTiles[tileIndex].position;
    }
    

}