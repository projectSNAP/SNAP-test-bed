/*	Video explaining how Shaders work:
 * 		https://www.youtube.com/watch?v=C0uJ4sZelio&t=1799s
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //allows us to use IntPtr type
using System.Runtime.InteropServices; //allows us to access our SharedMemTestLib.dll
using System.IO;
using System.Diagnostics; //allows us to use Process


public class SharedMemory : MonoBehaviour {
	[DllImport("bin\\SharedMemoryDLL.dll")]
	static extern IntPtr CreateImagePointerToSharedMemory (int x, int y);

	[DllImport("bin\\SharedMemoryDLL.dll")]
	static extern IntPtr CreateDimensionPointerToSharedMemory (int x, int y);

	[DllImport("bin\\SharedMemoryDLL.dll")]
	static extern void UnmapPointerToSharedMemory (IntPtr pSharedMem);



	public Material mat;
	int width, height;
	Texture2D tex;
	string pathToVAEExecutable;
	Process process;
	byte[] bytes;
	int[] dim;
	IntPtr ptrToSharedMemory, ptrToDim;
	const int RGBA_TYPE = 4;
	bool processRunning = false;
	Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();
		cam.depthTextureMode = DepthTextureMode.Depth;
		width = cam.pixelWidth;
		height = cam.pixelHeight;
		tex = new Texture2D(width, height, TextureFormat.RGBA32, false);


		pathToVAEExecutable =  Application.dataPath + "/bin/SNAP-visual-audio-engine.exe";

		if (processRunning) {
			process.Kill ();
		}

		process = System.Diagnostics.Process.Start (pathToVAEExecutable);
		processRunning = true;
	}

	void OnEnable()
	{
		cam = GetComponent<Camera> ();
		cam.depthTextureMode = DepthTextureMode.Depth;
		width = cam.pixelWidth;
		height = cam.pixelHeight;
		bytes = new byte[RGBA_TYPE * width * height];
		dim = new int[2]; //dimensions of image
		ptrToDim = CreateDimensionPointerToSharedMemory(2, 1);
		ptrToSharedMemory = CreateImagePointerToSharedMemory(width, height);
	}



	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		//src is the fully rendered scene that you would normally
		//send to the monitor. We are intercepting this so we can
		//modify it before passing it on.
		Graphics.Blit(source, destination, mat);
		RenderTexture.active = destination;

		//Reads pixels from the camera to our texture2D
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0, false);
		tex.Apply();
		bytes = tex.GetRawTextureData(); //bytes of image
		print("w: " + width);
		dim [0] = width;
		dim [1] = height;
		print ("dim w: " + dim[0] + " dim h: " + dim[1]);

		//Copy our dimensions of the image to shared memory space
		Marshal.Copy(dim, 0, ptrToDim, dim.Length);

		//Copy our byte array to our shared memory space
		Marshal.Copy (bytes, 0, ptrToSharedMemory, bytes.Length);
	}

	void OnDisable()
	{
		UnmapPointerToSharedMemory (ptrToSharedMemory);
		UnmapPointerToSharedMemory (ptrToDim);
		process.Kill();
	}

}
