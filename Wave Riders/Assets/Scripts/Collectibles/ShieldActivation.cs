using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivation : MonoBehaviour
{
    private float ShieldDuration = 5f;

    private void OnEnable()
    {
        InputManager.OnShieldInput += ActivateShield;
    }

    private void OnDisable()
    {
        InputManager.OnShieldInput -= ActivateShield;
    }


    public void ActivateShield()
    {
        if(HUD.powerupNum > 0 && this.GetComponent<PlayerController>().powerActive == false)
        {
            this.GetComponent<PlayerController>().powerActive = true;
            HUD.powerupNum--;

            StartCoroutine(ShieldTimer(this.GetComponent<PlayerController>()));
        }
    }

    private IEnumerator ShieldTimer(PlayerController playerController)
    {
        Debug.Log("Shield Activated");
        yield return new WaitForSeconds(ShieldDuration);
        playerController.powerActive = false;
        Debug.Log("Shield Deactivated");
    }
}
