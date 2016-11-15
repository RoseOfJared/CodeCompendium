using UnityEngine;
using System.Collections;

public class ObjectPickupScript : MonoBehaviour {

    public GameObject PickupPoint;

    void OnTriggerEnter(Collider collide)
    {
        m_CanPickupObject = true;

    }

	void OnTriggerStay()
	{
		if (m_IsInObjRadius) {
			m_PickedUpObject = true;
		} 
		else {m_PickedUpObject = false;}
	}

    void OnTriggerExit(Collider collide)
    {
        m_CanPickupObject = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

		if(Input.GetKeyDown(KeyCode.E))
		{
			m_IsInObjRadius = !m_IsInObjRadius;
		}

        if (m_PickedUpObject == true)
        {
			this.transform.position = PickupPoint.transform.position;
        }
	}


    public bool m_CanPickupObject;
	public bool m_PickedUpObject;
	public bool m_IsInObjRadius;
	public int m_InputCounter = 1;
	int m_ResultantNum;
}
