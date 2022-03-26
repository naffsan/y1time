using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
// 총알과 충돌했을 시-콜라이더
//오브젝트와 충돌시키는 스크립트
{
    public GameObject destroyEffect;
    public LayerMask targetLayer;
    public int damage;
    public int score;

   

    public void DoDestroyEffect()
    {
        GameObject go = Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(go, 3);
    }




    public int _hp;
    public int hp
    {
        set
        {

            if (value>0)
                _hp = value;

            else
            {
                _hp = 0;
                Player.instance.score += score;
                DoDestroyEffect();
                Destroy(gameObject);
            }

           
            hpSlider.value = (float)_hp / hpMax;
            
        }
        get
        {
            return _hp;
        }
    }
    public int hpMax;
    public Slider hpSlider;

    private void Awake()
    {
        hp = hpMax;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            Player.instance.hp -= damage;
            Destroy(gameObject);
        }
        //collision.gameObject.GetComponent<Player>().Hurt();//coll.gameob하면 플레이어에 접근

        //얘는 같은 콜라이더나 오브젝트가 아닌 강체와 충돌한다

        //
    }
}
