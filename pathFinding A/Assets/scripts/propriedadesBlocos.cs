using UnityEngine;
using System.Collections;

public class propriedadesBlocos : MonoBehaviour {

    public string type = "floor";

	public bool verified, selected = false;

	public int i,j;

	void Start(){

		this.gameObject.name = i+""+j;
      

	}

    void Update()
    {
        if (selected) GetComponent<SpriteRenderer>().color = Color.yellow;
        if (verified) GetComponent<SpriteRenderer>().color = Color.green;
    }


    void OnMouseDown(){

        if (adm.count == 0)
        {

            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(0f, 1f, 1f, 1f);
            type = "inicial";
            FindObjectOfType<adm>().inicial = this.GetComponent<propriedadesBlocos>();

            adm.count++;

        }
        else if (adm.count == 1)
        {

            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(1f, 0f, 0f, 1f);
            type = "final";
            FindObjectOfType<adm>().final = this.GetComponent<propriedadesBlocos>();
            

            adm.count++;

        }

        else if (adm.count == 2)
        {

            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(0f, 0f, 0f, 1f);

            type = "wall";

        }

    }

}
