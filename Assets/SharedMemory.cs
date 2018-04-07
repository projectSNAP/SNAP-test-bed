using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //allows us to use IntPtr type
using System.Runtime.InteropServices; //allows us to access our SharedMemTestLib.dll
using System.IO;

public class SharedMemory : MonoBehaviour {
	[DllImport("SharedMemoryDLL.dll")]
	static extern int WriteArrayToSharedMemory(IntPtr intArray, int size);

	[DllImport("SharedMemoryDLL.dll")]
	static extern IntPtr ReadArrayFromSharedMemory(ref int size);

	Texture2D tex;
	Texture2DArray texArr;
	public Camera cam;

	void Start(){
		cam.depthTextureMode = DepthTextureMode.Depth;
		tex = new Texture2D(cam.pixelWidth, cam.pixelHeight, TextureFormat.RGBA32, false); //takes a screen shot from the cameras perspective
		byte[] bytes = tex.GetRawTextureData ();
		int[] intArr = ConvertToIntArray (bytes);
		Debug.Log ("intArr: " + intArr[0] + ", " + intArr[1] + ", " + intArr[2] + ", " + intArr[3]);


		//Initialize an IntPtr for our int array that we want to write to memory
		GCHandle handle = GCHandle.Alloc (intArr, GCHandleType.Pinned);
		IntPtr ipArr = handle.AddrOfPinnedObject();


		//Copy our int array to our IntPtr that we initialized
		Marshal.Copy (intArr, 0, ipArr, intArr.Length); 	//(int[] source, int startIndex, IntPtr dest, int length)
		Debug.Log("intArr len: " + intArr.Length);


		//Write the IntPtr array to memory
		int err = WriteArrayToSharedMemory (ipArr, intArr.Length);

		if (err != 0)
			Debug.Log ("Write to shared memory failed!");
		else
			Debug.Log ("Write SUCCESS!");
		

		//Read the array from memory and store it in an IntPtr
		int npArrSize = 0;
		IntPtr npArr = ReadArrayFromSharedMemory (ref npArrSize);
		if (npArr == null)
			Debug.Log ("Read from shared memory failed!");
		else
			Debug.Log ("Read SUCCESS!");


		//Copy elements that the IntPtr points to over to a new int array
		int[] nArr = new int[npArrSize];
		Marshal.Copy (npArr, nArr, 0, npArrSize);

		Debug.Log ("nArr: " + nArr[0] + ", " + nArr[1] + ", " + nArr[2] + ", " + nArr[3]);

	}

	int[] ConvertToIntArray(byte[] bytes){
		int[] intArr = new int[bytes.Length];
		for (int i = 0; i < bytes.Length; i++) {
			intArr [i] = bytes [i];
		}
		return intArr;
	}

}
