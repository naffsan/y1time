using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알이 나가야 하니 속도와 방향이 있어야 함
    public Vector3 dir=Vector3.forward;//여기서 dir은 나가는 방향...3차원이고 각 방향만큼 얼만큼 이동할지 입력하면 그만큼의 속력으로 나가게 됨
    public float speed=5f;
     Transform tr;

    private void Awake() => tr = GetComponent<Transform>();//
                                                           //한줄이면 이렇게 코드 줄여쓰기가능
   
    private void FixedUpdate()=> tr.Translate(dir * speed * Time.fixedDeltaTime);//총알 움직이기-움직이는건 translate함수로 하는거


    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go == null) return;
        if(go.layer==LayerMask.NameToLayer("Enemy"))
        {
            Destroy(go);
            Destroy(gameObject);
        }
    }
}
