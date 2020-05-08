using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManagerScript : MonoBehaviour
{
    //Know what objects are clickable
    public LayerMask clickableLayer;

    //Swap Cursors per object
    public Texture2D pointer; //Normal Pointer
    public Texture2D target; //Cursor for clickable objects like the world
    public Texture2D doorway; //Cursor for doorways
    public Texture2D combat; //Cursor combat actions

    public EventVector3 OnClickEnvironment;

    private bool isMouseHeld = false;

    private RaycastHit hit;
	
	// Update is called once per frame
	void Update ()
    {
        

        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            bool item = false;

            if(hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }

            else if(hit.collider.gameObject.tag == "Item")
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else if(hit.collider.gameObject.tag == "Enemy")
            {
                Cursor.SetCursor(combat, new Vector2(16, 16), CursorMode.Auto);
            }
            else if(hit.collider.gameObject.tag == "Pointer")
            {
                Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }
//ashfjadkl
            if(Input.GetMouseButtonDown(1) || isMouseHeld)
            {
                isMouseHeld = true;
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;

                    OnClickEnvironment.Invoke(doorway.position);
                    Debug.Log("DOOR");
                }

                else if(item)
                {
                    Transform itemPos = hit.collider.gameObject.transform;

                    OnClickEnvironment.Invoke(itemPos.position);
                    Debug.Log("ITEM");
                }

                else
                {
                    OnClickEnvironment.Invoke(hit.point);
                }
            }
            if(Input.GetMouseButtonUp(1))
            {
                isMouseHeld = false;
            }
            if((Input.GetMouseButtonDown(0)) && hit.collider.gameObject.tag =="Enemy" )
            {
                // TODO: change cursor color
                // ALTERNATE: hit.collider.gameObject.GetComponent<NPCController> ().agentSpeed = 0;

            }
            //UnityEngine.AI.NavMeshAgent
        }

        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
	}
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }
