using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
    // �Ѿ˰� �浹���� ��-�ݶ��̴�
    //������Ʈ�� �浹��Ű�� ��ũ��Ʈ
{
    private void OnTriggerEnter(Collider other)
    {

        //collision.gameObject.GetComponent<Player>().Hurt();//coll.gameob�ϸ� �÷��̾ ����

        //��� ���� �ݶ��̴��� ������Ʈ�� �ƴ� ��ü�� �浹�Ѵ�
        Destroy(gameObject);
        //
    }
   
}
