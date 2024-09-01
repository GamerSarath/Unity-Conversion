using UnityEngine;

namespace Array2DEditor
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager instance;
        
        public  Array2DBool doubecellOccupied = null;

        public Array2DBool tripplecellOccupied = null;

        public Array2DBool tripplecellOccupied1 = null;
        public Array2DBool tripplecellOccupied2 = null;
        public Array2DBool tripplecellOccupied3 = null;
        public Array2DBool tripplecellOccupied4 = null;
        public Array2DBool tripplecellOccupied5 = null;
        public Array2DBool tripplecellOccupied6 = null; 
        public Array2DBool tripplecellOccupied7 = null;
        public Array2DBool tripplecellOccupied8 = null;
        public Array2DBool tripplecellOccupied9 = null;

        public int selectedCellsCount;

        public bool[] coloumnFinished = new bool[10];

        public bool[] rowFinished = new bool[10];

        public bool[] tripplecoloumnFinished = new bool[100];
  

        public bool[] tripplerowFinished = new bool[100];

        /*[SerializeField]
        private GameObject prefabToInstantiate = null;
*/
        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            
    /*
            var cells = cellOccupied.GetCells();

            Debug.Log("Occupied size is " + cellOccupied.GridSize.y);
            for (var y = 0; y < cellOccupied.GridSize.y; y++)
            {
                for (var x = 0; x < cellOccupied.GridSize.x; x++)
                {
                    if (!cells[y, x])
                    {
                        Debug.Log("print " + x + y);
                    }
                }
            }*/
    	}

        public bool[,] GetBools()
        {
            return doubecellOccupied.GetCells();
        }


        public bool[,] GetTrippleBools(int tabnumber)
        {
            bool[,] result = null;
            switch (tabnumber)
            {
                case 0:
                    result = tripplecellOccupied.GetCells();
                    break;

                case 1:
                    result = tripplecellOccupied1.GetCells();
                    break;

                case 2:
                    result = tripplecellOccupied2.GetCells();
                    break;

                case 3:
                    result = tripplecellOccupied3.GetCells();
                    break;

                case 4:
                    result = tripplecellOccupied4.GetCells();
                    break;

                case 5:
                    result = tripplecellOccupied5.GetCells();
                    break;

                case 6:
                    result = tripplecellOccupied6.GetCells();
                    break;

                case 7:
                    result = tripplecellOccupied7.GetCells();
                    break;

                case 8:
                    result = tripplecellOccupied8.GetCells();
                    break;

                case 9:
                    result = tripplecellOccupied9.GetCells();
                    break;
            }

            return result;
        }

        public void UpdateGrid(bool[,] bools)
        {
            for (int i =0; i < 10; i++)
            {
               for(int j = 0; j < 10; j++)
                {
                    if (bools[i, j])
                    {
                     //   Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                        if (bools[0,j] && bools[1,j] && bools[2,j] && bools[3,j] && bools[4,j] && bools[5,j] && bools[6,j] && bools[7,j] && bools[8,j] && bools[9,j])
                        {
                            coloumnFinished[j] = true;
                        }
                        if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i,4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                        {
                            rowFinished[i] = true;
                        }

                    }
                    else if(!bools[i,j])
                    {

                        if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                        {
                           // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                            coloumnFinished[j] = false;
                        }
                        if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                        {
                          //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                            rowFinished[i] = false;
                        }
                    }
                }
            }
           
               
        }

        public void UpdateTrippleGrid(bool[,] bools)
        {
           switch(GameManager.Instance.currentTrippleMultiplyValue/100)
            {
                case 0:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                             //   Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                               //     Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j] = true;
                              //      PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                //    Debug.Log("row fiished");

                                    tripplerowFinished[i] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                           //          Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j] = false;
                              //      PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                               //       Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i] = false;
                                }
                            }
                        }
                    }
                    break;

                case 1:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j+ 10] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i + 10] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                     //Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j+10] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i+10] = false;
                                }
                            }
                        }
                    }
                    break;

                case 2:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j + 20] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i+20] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                    // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j + 20] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i+20] = false;
                                }
                            }
                        }
                    }
                    break;

                case 3:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j + 30] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i+30] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                    // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j + 30] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i] = false;
                                }
                            }
                        }
                    }
                    break;

                case 4:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j + 40] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i +40] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                    // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j + 40] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i + 40] = false;
                                }
                            }
                        }
                    }
                    break;

                case 5:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j + 50] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i + 50] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                    // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j + 50] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i+50] = false;
                                }
                            }
                        }
                    }
                    break;

                case 6:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j + 60] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i + 60] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                    // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j + 60] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i +60] = false;
                                }
                            }
                        }
                    }
                    break;

                case 7:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j + 70] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i + 70] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                    // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j + 70] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i + 70] = false;
                                }
                            }
                        }
                    }
                    break;

                case 8:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j + 80] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i + 80] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                    // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j + 80] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i + 80] = false;
                                }
                            }
                        }
                    }
                    break;

                case 9:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (bools[i, j])
                            {
                                Debug.Log("cell is" + i + " , " + j + bools[i, j]);
                                if (bools[0, j] && bools[1, j] && bools[2, j] && bools[3, j] && bools[4, j] && bools[5, j] && bools[6, j] && bools[7, j] && bools[8, j] && bools[9, j])
                                {
                                    Debug.Log("coloumn fiished");
                                    tripplecoloumnFinished[j + 90] = true;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (bools[i, 0] && bools[i, 1] && bools[i, 2] && bools[i, 3] && bools[i, 4] && bools[i, 5] && bools[i, 6] && bools[i, 7] && bools[i, 8] && bools[i, 9])
                                {
                                    tripplerowFinished[i + 90] = true;
                                }

                            }
                            else if (!bools[i, j])
                            {

                                if (!bools[0, j] || !bools[1, j] || !bools[2, j] || !bools[3, j] || !bools[4, j] || !bools[5, j] || !bools[6, j] || !bools[7, j] || !bools[8, j] || !bools[9, j])
                                {
                                    // Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplecoloumnFinished[j + 90] = false;
                                    PlayerPrefsExtension.SetBoolArray("TrippleColoumnFinished" + j, tripplecoloumnFinished);
                                }
                                if (!bools[i, 0] || !bools[i, 1] || !bools[i, 2] || !bools[i, 3] || !bools[i, 4] || !bools[i, 5] || !bools[i, 6] || !bools[i, 7] || !bools[i, 8] || !bools[i, 9])
                                {
                                    //  Debug.Log("cell is" + i + " , " + j + bools[i, j]);

                                    tripplerowFinished[i + 90] = false;
                                }
                            }
                        }
                    }
                    break;
            }


        }

        public void ClearTrippleColoumnFinishedArray()
        {
            for (int i = 0; i < 10; i++)
            {
               tripplecoloumnFinished[i] = false;
            }
           
        }
        public void UpdateRowButtons()
        {
            for (int i = 0;i < 10; i++)
            {
                if (rowFinished[i])
                {
                    UIManager.Instance.rowSelectButtons[i].SetActive(false);
                    UIManager.Instance.rowRemoveButtons[i].SetActive(true);

                }
                else if(!rowFinished[i])
                {
                    UIManager.Instance.rowSelectButtons[i].SetActive(true);
                    UIManager.Instance.rowRemoveButtons[i].SetActive(false);

                }
            }
        }

        public void UpdateTrippleRowButtons()
        {
           // Debug.Log("Update Row Buttons");
           switch(GameManager.Instance.currentTrippleMultiplyValue/100)
            {
                case 0:
                    for (int i = 0; i < 10; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);
                           // Debug.Log("row fiished");

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);
                         //   Debug.Log("row fiished");   

                        }
                    }   
                    break;

                case 1:
                    for (int i = 10; i < 20; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

                case 2:
                    for (int i = 20; i < 30; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

                case 3:
                    for (int i = 30; i < 40; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

                case 4:
                    for (int i = 40; i < 50; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

                case 5:
                    for (int i = 50; i < 60; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

                case 6:
                    for (int i = 60; i < 70; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

                case 7:
                    for (int i = 70; i < 80; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

                case 8:
                    for (int i = 80; i < 90; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

                case 9:
                    for (int i = 90; i < 100; i++)
                    {
                        if (tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplerowFinished[i])
                        {
                            UIManager.Instance.tripplerowSelectButtons[i].SetActive(true);
                            UIManager.Instance.tripplerowRemoveButtons[i].SetActive(false);

                        }
                    }
                    break;

            }
        }

        public void UpdateTrippleColoumnButtons()
        {
           // Debug.Log("Calling update coloumn method");
           // ClearTrippleColoumnFinishedArray();
           switch(GameManager.Instance.currentTrippleMultiplyValue/100)
            {
                case 0:
                    for (int i = 0; i < 10; i++)
                    {
                      //  Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                          //  Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                           // Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 1:
                    for (int i = 10; i < 20; i++)
                    {
                      //  Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                            //Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                        //    Debug.Log("Inside else if");    
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 2:
                    for (int i = 20; i < 30; i++)
                    {
                      //  Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                        //    Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                        //    Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 3:
                    for (int i = 30; i < 40; i++)
                    {
                      //  Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                            Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                        //    Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 4:
                    for (int i = 40; i < 50; i++)
                    {
                       // Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                         //   Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                         //   Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 5:
                    for (int i = 50; i < 60; i++)
                    {
                      //  Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                         //   Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                          //  Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 6:
                    for (int i = 60; i < 70; i++)
                    {
                       // Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                          //  Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                           // Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 7:
                    for (int i = 70; i < 80; i++)
                    {
                        //Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                          //  Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                         //   Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 8:
                    for (int i = 80; i < 90; i++)
                    {
                       // Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                       //     Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                           // Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;

                case 9:
                    for (int i = 90; i < 100; i++)
                    {
                       // Debug.Log("Inside for loop " + i);
                        if (tripplecoloumnFinished[i])
                        {
                           // Debug.Log("i is " + i + " bool is " + tripplecoloumnFinished[i]);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(true);

                        }
                        else if (!tripplecoloumnFinished[i])
                        {
                          //  Debug.Log("Inside else if");
                            UIManager.Instance.tripplecolRemoveButtons[i].SetActive(false);
                            UIManager.Instance.tripplecolSelectButtons[i].SetActive(true);

                        }
                    }
                    break;
            }
          
        }

        public void UpdateColoumnButtons()
        {
            //Debug.Log("Calling update coloumn method");
            for (int i = 0; i < 10; i++)
            {
                if (coloumnFinished[i])
                {
                    //Debug.Log("i is " + i + " bool is " + coloumnFinished[i]);
                    UIManager.Instance.colSelectButtons[i].SetActive(false);
                    UIManager.Instance.colRemoveButtons[i].SetActive(true);

                }
                else if (!coloumnFinished[i])
                {
                    UIManager.Instance.colSelectButtons[i].SetActive(true);
                    UIManager.Instance.colRemoveButtons[i].SetActive(false);

                }
            }
        }


    }
}
