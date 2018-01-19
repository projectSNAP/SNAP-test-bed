using UnityEngine;

public class PlayerController : MonoBehaviour
{
		private Rigidbody rbody;

		void Start()
		{
			rbody = GetComponent<Rigidbody>();
		}

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);

				rbody.AddForce(x, 0f, z);
    }
}
