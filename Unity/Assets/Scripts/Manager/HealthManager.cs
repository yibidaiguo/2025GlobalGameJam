using System.Collections.Generic;
using JKFrame;
using UnityEngine;
//管理所有的受伤行为
public class HealthManager : SingletonMono<HealthManager>
{
    int healthMax;//生命值上限
    int health;//生命值
    public int damage = 1;//伤害
    private List<GameObject> harmfulThings = new ();
    

    public void harmfulThingsAdd(GameObject obj)
    {
        harmfulThings.Add(obj);
    }


    public void HealthCaculate()
    {
        //计算伤害
        foreach (GameObject obj in harmfulThings)
        {
            if (obj != null)
            {
                health -= damage;
                //Todo 掉血动画
            }
        }
        //判断是否死亡
        if (health <= 0)
        {
            //Todo 死亡动画
            //Todo 死亡逻辑
        }
        //清空列表
        harmfulThings.Clear();
    }

}

