using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{ //�ʵ��� �ν�����â ���� ����
  //public: �ܺ�Ŭ���� ���ٰ��� �ν����� ����
  //private: �ܺ�Ŭ���� ���ٺҰ� �ν����� �����
  //[HideInsperctor] public: �ܺ�Ŭ����  ���ٰ��� �ν����� �����
  // [SerializeField]private: �ܺ�Ŭ���� ���ٺҰ� �ν�����â ����



    //this Ű����
    //��ü �ڽ��� ��ȯ�ϴ� Ű����
    // Start is called before the first frame update
    public int a = 3;
    private Transform tr;
    public float moveSpeed;
    Vector3 move;

    private void Awake()
    {
        Debug.Log(this);
        Debug.Log(this.gameObject);
        Debug.Log(gameObject);
        tr = this.gameObject.GetComponent<Transform>();
        tr = GetComponent<Transform>();
        tr = transform;
        //��Ӱ� ǥ�õǴ°� ���������ϴ� �ǹ�->�׳� gameObject�� �ᵵ �ȴٴ� ��
    }
    void Start()
    {
        tr.position = Vector3.zero;
        transform.position = Vector3.zero;
        GetComponent<Transform>().position = Vector3.zero;
        gameObject.GetComponent<Transform>().position = Vector3.zero;
        this.gameObject.GetComponent<Transform>().position = Vector3.zero;

    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");
        Debug.Log($"h={h}, v={v}");
        move = new Vector3(h, 0, v);
    }
    // Update is called once per frame
    void FixedUpdate()
    {// ������ ���� �� ������ �� ��ȭ���� ������� �� 
        //�ð� �� ��ġ ��ȭ��(�ӵ�)=��ġ��ȭ��/�ð�
        //������ �ð� �� ��ġ ��ȭ��(������ ���� �ӵ�)=��ġ/������ �ð�
        //��ġ��ȭ��=������ �ð� �� ��ġ ��ȭ��*������ �ð�

        //tr.position += Vector3.forward*Time.deltaTime;
        //�� �����Ӹ��� �̸�ŭ �̵���Ű�ڴٴ� �ǹ�
        tr.position += move *moveSpeed* Time.fixedDeltaTime;
    }
}
