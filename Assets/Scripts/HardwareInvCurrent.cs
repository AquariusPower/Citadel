using UnityEngine;
using System.Collections;

public class HardwareInvCurrent : MonoBehaviour {
	public int hardwareInvCurrent = new int();
	public int hardwareInvIndex = new int();
	public int[] hardwareInventoryIndices = new int[]{0,1,2,3,4,5,6,7,8,9,10,11,12,13};
	public static HardwareInvCurrent a;
	
	void Awake() {
		a = this;
        a.hardwareInvCurrent = 0; // Current slot in the general inventory (14 slots)
        a.hardwareInvIndex = 0; // Current index to the item look-up table
	}
}
