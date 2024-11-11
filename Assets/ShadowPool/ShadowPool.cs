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
            var newShadow = Instantiate(Shadow);//生成预制体
            newShadow.transform.SetParent(transform);//放到子集
            ReturnPool(newShadow);//返回对象池
        }
    }
    public void ReturnPool(GameObject gameobject)
    {
        gameobject.SetActive(false);
        ShadowList.Enqueue(gameobject);//添加到对象池末端中
    }
    public GameObject GetFromPool()
    {
          if (ShadowList.Count == 0)
          {
              FillPool();
          }
          var outShadow = ShadowList.Dequeue();//从队列中获得一个预制体
          outShadow.SetActive(true);
          return outShadow;
    }
}

