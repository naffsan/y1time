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
    public float diceAnimationTime;//�̹����� ���ư��� �ð�
    //public List<Sprite> diceAnimationSprites = new List<Sprite>();//�ɰ��� ��������Ʈ ����
    private Sprite[] sprites;
    public delegate void AnimationFinishedEvent(int diceValue);
        

    private void Start()
    {
        sprites=Resources.LoadAll<Sprite>("DiceVectorDark");//����ȣ��

    }

    public IEnumerator E_DiceAnimation(int diceValue, DiceGameManager manager, AnimationFinishedEvent finishEvent)
    {
        float elapsedTime = 0;
        while (elapsedTime<diceAnimationTime)
        {
            elapsedTime += diceAnimationTime / 10;
            int tmpldx=Random.Range(0,sprites.Length);
            DiceAnimationImage.sprite = sprites[tmpldx];   
            yield return new WaitForSeconds(diceAnimationTime/10);//�� �����Ӹ��� ����
        }
        DiceAnimationImage.sprite = sprites[diceValue - 1];
        if(finishEvent != null)
        finishEvent(diceValue);
        manager.animationCoroutine = null;
        //yield return null;//�� ���� ���Ҵ��� �˷���

    }




}
