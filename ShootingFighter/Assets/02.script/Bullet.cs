using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�Ѿ��� ������ �ϴ� �ӵ��� ������ �־�� ��
    public Vector3 dir=Vector3.forward;//���⼭ dir�� ������ ����...3�����̰� �� ���⸸ŭ ��ŭ �̵����� �Է��ϸ� �׸�ŭ�� �ӷ����� ������ ��
    public float speed=5f;
     Transform tr;

    private void Awake() => tr = GetComponent<Transform>();//
                                                           //�����̸� �̷��� �ڵ� �ٿ����Ⱑ��
   
    private void FixedUpdate()=> tr.Translate(dir * speed * Time.fixedDeltaTime);//�Ѿ� �����̱�-�����̴°� translate�Լ��� �ϴ°�


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
