using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// <c>Damage3D</c> is intended for use with 3D based projects. This component will deal damage to the <c>Health</c> component of another object while colliding. This can be damage dealt once
/// or damage dealt over time. Trigger and non-trigger conditions are taken into account.
/// </summary>
public class Damage3D : MonoBehaviour
{
    [Header("Damage Properties")]
    [SerializeField, Tooltip("Amount of damage to be dealt.")] int damage = 0;
    [SerializeField, Tooltip("Boolean to determine whether to deal damage once or over time. If damage is dealt overtime, the damage amount is dealt over the course of one second.")] bool isOneTime = true;
    [SerializeField, Tooltip("This list will contain tags that this damage dealing object should not affect.")] List<string> ignoreTags;

    [Header("Game Data")]
    [SerializeField, Tooltip("A GameData object that contains a key 'Damage'.")] GameData dataObjectWithDamage;
    [SerializeField, Tooltip("A boolean used to determine whether or not to take advantage of the GameData object 'dataObjectWithDamage'.")] bool useGameDataDamage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isOneTime) return;
        if (other.gameObject.TryGetComponent<Health>(out Health health) && !ignoreTags.Any(ignoreTag => other.CompareTag(ignoreTag)))
        {
            health.Damage((useGameDataDamage) ? dataObjectWithDamage.intData["Damage"] : damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isOneTime) return;
        if (other.gameObject.TryGetComponent<Health>(out Health health) && !ignoreTags.Any(ignoreTag => other.CompareTag(ignoreTag)))
        {
            health.Damage((int)(((useGameDataDamage) ? dataObjectWithDamage.intData["Damage"] : damage) * Time.deltaTime));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isOneTime) return;
        if (collision.gameObject.TryGetComponent<Health>(out Health health) && !ignoreTags.Any(ignoreTag => collision.gameObject.CompareTag(ignoreTag)))
        {
            health.Damage((useGameDataDamage) ? dataObjectWithDamage.intData["Damage"] : damage);
        }
    }
}
