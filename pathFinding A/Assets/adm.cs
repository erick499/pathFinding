using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class adm : MonoBehaviour {

	public GameObject bloco;
    public propriedadesBlocos inicial;
	public propriedadesBlocos final;
    public static int count = 0;
    public int columns = 10;
    public int rows = 10;
	// Use this for initialization
	void Start () {

		for (int i = 0; i < columns; i++) {
			for(int j = 0; j < rows; j++){

				bloco.GetComponent<propriedadesBlocos>().i = i;
				bloco.GetComponent<propriedadesBlocos>().j = j;
				Instantiate(bloco,new Vector3(0.15f * i, 0.15f* j, 0f), bloco.transform.rotation);

			}
		}

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("s"))
       {

            pathFinding(inicial);

       }

	}

    void pathFinding(propriedadesBlocos blocoCopia)
    {

        List<propriedadesBlocos> blocoList = new List<propriedadesBlocos>();

        if (blocoCopia.name != final.name && blocoCopia.name != null)
        {
            propriedadesBlocos temp;
            blocoList.Add(blocoCopia);
            int minVal = 100000;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        temp = Find(blocoCopia, i, j);

                        if (!temp.selected)
                        {
                            if (i == 0 || j == 0)
                            {
                                if (TotalValue(temp, final, 10) <= minVal)
                                {
                                    if (TotalValue(temp, final, 10) < minVal)
                                    {
                                        blocoList.Clear();
                                        minVal = TotalValue(temp, final, 10);
                                    }

                                    blocoList.Add(temp);
                                }
                            }
                            else if (TotalValue(temp, final, 14) <= minVal)
                            {
                                if (TotalValue(temp, final, 14) < minVal)
                                {
                                    blocoList.Clear();
                                    minVal = TotalValue(temp, final, 14);
                                }

                                blocoList.Add(temp);
                            }

                        }
                    }
                }
            }

        }
    }

    public void ReturnPathFinding(propriedadesBlocos actual)
    {
        if (actual.name != inicial.name)
        {
            int MV = 100000;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        if (Find(actual, i, j).selected)
                        {
                            if (i == 0 || j == 0)
                            {
                                if (TotalValue(Find(actual, i, j), inicial, 10) < MV)
                                    MV = TotalValue(Find(actual, i, j), inicial, 10);
                            }
                            else
                            {
                                if (TotalValue(Find(actual, i, j), inicial, 14) < MV)
                                    MV = TotalValue(Find(actual, i, j), inicial, 14);
                            }
                        }
                    }
                }
            }

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        if (!Find(actual, i, j).type.Equals("inicial"))
                        {
                            if (Find(actual, i, j).selected)
                            {
                                if (i == 0 || j == 0)
                                {
                                    if (TotalValue(Find(actual, i, j), inicial, 10) == MV)
                                    {
                                        Find(actual, i, j).verified = true;
                                        Find(actual, i, j).selected = false;
                                        ReturnPathFinding(Find(actual, i, j));
                                    }
                                }
                                else
                                {
                                    if (TotalValue(Find(actual, i, j), inicial, 14) == MV)
                                    {
                                        Find(actual, i, j).verified = true;
                                        Find(actual, i, j).selected = false;
                                        ReturnPathFinding(Find(actual, i, j));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public int TotalValue(propriedadesBlocos Ot, propriedadesBlocos Tdest, int V)
    {
        if (Ot.type == "wall"|| Ot == null)
        {
            return 50000;
       }

        return (V + 10 * (Mathf.Abs(Tdest.i - Ot.i) + Mathf.Abs(Tdest.j - Ot.j)));
    }

    public propriedadesBlocos Find(propriedadesBlocos blococopia, int i, int j)
    {
        if (blococopia.i + i < 0 || blococopia.j + j < 0)
            return null;
        else
            return GameObject.Find((blococopia.i + i).ToString() + (blococopia.j + j).ToString()).GetComponent<propriedadesBlocos>();
    }


}
