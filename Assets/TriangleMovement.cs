using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    private Vector3 move;

   /* public float forwardforce = 40f;
    public float sidewayforce = 40f;
    public Rigidbody2D rb;                        Connected to the rigidbody movement 
    */
    void Start()
    {
     /*   if(rb == null) 
        {
            rb = this.GetComponent<Rigidbody2d>
        }
    */  
    }

 
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))

       // MovePlayer();   //Rigidbody movement     
    }
    // has been added if wanted to use rigidbody instead
/*    void MovePlayer()
    {
        if(Input.KeyCode.W)
        {
            rb.AddForce(0,0,forwardforce * Time.deltatime , ForceMode.VelocityChange)
        }

        if(Input.KeyCode.S)
        {
            rb.AddForce(0,0,-forwardforce * Time.deltatime , ForceMode.VelocityChange)    // for rigidbody movement
        }

        if(Input.KeyCode.A)
        {
            rb.AddForce(-sidewayforce * Time.deltatime,0,0 , ForceMode.VelocityChange)
        }

        if(Input.KeyCode.D)
        {
            rb.AddForce(sidewayforce * Time.deltatime ,0,0 , ForceMode.VelocityChange)
        }
    }
*/
}
