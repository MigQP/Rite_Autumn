using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour
{
	/*RAYCAST-BASED SYSTEM FOR GRABBING*/


	public bool grabbed;
	RaycastHit2D hit;
	public float distance = 2f;
	public Transform holdpoint;
	public float throwforce;
	public LayerMask notgrabbed;


	private SpiderBrain playerMov;

	// Use this for initialization
	void Start()
	{
		playerMov = FindObjectOfType<SpiderBrain>();
	}

	// Update is called once per frame
	void Update()
	{

		Vector3 charecterScale = transform.localScale;

		// Sprite Flipping
		if (Input.GetAxis("Horizontal") < 0)
		{
			charecterScale.x = -1;
		}
		if (Input.GetAxis("Horizontal") > 0)
		{
			charecterScale.x = 1;
		}

		transform.localScale = charecterScale;


		// Grab and Release OnKey
		if (Input.GetKeyDown(KeyCode.Space))
		{

			if (!grabbed)
			{
				Physics2D.queriesStartInColliders = false;

				hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

				if (hit.collider != null && hit.collider.tag == "grabbable")
				{
					if (hit.collider.gameObject.GetComponent<LeafSplit>().isGrabbable == false)
						return;
					//slowing ant once object is grabbed
					playerMov.speed = 2;
					grabbed = true;

				}


				//Grab
			}
			else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
			{
				hit.collider.gameObject.GetComponent<LeafSplit>().isGrabbable = false;
				grabbed = false;

				if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
				{	//ant normal speed
					playerMov.speed = 5;
					float th = throwforce + playerMov.speed;
					hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * th /2;
					hit.collider.gameObject.GetComponent<LeafSplit>().canSplit = true;
				}


				//Release
			}


		}



		if (grabbed)
			hit.collider.gameObject.transform.position = holdpoint.position;


	}


	// GrabGizmo
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
	}
}