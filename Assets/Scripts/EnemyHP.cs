using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int bulletDamage;
    public int selfDamage;
    public int expValue;

    public EXPManager expManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetShot()
    {
        currentHP -= selfDamage;
        if(currentHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        expManager.ReceiveEXP(expValue);
        Destroy(gameObject);
    }
}
