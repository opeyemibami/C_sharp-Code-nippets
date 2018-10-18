using System;
using System.Collections;


namespace FloydShortestDistanceProgram_OR
{
    class FloydAlgorithm
    {
        

        public static int Initializer { get; set; }
        private SortedList CollectedData;
        private SortedList SMatrix;
        private static int NumOfNodes;
        private float IFN;
        private int[,] Keys = new int[NumOfNodes, NumOfNodes];
        public FloydAlgorithm(SortedList ImportedData,SortedList _SMatrix, int _NumOfNodes, float _IFN, int[,] _Keys)
        {
            CollectedData = ImportedData;
            SMatrix = _SMatrix;
            NumOfNodes = _NumOfNodes;
            IFN = _IFN;
            Keys = _Keys;
        }
        

        //visualization of collected Dataset for virfication purposes
        int spacing = 0;
        public void DisplayData()
        {
            Console.WriteLine("Do:");
            foreach (DictionaryEntry DE in CollectedData)
            {
                //int key = (int)DE.Key;
                float FValue = (float)DE.Value;
                //string SValue = DE.Value.ToString();
                if ((float)DE.Value >= IFN)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0,-8}", "\u221E");
                    Console.ForegroundColor = ConsoleColor.White;
                    spacing++;
                    if (spacing == NumOfNodes)
                    {
                        Console.WriteLine("\n");
                        spacing = 0;
                    }
                }
                else
                {
                    Console.Write("{0,-8}", FValue);
                    //Console.Write(FValue + "    ");
                    spacing++;
                    if (spacing == NumOfNodes)
                    {
                        Console.WriteLine("\n");
                        spacing = 0;
                    }
                }

            }
            Console.WriteLine("So:");
        }


        //display of S_Matrix
        public void DisplaySMatrix()
        {
            foreach (DictionaryEntry DE in SMatrix)
            {
                
                int Value = (int)DE.Value;
                Console.Write("{0,-8}", Value);
                //Console.Write(id + "  ");
                spacing++;
                if (spacing == NumOfNodes)
                {
                    Console.WriteLine("\n");
                    spacing = 0;
                }
            }
        }

        

        SortedList[] EachIterationResult = new SortedList[Initializer];

       

        public static int EachIterationfiller { get; set; }
        public static int Count { get; set; }
        public static int IterationNumber { get; set; }
        
        
        public static int i = 0, j = 0;
        float Pivotrow, PivotColumn;

        public void FloydsAlgorithmEngine()
        {
            //ArrayList convertedkeys = new ArrayList(NumOfNodes * NumOfNodes);
            //int row = 1, column = 1;
            //for (int i = 0; i < convertedkeys.Count; i++)
            //{
            //    convertedkeys[i] = Keys[row, column];
            //    column++;
            //    if (column == NumOfNodes+1 ) { column = 1;row++; }
            //}

            NextIteration:
            SortedList TempMemory = new SortedList();
         

            EachIterationResult[IterationNumber] = new SortedList();
            if (IterationNumber == 0) { EachIterationResult[IterationNumber] = (SortedList)CollectedData.Clone(); }
            else { EachIterationResult[IterationNumber] = (SortedList)EachIterationResult[IterationNumber - 1].Clone(); }
            foreach (DictionaryEntry DE in EachIterationResult[IterationNumber])
            {
                float Value = (float)DE.Value;
                Pivotrow = (float)EachIterationResult[IterationNumber].GetByIndex(i);
                PivotColumn = (float)EachIterationResult[IterationNumber].GetByIndex(j);
                if ((Pivotrow + PivotColumn) < Value )
                {
                    Value = (Pivotrow + PivotColumn);
                    TempMemory.Add(EachIterationfiller, Value);
                   
                }
                EachIterationfiller++;
                if (EachIterationfiller == ((NumOfNodes * NumOfNodes)))
                {
                    EachIterationfiller = 0;
                }
              
                j++; Count++;
                if (Count == NumOfNodes)
                {
                    Count = 0;
                    j = NumOfNodes * IterationNumber;
                    i = i + NumOfNodes;

                }
                
            }
            TempMemory.TrimToSize();
            foreach(DictionaryEntry de in TempMemory)
            {
                int keyz = (int)de.Key;
                float Nvalue = (float)de.Value;
                EachIterationResult[IterationNumber].SetByIndex(keyz, Nvalue);
                SMatrix.SetByIndex(keyz, IterationNumber + 1);
            }
            Console.WriteLine("D" + IterationNumber);
            foreach (DictionaryEntry DE in EachIterationResult[IterationNumber])
            {
                int key = (int)DE.Key;
                float FValue = (float)DE.Value;
                
                if ((float)DE.Value >= IFN)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0,-8}", "\u221E");
                    Console.ForegroundColor = ConsoleColor.White;
                    spacing++;
                    if (spacing == NumOfNodes)
                    {
                        Console.WriteLine("\n");
                        spacing = 0;
                    }
                }
                else if((float)DE.Value < IFN && TempMemory.ContainsKey(EachIterationResult[IterationNumber].IndexOfKey(key)))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0,-8}", FValue);
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write(FValue + "    ");
                    spacing++;
                    if (spacing == NumOfNodes)
                    {
                        Console.WriteLine("\n");
                        spacing = 0;
                    }
                }

                else
                { 
                    Console.Write("{0,-8}", FValue);
                    //Console.Write(FValue + "    ");
                    spacing++;
                    if (spacing == NumOfNodes)
                    {
                        Console.WriteLine("\n");
                        spacing = 0;
                    }
                }

            }
            Console.WriteLine("S"+IterationNumber);
            DisplaySMatrix();
            Console.WriteLine("End of Iteration: {0}\n",IterationNumber);

            IterationNumber++;
            if (IterationNumber < NumOfNodes)
            {
                j = NumOfNodes * IterationNumber;
                i = IterationNumber;
                goto NextIteration;
            }
        }


        //display of  result for a specified path
        public void DisplayResult(int _Source,int _destination,int CapacityRange)
        {    
            float CurrentCost = 0;
            int Source = _Source;
            int destination = _destination;
            int key;
            if (CapacityRange == destination)
            {
                 key = (Source * CapacityRange * 10) + destination;
            }
            else
            {
                key = (Source * 10) + destination;
            }
            
            ArrayList Path = new ArrayList();
            Path.Add(Source);
            if(key!= ((CapacityRange + 1) * destination))
            {
                //key = (Source * 10) + (int)SMatrix.GetByIndex((SMatrix.IndexOfKey(key)));
                while ((int)SMatrix.GetByIndex((SMatrix.IndexOfKey(key))) != destination)
                {
                    //Path.Add((int)SMatrix.GetByIndex((SMatrix.IndexOfKey(key))));
                    Path.Insert(1, (int)SMatrix.GetByIndex((SMatrix.IndexOfKey(key))));
                    key = (Source * CapacityRange) + (int)SMatrix.GetByIndex((SMatrix.IndexOfKey(key)));
                    if (key == (Source * CapacityRange) + (int)SMatrix.GetByIndex((SMatrix.IndexOfKey(key))))
                    {
                        key = (Source * CapacityRange) + (int)SMatrix.GetByIndex((SMatrix.IndexOfKey(key)));
                        goto EndloopByforce;
                    }
                }
                EndloopByforce:
                //Path.Insert(1,(int)SMatrix.GetByIndex((SMatrix.IndexOfKey(key))));
                Path.Add(destination);
                //Path.Sort();
                Path.TrimToSize();

                ArrayList CostKeys = new ArrayList(Path.Count - 1);
                for (int i = 0; i < (Path.Count - 1); i++)
                {
                    CostKeys.Add(((int)Path[i] * CapacityRange) + (int)Path[i + 1]);
                }

                for (int i = 0; i < CostKeys.Count; i++)
                {
                    CurrentCost = (float)EachIterationResult[IterationNumber - 1].GetByIndex(EachIterationResult[IterationNumber - 1].IndexOfKey(CostKeys[i])) + CurrentCost;
                }
                Console.Write("\tPath :");
                foreach (var element in Path)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(element);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("]");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("--->");
                    

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tTotal cost = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} units",CurrentCost);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("No feaible Route Between Node{0} to Node{0}",Source,destination);
            }
        }

    }
}
