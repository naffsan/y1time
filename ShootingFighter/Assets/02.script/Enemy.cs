using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
// �Ѿ˰� �浹���� ��-�ݶ��̴�
//������Ʈ�� �浹��Ű�� ��ũ��Ʈ
{
    public GameObject destroyEffect;

    public void DoDestroyEffect()
    {
        GameObject go = Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(go, 3);
    }


private void OnTriggerEnter(Collider other)
    {

        //collision.gameObject.GetComponent<Player>().Hurt();//coll.gameob�ϸ� �÷��̾ ����

        //��� ���� �ݶ��̴��� ������Ʈ�� �ƴ� ��ü�� �浹�Ѵ�
        Destroy(gameObject);
        //
    }
   
}
