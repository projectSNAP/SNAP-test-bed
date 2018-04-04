using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices; //allows us to access our SharedMemTestLib.dll

/* If you want to try to pass an actual 2d float array to the SharedMemTestLib.dll, here is a thread on it:
 * 	https://stackoverflow.com/questions/18018509/passing-2d-array-from-c-sharp-to-c?rq=1
 * Otherwise, to use the dll Read/Write to shared memory, then you have to manually put in each element
 * of your 2d array into the functions.
 */

public class SharedMemory : MonoBehaviour {
	[DllImport("SharedMemoryDLL.dll")]
	static extern int WriteArrayToSharedMemory(float f1, float f2, float f3, float f4);
	//[f1, f2]
	//[f3, f4]

	[DllImport("SharedMemoryDLL.dll")]
	static extern void ReadArrayFromSharedMemory(ref float nF1, ref float nF2, ref float nF3, ref float nF4);
	//[nF1, nF2]
	//[nF3, nF4]

	void Start(){
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
		float[,] fArray = new float[2, 2]{ { 1.1f, 2.2f }, { 3.3f, 4.4f } };
		int err = WriteArrayToSharedMemory (fArray[0,0], fArray[0,1], fArray[1,0], fArray[1,1]);

		if (err != 0)
			Debug.Log ("Write to shared memory failed!");


		//float[,] fResult = new float[2, 2];
		//ReadArrayFromSharedMemory (ref fResult[0,0], ref fResult[0,1], ref fResult[1,0], ref fResult[1,1]);
		//Debug.Log ("fResult: " + fResult[0,0] + ", " + fResult[0,1] + ", " + fResult[1,0] + ", " + fResult[1,1]);
	}

}
