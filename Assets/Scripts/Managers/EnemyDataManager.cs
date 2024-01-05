using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class EnemyDataManager : MonoBehaviour
{
    public string initJson;
    public List<EnemyData> enemyDatas = new List<EnemyData>();
 

    private void Start()
    {
        InitializeData();
    }


    void InitializeData()
    {
        JsonData data;
        data = JsonMapper.ToObject(initJson);

        for(int i = 0; i < data.Count; i ++)
        {
            EnemyData enemy = new EnemyData();
            enemy.weaponName = data[i]["enemy_name"].ToString();
            enemy.id = data[i]["enemy_id"].ToString();
            enemy.health = int.Parse( data[i]["enemy_hp"].ToString());
            enemy.speed =  float.Parse(data[i]["enemy_speed"].ToString());
            enemy.damage = float.Parse(data[i]["enemy_damage"].ToString());
            enemyDatas.Add(enemy);
        }
      
    }

}


[System.Serializable]
public class EnemyData
{
    public string weaponName, id;
    public int health;
    public float damage, speed;
}
