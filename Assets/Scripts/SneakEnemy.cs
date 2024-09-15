using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SneakEnemy : Enemy
{

    public override void Hit(int damage)
    {
        base.Hit(damage);

        transform.position = new Vector3(-transform.position.x, transform.position.y, -transform.position.z);
    }
}
