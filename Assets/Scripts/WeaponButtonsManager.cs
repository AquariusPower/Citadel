﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponButtonsManager : MonoBehaviour {
	[SerializeField] public GameObject[] wepButtons;
	[SerializeField] private GameObject[] wepCountsText;

	void Update() {
		if (WeaponInventory.WepInventoryInstance == null) {
			Const.sprint("ERROR->WeaponButtonsManager: WeaponInventory instance failed to initialize!",transform.parent.gameObject);
			return;
		}
		for (int i=0; i<7; i++) {
			if (WeaponInventory.WepInventoryInstance.weaponInventoryIndices[i] > 0) {
				wepButtons[i].SetActive(true);
                wepButtons[i].GetComponent<WeaponButton>().useableItemIndex = WeaponInventory.WepInventoryInstance.weaponInventoryIndices[i];
                wepCountsText[i].SetActive(true);
			} else {
				wepButtons[i].SetActive(false);
                wepButtons[i].GetComponent<WeaponButton>().useableItemIndex = -1;
                wepCountsText[i].SetActive(false);
			}
		}

		if (GetInput.a.WeaponCycUp ()) {
			int i = WeaponCurrent.WepInstance.weaponCurrent;
			i++;

			int numberOfWeapons = 0;
			for (int j=0;j<7;j++) {
				if (WeaponInventory.WepInventoryInstance.weaponInventoryIndices [j] != -1)
					numberOfWeapons++;
			}

			if (numberOfWeapons == 0) return;

			if (i == numberOfWeapons)	i = 0;

			// Check that the index we are going to is different than what we are on
			if (i != WeaponCurrent.WepInstance.weaponCurrent) {
				//WeaponCurrent.WepInstance.weaponCurrent = i;
				wepButtons [i].GetComponent<WeaponButton> ().WeaponInvClick ();
			}
		}

		if (GetInput.a.WeaponCycDown ()) {
			int i = WeaponCurrent.WepInstance.weaponCurrent;
			i--;

			int numberOfWeapons = 0;
			for (int j=0;j<7;j++) {
				if (WeaponInventory.WepInventoryInstance.weaponInventoryIndices [j] != -1)
					numberOfWeapons++;
			}

			if (numberOfWeapons == 0) return;

			if (i < 0)	i = (numberOfWeapons - 1);

			// Check that the index we are going to is different than what we are on
			if (i != WeaponCurrent.WepInstance.weaponCurrent) {
				//WeaponCurrent.WepInstance.weaponCurrent = i;
				wepButtons [i].GetComponent<WeaponButton> ().WeaponInvClick ();
			}
		}
	}
}
