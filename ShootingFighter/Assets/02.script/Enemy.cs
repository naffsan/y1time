using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
// �Ѿ˰� �浹���� ��-�ݶ��̴�
//������Ʈ�� �浹��Ű�� ��ũ��Ʈ
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
        //collision.gameObject.GetComponent<Player>().Hurt();//coll.gameob�ϸ� �÷��̾ ����

        //��� ���� �ݶ��̴��� ������Ʈ�� �ƴ� ��ü�� �浹�Ѵ�

        //
    }
}
