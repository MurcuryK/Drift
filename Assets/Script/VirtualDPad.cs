using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualDPad : MonoBehaviour
{

    public Text directionText;

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if(theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;

                if (x == 0)
                {
                    direction = "Tapped";
                }

                else if (x > 0)
                {
                    direction = "Right";
                }

                else if (x < 0)
                {
                    direction = "Left";
                }

            }
        }

        directionText.text = direction;


    }
}
