using System;
using System.Collections;


namespace FloydShortestDistanceProgram_OR
{
    class Program 
    {
         
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\n\n\n\tGROUP 1 FLOYD'S ALGORITHM");
            Console.Title = "Floyd's algorithm by Group 1";
            MainMenu:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\tWelcome to DATALAB_FLOYD'S ALGORITHM(SHORTEST DISTANCE SOLVER)");
            Console.WriteLine("\tProgram Capacity = 1000 nodes");
            Console.WriteLine("\tUpgrade to  v4.5 for Higer capacity on Http://datalab.com/ng OR reach DATALAB HelpLine : 08166780424");
            Console.ForegroundColor = ConsoleColor.White;
            float IFN = 999999;
            ValidCapacity:
            Console.WriteLine("Please input the number of Nodes:");
            //ensuring  a valid number of nodes 
            int NumOfNodes = 0;
            while (!int.TryParse(Console.ReadLine(), out NumOfNodes))
            {
                Console.WriteLine("Please Input a valid number of nodes"); 
            }
            //int NumOfNodes = int.Parse(Console.ReadLine());
            
            int CapacityRange;
            if (NumOfNodes <= 1000)
            {
                //setting rangeCapacity to be used in code for proper algorithm;
                if (0 < NumOfNodes && NumOfNodes <= 10) { CapacityRange = 10; }
                else if (10 < NumOfNodes && NumOfNodes <= 100) { CapacityRange = 100; }
                else { CapacityRange = 1000; }
                //partially initializing floydsalgoritm parameters due to program flow;
                FloydAlgorithm.Initializer = NumOfNodes;
                FloydAlgorithm.Count = 0;
                FloydAlgorithm.Count = 0;
                FloydAlgorithm.IterationNumber = 0;
                FloydAlgorithm.i = 0;
                FloydAlgorithm.j = 0;
                //creating my sortedlist for my data and smatrix
                SortedList Dataset = new SortedList(NumOfNodes * NumOfNodes);
                SortedList SMatrix = new SortedList(NumOfNodes * NumOfNodes);
                int SMatrcixFiller = 1;
                //Generation of sortedList keys using 2D array;
                int[,] Index = new int[NumOfNodes, NumOfNodes];

                //movement is per row
                for (int RowIndex = 1; RowIndex <= NumOfNodes; RowIndex++)
                {
                    //movement is per column
                    for (int columnIndex = 1; columnIndex <= NumOfNodes; columnIndex++)
                    {
                        //generation of the values(keys) in the 2D Index[,] for the maximum nodes = 0 < NumOfNodes && NumOfNodes < 10
                        if (0 < NumOfNodes && NumOfNodes <= 10)
                        {
                            //making sure that the last key is 1010
                            if ((RowIndex == 10) && (columnIndex == 10))
                            {
                                Index[(RowIndex) - 1, (columnIndex) - 1] = (CapacityRange * RowIndex * 10) + columnIndex;
                                SMatrix.Add(Index[(RowIndex - 1), (columnIndex - 1)], 0);
                            }

                            else
                            {

                                Index[(RowIndex - 1), (columnIndex - 1)] = (CapacityRange * RowIndex) + columnIndex;
                                //making sure Smatrix diagonal is always 0
                                if (Index[(RowIndex - 1), (columnIndex - 1)] == ((CapacityRange + 1) * columnIndex))
                                {
                                    SMatrix.Add(Index[(RowIndex - 1), (columnIndex - 1)], 0);
                                    SMatrcixFiller++;
                                }
                                else
                                {
                                    SMatrix.Add(Index[(RowIndex - 1), (columnIndex - 1)], SMatrcixFiller);
                                    SMatrcixFiller++;
                                }
                                //resetting SMatrcixFiller
                                if (SMatrcixFiller == NumOfNodes + 1)
                                {
                                    SMatrcixFiller = 1;
                                }
                            }

                        }
                        //generation of the values(keys) in the 2D Index[,] for the maximum nodes = 9 < NumOfNodes && NumOfNodes < 100
                        else if (10 < NumOfNodes && NumOfNodes < 100)
                        {
                            Index[(RowIndex - 1), (columnIndex - 1)] = (CapacityRange * RowIndex) + columnIndex;
                            //making sure Smatrix diagonal is always 0
                            if (Index[(RowIndex - 1), (columnIndex - 1)] == ((CapacityRange + 1) * columnIndex))
                            {
                                SMatrix.Add(Index[(RowIndex - 1), (columnIndex - 1)], 0);
                                SMatrcixFiller++;
                            }
                            else
                            {
                                SMatrix.Add(Index[(RowIndex - 1), (columnIndex - 1)], SMatrcixFiller);
                                SMatrcixFiller++;
                            }
                            //resetting SMatrcixFiller
                            if (SMatrcixFiller == NumOfNodes + 1)
                            {
                                SMatrcixFiller = 1;
                            }
                        }
                        //generation of the values(keys) in the 2D Index[,] for the maximum nodes = 99 < NumOfNodes && NumOfNodes < 1000
                        else //if (99 < NumOfNodes && NumOfNodes <= CapacityRange)
                        {
                            Index[(RowIndex - 1), (columnIndex - 1)] = (CapacityRange * RowIndex) + columnIndex;
                            //making sure Smatrix diagonal is always 0
                            if (Index[(RowIndex - 1), (columnIndex - 1)] == ((CapacityRange + 1) * columnIndex))
                            {
                                SMatrix.Add(Index[(RowIndex - 1), (columnIndex - 1)], 0);
                                SMatrcixFiller++;
                            }
                            else
                            {
                                SMatrix.Add(Index[(RowIndex - 1), (columnIndex - 1)], SMatrcixFiller);
                                SMatrcixFiller++;
                            }
                            //resetting SMatrcixFiller
                            if (SMatrcixFiller == NumOfNodes + 1)
                            {
                                SMatrcixFiller = 1;
                            }
                        }
                    }

                }
                ////visualization of generated keys for virfication purposes
                int spacing = 0;
                //foreach (int id in Index)
                //{
                //    Console.Write("{0,-7}", id);
                //    //Console.Write(id + "  ");
                //    spacing++;
                //    if (spacing == NumOfNodes)
                //    {
                //        Console.WriteLine("\n");
                //        spacing = 0;
                //    }

                //}
                ////Smatrix visualization
                //foreach (DictionaryEntry de in SMatrix)
                //{
                //    int Value = (int)de.Value;
                //    Console.Write("{0,-7}", Value);
                //    //Console.Write(id + "  ");
                //    spacing++;
                //    if (spacing == NumOfNodes)
                //    {
                //        Console.WriteLine("\n");
                //        spacing = 0;
                //    }
                //}

                int Row = 1; int Column = 1;
                
                // int spacing = 0;
                Console.WriteLine("Input your data one after the other in the order stated below \n select the VALUE type i.e Infinity or Real Value\n ");

                for (int i = 0; i < (NumOfNodes * NumOfNodes); i++)
                {
                    ValueTypeLabel:

                    Console.Write("Select the value for R{0}C{1}" + "  ", Row, Column);
                    Console.WriteLine("\n\t1.Real value          2.Infinity");
                    int ValueType = 0;
                    while (!int.TryParse(Console.ReadLine(), out ValueType))
                    {
                        Console.Write("Select the value for R{0}C{1}" + "  ", Row, Column);
                        Console.WriteLine("\n\t1.Real value          2.Infinity");
                    }



                    if (ValueType == 1)
                    {
                        Console.Write("Input value for R{0}C{1}" + "  ", Row, Column);
                        float EditedValue = 0;
                        while ((!float.TryParse(Console.ReadLine(), out EditedValue)) && (EditedValue > float.MaxValue))
                        {
                            Console.WriteLine("Value out of range of program input \nI suggest you Enter a scaled value");
                        }
                        Dataset.Add(Index[Row - 1, Column - 1], EditedValue);
                        Column++;
                        if (Column == NumOfNodes + 1)
                        {
                            Column = 1;
                            Row++;
                        }
                        Console.Clear();
                    }
                    else if (ValueType == 2)
                    {
                        Console.Write("");
                        Dataset.Add(Index[Row - 1, Column - 1], IFN);
                        Column++;
                        if (Column == NumOfNodes + 1)
                        {
                            Column = 1;
                            Row++;
                        }
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option");
                        goto ValueTypeLabel;
                    }
                    //display of D_matrix on the point of input
                    foreach (DictionaryEntry DE in Dataset)

                    {
                        //note: IFN = "\u221E"
                        //int key = (int)DE.Key;
                        float FValue = (float)DE.Value;
                        //string SValue = DE.Value.ToString();
                        if ((float)DE.Value >= IFN)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0,-8}", "\u221E");
                            Console.ForegroundColor = ConsoleColor.White;
                            //Console.Write("IFN" + "  ");
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

                }
                //clearing the console for neater job
                Console.Clear();

                var FloydsAlgorithm = new FloydAlgorithm(Dataset, SMatrix, NumOfNodes, IFN, Index);
                //display of problem to be solved 
                FloydsAlgorithm.DisplayData();
                FloydsAlgorithm.DisplaySMatrix();

                Recursive: Console.WriteLine("1.Go to output           2.Edit inputs");
                int UserOption = 0;
                while (!int.TryParse(Console.ReadLine(), out UserOption))
                {
                    Console.WriteLine("Please input a valid option");
                    Console.WriteLine("1.Go to output           2.Edit inputs");
                }


                switch (UserOption)
                {
                    case 1:
                        FloydsAlgorithm.FloydsAlgorithmEngine();

                        break;
                    case 2:
                        Console.WriteLine("please enter the Row and column to be edited together....eg. 12 where 1 means row1 and 2 means column 2");
                        int EditKey = 0;
                        while ((!int.TryParse(Console.ReadLine(), out EditKey) ||  (SMatrix.Contains(EditKey)==false)))
                        {
                            Console.WriteLine("Error!!! Enter a valid Row and column be edited together eg. 12 where 1 means row1 and 2 means column 2");
                        }
                        Console.WriteLine("please enter the New value");
                        float Value = 0;
                        while ((!float.TryParse(Console.ReadLine(), out Value))  || Value>float.MaxValue)
                        {   
                            Console.WriteLine("Value out of range of program input \ni suggest you use a scaled value");
                        }
                        Dataset[EditKey] = Value;
                        Console.Clear();
                        Console.WriteLine("value updated");
                        FloydsAlgorithm.DisplayData();
                        FloydsAlgorithm.DisplaySMatrix();

                        FloydAlgorithm.EachIterationfiller = 0;
                        FloydAlgorithm.Count = 0;
                        FloydAlgorithm.IterationNumber = 0;
                        FloydAlgorithm.i = 0;
                        FloydAlgorithm.j = 0;

                        goto Recursive;

                    default:
                        Console.WriteLine("Please select a valid option");
                        goto Recursive;
                }
               //determination of feasible cost for any path selection
                ShortestRoute: Console.WriteLine("\tTo find the shortest route between Source Node and Destination Node ");
                Console.WriteLine("Input Source Node");
                int SourceNode = 0;
                while ((!int.TryParse(Console.ReadLine(), out SourceNode)) || SourceNode > NumOfNodes)
                {
                    Console.WriteLine("input a valid Source node");
                }
                Console.WriteLine("Input Destination Node");
                int DestinationNode = 0;
                while ((!int.TryParse(Console.ReadLine(), out DestinationNode)) || DestinationNode > NumOfNodes)
                {
                    Console.WriteLine("input a valid Destination node");
                }
                //implementing FloydsAlgorithm.DisplayResult 
                FloydsAlgorithm.DisplayResult(SourceNode, DestinationNode,CapacityRange);

                //does this user want to perfoem another operation on this program ???
                UserDecision: Console.WriteLine("\t1.Select another Set of SourceNode and Destination         2.Edit Table               3.MainMenu                  4.Exit Program       5.About");
                int _UserOption = 0;
                while ((!int.TryParse(Console.ReadLine(), out _UserOption)) && _UserOption > 5)
                {
                    Console.WriteLine("input a valid Destination node");
                }
                switch (_UserOption)
                {
                    case 1:
                        goto ShortestRoute;
                    case 2:
                        Console.Clear();
                        foreach (DictionaryEntry DE in Dataset)
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

                        goto Recursive;
                        
                    case 3:Console.Clear();
                        goto MainMenu;
                    case 4:
                        Environment.Exit(0);
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tThis program was developed by Sir Yhemmzy \n\tIn the course of his pursuit of Bachelor's Degree in Systems Engineering, University of Lagos");
                        Console.WriteLine("\tThe program was initially intended to meet the demands of the Course(Operation Researh) lecturer (DR. Ogunwolu) ");
                        Console.Write("\tBut later extended to meet public demands at solving shortest distance problems using the Floyd's Algorithm \n\t(c)2018. All rights reserve");
                        Console.WriteLine("\n ");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto UserDecision;
                    default:
                        Console.WriteLine("Please select a valid option");
                        goto UserDecision;
                }

            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tProgram Capacity Exceed\n\tPlease check input range info");
                Console.ForegroundColor = ConsoleColor.White;
                goto ValidCapacity;
            }
        }
    }
}
