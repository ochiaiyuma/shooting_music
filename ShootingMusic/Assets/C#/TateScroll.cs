using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TateScroll : MonoBehaviour
{
    //�X�N���[���X�s�[�h
    [SerializeField] float speed = 1;

    void Update()
    {
        //�������ɃX�N���[��
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Y��-11�܂ŗ���΁A21.33�܂ňړ�����
        if (transform.position.y <= -11.3f)
        {
            transform.position = new Vector2(0, 10f);
        }
    }
}