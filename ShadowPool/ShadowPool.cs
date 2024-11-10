using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;
    public GameObject Shadow;
    public int Shadow_count;
    public  Queue<GameObject> ShadowList = new Queue<GameObject>();
    private void Awake()
    {
        instance = this;
        FillPool();
    }
    public void FillPool()
    {
        for (int i = 0; i < Shadow_count; i++)
        {
            var newShadow = Instantiate(Shadow);//����Ԥ����
            newShadow.transform.SetParent(transform);//�ŵ��Ӽ�
            ReturnPool(newShadow);//���ض����
        }
    }
    public void ReturnPool(GameObject gameobject)
    {
        gameobject.SetActive(false);
        ShadowList.Enqueue(gameobject);//��ӵ������ĩ����
    }
    public GameObject GetFromPool()
    {
          if (ShadowList.Count == 0)
          {
              FillPool();
          }
          var outShadow = ShadowList.Dequeue();//�Ӷ����л��һ��Ԥ����
          outShadow.SetActive(true);
          return outShadow;
    }
}

