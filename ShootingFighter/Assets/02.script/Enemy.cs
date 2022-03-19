using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
// 총알과 충돌했을 시-콜라이더
//오브젝트와 충돌시키는 스크립트
{
    public GameObject destroyEffect;

    public void DoDestroyEffect()
    {
        GameObject go = Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(go, 3);
    }


private void OnTriggerEnter(Collider other)
    {

        //collision.gameObject.GetComponent<Player>().Hurt();//coll.gameob하면 플레이어에 접근

        //얘는 같은 콜라이더나 오브젝트가 아닌 강체와 충돌한다
        Destroy(gameObject);
        //
    }
   
}
