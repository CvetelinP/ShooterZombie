using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    AmmoSlot[] ammoSlots;

    [System.Serializable]
    public class AmmoSlot
    {
        public AmmoType ammoType;
        public int amount;
    }


    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).amount;
    }

    public int ReduceAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).amount--;
    }
    public int IncreaseAmmo(AmmoType ammoType,int ammoAmount)
    {
        return GetAmmoSlot(ammoType).amount+=ammoAmount;
    }


    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }

        }
        return null;
    }
}
