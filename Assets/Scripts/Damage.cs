using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damage<T>
{
    void TakeDamage(T amount);
}
