using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //�Ѿ��� ������ �ϴ� �ӵ��� ������ �־�� ��
    public Vector3 dir=Vector3.back;//���⼭ dir�� ������ ����...3�����̰� �� ���⸸ŭ ��ŭ �̵����� �Է��ϸ� �׸�ŭ�� �ӷ����� ������ ��
    public float speed = 1f;
    Transform tr;

    private void Awake() => tr = GetComponent<Transform>();//
                                                           //�����̸� �̷��� �ڵ� �ٿ����Ⱑ��

    private void FixedUpdate() => tr.Translate(dir * speed * Time.fixedDeltaTime);//�Ѿ� �����̱�-�����̴°� translate�Լ��� �ϴ°�

}
