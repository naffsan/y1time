using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicdAnimationUI : MonoBehaviour
{
    public static DicdAnimationUI instance;
    private void Awake()
    {
        instance = this;
    }
    public Image DiceAnimationImage;
    public float diceAnimationTime;//이미지가 돌아가는 시간
    //public List<Sprite> diceAnimationSprites = new List<Sprite>();//쪼개진 스프라이트 쓰기
    private Sprite[] sprites;
    public delegate void AnimationFinishedEvent(int diceValue);
        

    private void Start()
    {
        sprites=Resources.LoadAll<Sprite>("DiceVectorDark");//폴더호출

    }

    public IEnumerator E_DiceAnimation(int diceValue, DiceGameManager manager, AnimationFinishedEvent finishEvent)
    {
        float elapsedTime = 0;
        while (elapsedTime<diceAnimationTime)
        {
            elapsedTime += diceAnimationTime / 10;
            int tmpldx=Random.Range(0,sprites.Length);
            DiceAnimationImage.sprite = sprites[tmpldx];   
            yield return new WaitForSeconds(diceAnimationTime/10);//매 프레임마다 찍힘
        }
        DiceAnimationImage.sprite = sprites[diceValue - 1];
        if(finishEvent != null)
        finishEvent(diceValue);
        manager.animationCoroutine = null;
        //yield return null;//몇 바퀴 돌았는지 알려줌

    }




}
