using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] BoxCollider _itemCollider;
    private IHealth playerHealth;
    [SerializeField] int _dmgValue = 1;
    [SerializeField] float _cdDuration = 0.5f;
    private bool _onCoolDown = false;

    private void OnTriggerStay(Collider other)
    {
        if (_itemCollider != null && other.gameObject.CompareTag("Player"))
        {
            if(!_onCoolDown)
            {
                playerHealth = other.GetComponent<IHealth>();
                playerHealth.TakeDamage(_dmgValue);
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
}
