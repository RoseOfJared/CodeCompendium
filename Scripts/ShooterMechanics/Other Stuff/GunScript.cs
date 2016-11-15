using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {

    public Transform barrel;
    public float range = 0f;

	
	// Update is called once per frame
	void Update()
    {
	    if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("Fire");
        }
	}

    IEnumerator Fire()
    {
        RaycastHit hit;
        Ray ray = new Ray(barrel.position, transform.forward);

        if(Physics.Raycast(ray, out hit, range))
        {
            if(hit.collider.tag == "Enemy")
            {

            }
        }
        Debug.DrawRay(barrel.position, transform.forward * range, Color.green);
        yield return null;
    }


}
