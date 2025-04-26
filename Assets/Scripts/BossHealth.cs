using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bossHealth = 20;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            print("BossLoaded");
            LoadBoss();
        }

        if(bossHealth <= 0)
        {
            animator.SetTrigger("die");
            this.GetComponentInChildren<CapsuleCollider>().enabled = false;
            this.GetComponent<Rigidbody>().freezeRotation = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            this.GetComponent<BossFight>().enabled = false;
            this.GetComponent<BossScript>().enabled = false;
            Destroy(this.gameObject, 5.5f);
        }
    }

    public void TakeDamageFromBoss(int damage)
    {
        bossHealth -= damage;
    }

    public void LoadBoss()
    {
        PlayerDataToSave data = SaveSystem.Load();
        bossHealth = data.bossHealth;

        var bossPosition = new Vector3(data.bossPos[0],data.bossPos[1],data.bossPos[2]);
        this.GetComponent<Transform>().position = bossPosition;
    }
}
