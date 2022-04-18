using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float Health { get; set; }
    public float Damage { get; set; }
    public float AttackSpeed { get; set; } //Time between two shots
    public float Ammo { get; set; } //Number of bullets stored totally before needing to reload
    public float Bullets { get; set; } //Number of bullets shot at one click
    public float ReloadSpeed { get; set; } //Get to full ammo
    public float NumberOfJumps { get; set; }
    public float MovementSpeed { get; set; }    

    void Start()
    {
        Health = 100;
        Damage = 25;
        AttackSpeed = 0.25f;
        Ammo = 9;
        Bullets = 3;
        ReloadSpeed = 0.75f;
        NumberOfJumps = 1;
        MovementSpeed = 250;
    }
    public void Upgrade(string stat, float modifier)
    {
        switch (stat)
        {
            case "Health":
                Health += modifier;
                break;
            case "Damage":
                Damage += modifier;
                break;
            case "AttackSpeed":
                AttackSpeed -= modifier;
                break;
            case "Ammo":
                Ammo += modifier;
                break;
            case "Bullets":
                Bullets += modifier;
                break;
            case "ReloadSpeed":
                ReloadSpeed -= modifier;
                break;
            case "NumberOfJumps":
                NumberOfJumps += modifier;
                break;
        }
    }
}
