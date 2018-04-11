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
	public Camera cam;
	bool capture;
	public Material mat;
	int width, height;

	void Start(){
		capture = false;
		cam.depthTextureMode = DepthTextureMode.Depth;
		width = cam.pixelWidth;
		height = cam.pixelHeight;
		tex = new Texture2D (width, height, TextureFormat.RGBA32, false);
	}

	void Update(){
		if (Input.GetKey (KeyCode.C)) {
			capture = true;
		}
	}

	void OnRenderImage(RenderTexture src, RenderTexture dest){
		//src is the fully rendered scene that you would normally
		//send to the monitor. We are intercepting this so we can
		//modify it before passing it on.
		Graphics.Blit (src, dest, mat);
		if (capture) {
			RenderTexture.active = dest;
			tex.ReadPixels (new Rect (0, 0, width, height), 0, 0);
			tex.Apply ();
			byte[] bytes = tex.GetRawTextureData ();

			Debug.Log ("bytes: " + bytes [0] + ", " + bytes [1] + ", " + bytes [2] + ", " + bytes [bytes.Length - 3] + ", " + bytes [bytes.Length - 2] + ", " + bytes [bytes.Length - 1]);
			Debug.Log ("bytes len: " + bytes.Length);

			int[] intArr = ConvertToIntArray (bytes);
			Debug.Log ("intArr: " + intArr [0] + ", " + intArr [1] + ", " + intArr [2] + ", " + intArr [3] + ", " + intArr [intArr.Length - 3] + ", " + intArr [intArr.Length - 2] + ", " + intArr [intArr.Length - 1]);
			Debug.Log ("intArr size: " + intArr.Length);


			//Initialize an IntPtr for our int array that we want to write to memory
			GCHandle handle = GCHandle.Alloc (intArr, GCHandleType.Pinned);
			IntPtr ipArr = handle.AddrOfPinnedObject ();


			//Copy our int array to our IntPtr that we initialized
			Marshal.Copy (intArr, 0, ipArr, intArr.Length); 	//(int[] source, int startIndex, IntPtr dest, int length)


			//Write the IntPtr array to memory
			int err = WriteArrayToSharedMemory (ipArr, intArr.Length);

			if (err != 0)
				Debug.Log ("Write to shared memory failed!");
			else
				Debug.Log ("Write SUCCESS!");


			/*
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

			Debug.Log ("nArr: " + nArr[0] + ", " + nArr[1] + ", " + nArr[2] + ", " + nArr[3] + ", " + nArr[nArr.Length - 3] + ", " + nArr[nArr.Length - 2] + ", " + nArr[nArr.Length - 1]);
			Debug.Log ("nArr size: " + nArr.Length);
			*/
			capture = false;
		}

	}

	void OnPostRender(){
		
	}


	int[] ConvertToIntArray(byte[] bytes){
		int[] intArr = new int[bytes.Length];
		for (int i = 0; i < bytes.Length; i++) {
			intArr [i] = bytes [i];
		}
		return intArr;
	}

}
