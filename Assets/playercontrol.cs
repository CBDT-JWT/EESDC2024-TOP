using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;
using static UnityEditor.PlayerSettings;

public class control : MonoBehaviour
{
    private bool isclick = false;
    Vector2 mousepos;
    Vector2 distance;
    Vector2 playerpos;
    Vector2 initialpos;
    public GameObject goal;
    Rigidbody2D rb;

    public float maxdis=1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialpos = rb.position; 
    }
    private void OnMouseDown()
    {
        distance = new Vector2(transform.position.x, transform.position.y) - mousepos;
        isclick = true;
     


    }
    private void OnMouseUp()
    {
        
        isclick = false;
       

    }
    // Update is called once per frame
    private void draw()
    {
        Vector2 orient = (mousepos - playerpos);
        List<Vector2> pointList = new List<Vector2>();
        pointList.Add(transform.position);
        for(int i = 1; i < 10; i++)
        {
            float time =0.1f * i ;
            Vector2 point = new Vector2(pointList.First().x + orient.x * time, pointList.First().y + orient.y * time);
            Ray2D ray2D = new Ray2D(pointList.Last(),point-pointList.Last());
            RaycastHit2D hit = Physics2D.Raycast(ray2D.origin, ray2D.direction, Vector2.Distance(pointList.Last(),point));
            pointList.Add(point);
        }
        foreach (Vector2 point in pointList)
        {
            Debug.DrawLine(new Vector2(point.x, point.y), new Vector2(point.x + 0.1f, point.y + 0.1f), Color.red, Mathf.Infinity);
        }


    }
  
    void Update()
    {
        mousepos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!isclick)
        {
            playerpos = new Vector2(transform.position.x, transform.position.y);
        }
        if (isclick)
        {
            Vector2 pos = (mousepos - playerpos).normalized * maxdis;
            transform.position=mousepos+distance;
            if(Vector2.Distance(transform.position, playerpos) > maxdis)
            {
                
                transform.position = pos + playerpos;
                
            }
            draw();
            rb.velocity = -(mousepos - playerpos) * 5;
            
        }
        if(rb.velocity.x < 0.3 && rb.velocity.x > -0.3)
        {
            rb.velocity= new Vector2(0,rb.velocity.y);
        }
        if (rb.velocity.y < 0.3 && rb.velocity.y > -0.3)
        {
            rb.velocity = new Vector2( rb.velocity.x,0);
        }

        if (goal.active)
        {
            transform.position = initialpos;
            rb.velocity = new Vector2(0, 0);

        }
    }
}
