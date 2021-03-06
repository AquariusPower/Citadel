using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class HardwareInvButton : MonoBehaviour {
    public int HardwareInvButtonIndex;
    public int useableItemIndex;
	public HardwareInventory hardwareInventory;
	public MFDManager mfdManager;

    void HardwareInvClick() {
		HardwareInvCurrent.a.hardwareInvCurrent = HardwareInvButtonIndex;  //Set current
		mfdManager.SendInfoToItemTab(useableItemIndex);
    }
		
    void Start() {
        GetComponent<Button>().onClick.AddListener(() => { HardwareInvClick(); });
    }

    void Update() {
		useableItemIndex = HardwareInventory.a.hardwareInventoryIndexRef[HardwareInvButtonIndex];
    }
}
