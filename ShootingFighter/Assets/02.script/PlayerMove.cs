using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
    
{
    private Transform tr;

    Vector3 move;//hv �ް� ������ 0
    public float speed = 1f;
    // Ű���� ȭ��ǥ ���� ������ ����Ű�� x�๫��
    //���Ʒ� ����Ű�� z�๫��
    private void Awake()//start���� ���� �����
    {
        tr = GetComponent<Transform>();//�ѹ� �ҷ��ͼ� ĳ�̽�Ű��-������Ʈ�� �ڵ带 �մ� ¡�˴ٸ���
                                       //�̰� ���� �� ������ �������� ����


    }
  

   private void Update()//��� ��� ��ŭ �������� �ֱ�
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //���� Ű �Է��� �޾��� �� x z������ ������ �ְڴٴ� �ǹ�
        //�� hv�� ���� ������, ����� �����̴� �� �Ƚ��������Ʈ���� �ؾ� �ڿ�����
        move=new Vector3(h,0,v).normalized;//normalized�� ���⺤�ͷ� ����ϱ�/������ ���� �����̰� �ϱ�,
                                           //���� �ڿ������� �����̰��Ϸ��� �̰� ���� ��
    }
    private void FixedUpdate()//������ �����̽ÿ� �ϰ� ����ϱ�
    {
        tr.Translate(move*speed*Time.fixedDeltaTime);//�����̱�
                                                     //deltatime�� �� �����ӷ���Ʈ�� ������
                                                     //���� ������ ���� ������ �� ���̰� ���� ����� ��

    }

}//1. 