using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] BoxCollider _itemCollider;
    private IHealth entityHealth;
    [SerializeField] int _dmgValue = 1;
    [SerializeField] float _cdDuration = 0.5f;
    private bool _onCoolDown = false;

    private void OnTriggerStay(Collider other)
    {
        if (_itemCollider != null && !_onCoolDown && (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Damageable")))
        {
            entityHealth = other.GetComponent<IHealth>();
            entityHealth.TakeDamage(_dmgValue);
            StartCoroutine(dmgCooldown());
        }
    }
        
    IEnumerator dmgCooldown()
    {
        _onCoolDown = true;
        yield return new WaitForSeconds(_cdDuration);
        _onCoolDown = false;
    }
}
