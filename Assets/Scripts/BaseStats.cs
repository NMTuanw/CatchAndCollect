using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BaseStats", menuName = "BaseStats", order = 0)]
public class BaseStats : ScriptableObject {
    public float moveSpeed;
    public float jumpForce;

    public float dashSpeed;
}
