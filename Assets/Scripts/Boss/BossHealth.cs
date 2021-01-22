using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public BossHealthBar healthBar;
    public static BossHealth instance;
    public Boss boss;
    public Animator anim;
    public GameObject ganaste;
    public int currentHealth;
    public int health;
    public int maxLevel;
    public bool Invincible;
    public bool win, loose;

    public void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        Invincible = true;
        currentHealth = 100;
        healthBar.SetMaxHealth(maxLevel);
        healthBar.setHealth(currentHealth);
    }
    void Update()
    {
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 40)
        {
            anim.SetBool("isEnraged", true);
            boss.enraged = true;
        }
        if (currentHealth <= 0)
        {
            EndingVideo.instance.playNow = true;
        }
    }
}
