using System;
using System.Data.Common;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;

class Program
 {
    static void print_array(int[,]newarr, int row, int column) 
    {
        Console.WriteLine("Sorted Array");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write("[{0}][{1}]:", i + 1, j + 1);
                Console.Write(newarr[i, j] + " ");
            }
            Console.WriteLine(" ");
        }
    }

    static int inputValidation(string a,int b)
    {
        while ((!int.TryParse(a, out b)) || b <= 0)
        {
            Console.WriteLine("Invalid input");
            a = Console.ReadLine()!;
        }
        return b;
        /*while(b<=0)
        {
            Console.WriteLine("Invalid input");
            a = Console.ReadLine()!;
        }*/

    }

    static int getint(string a,int b)
    {
        while (!int.TryParse(a, out b))
        {
            Console.WriteLine("Invalid input");
            Convert.ToInt32(Console.ReadLine()!);
        }
        return b;
    }

    static void save_result_to_file(StreamWriter method,int row, int column, string path, int[,] newarr)
    {
        //using var rewrite = new StreamWriter(fs);
        //rewrite = new StreamWriter(path, app);
        method.WriteLine(row);
        method.WriteLine(column);
        //string? file_str;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                method.WriteLine(newarr[i,j]);
            }
        }
        
    }

    static void save_all_res(int[,]newarr, int row, int column)
    {
        string save_results;
        Console.Write("Do you want to save results to a file?(y/n): ");
        do
        {
            save_results = Console.ReadLine()!;
            if (save_results == "y" || save_results == "Y")
            {
                Console.WriteLine("yes");
                Console.Write("Enter file name: ");
                string path = Console.ReadLine()!;
                if (File.Exists(path))
                {
                    string file_exist;
                    //bool reader;
                    Console.WriteLine("File already exists! do you want to rewrite(rw), append(a) or create a new file(nf)?:");
                    do
                    {
                        file_exist = Console.ReadLine()!;
                        if (file_exist == "rw" || file_exist == "rW" || file_exist == "Rw" || file_exist == "RW")
                        {
                            Console.WriteLine("Rewriting file...");
                            using (StreamWriter rewrite = new StreamWriter(path, false))
                            {
                                rewrite.WriteLine(row);
                                rewrite.WriteLine(column);

                                for (int i = 0; i < row; i++)
                                {
                                    for (int j = 0; j < column; j++)
                                    {
                                        rewrite.WriteLine(newarr[i, j]);
                                    }
                                }
                                rewrite.Close();
                            }
                            break;
                        }
                        else if (file_exist == "a" || file_exist == "A")
                        {
                            Console.WriteLine("Appending file...");
                            //reader = true;

                            using (StreamWriter app = new StreamWriter(path, true))
                            {
                                app.WriteLine(row);
                                app.WriteLine(column);

                                for (int i = 0; i < row; i++)
                                {
                                    for (int j = 0; j < column; j++)
                                    {
                                        app.WriteLine(newarr[i, j]);
                                    }
                                }
                                app.Close();
                            }


                            break;
                        }
                        else if (file_exist == "nf" || file_exist == "nF" || file_exist == "Nf" || file_exist == "NF")
                        {
                            Console.WriteLine("Creating new file...");
                            Console.Write("Enter file name: ");
                            string nfile = Console.ReadLine()!;
                            while (File.Exists(nfile))
                            {
                                Console.Write("File already exists! Enter a different file name: ");
                                nfile = Console.ReadLine()!;
                            }

                            TextWriter new_file = new StreamWriter(nfile,true);

                            new_file.WriteLine(row);
                            new_file.WriteLine(column);

                            for (int i = 0; i < row; i++)
                            {
                                for (int j = 0; j < column; j++)
                                {
                                    new_file.WriteLine(newarr[i, j]);
                                }
                            }
                            new_file.Close();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again: ");
                        }

                    } while (file_exist != "rw" || file_exist != "rW" || file_exist != "Rw" || file_exist != "RW" ||
                             file_exist != "a" || file_exist != "A" ||
                             file_exist != "nf" || file_exist != "nF" || file_exist != "Nf" || file_exist != "NF");

                }

                else
                {
                    using FileStream fs = File.Create(path);
                    using var file = new StreamWriter(fs);
                    file.WriteLine(row);
                    file.WriteLine(column);
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            file.WriteLine(newarr[i, j]);
                        }
                    }
                    file.Close();
                }
                //StreamWriter file = new StreamWriter(path);
                break;
            }
            else if (save_results == "n" || save_results == "N")
            {
                Console.WriteLine("no");
                break;
            }
            else
                Console.WriteLine("Invalid input, try again: ");


        } while (save_results != "y" || save_results != "Y" || save_results == "n" || save_results == "N");

    }

    static void save_initial(int[,]newarr, int row, int column)
    {
        Console.Write("Do you want to save initial data for file?(y/n)");
        string save_initial;
        do
        {
            save_initial = Console.ReadLine()!;
            if (save_initial == "y" || save_initial == "Y")
            {
                Console.WriteLine("yes");
                Console.Write("Enter file name: ");
                string initial_path = Console.ReadLine()!;

                /*if (!File.Exists(initial_path))
                { // Create a file to write to
                    //StreamWriter rewrite = new StreamWriter(initial_path);

                   

                    int tmp = 7;
                    for(int i = 0;i<row;i++)
                    {
                        for(int j=0; j<column;j++)
                        {
                            sw.WriteLine(newarr[i,j]);
                        }
                    }

                    sw.WriteLine(tmp);
                }
                else
                {
                    Console.WriteLine("File already exists! do you want to rewrite(rw), append(a) or create a new file(nf)?:");
                }*/


                if (File.Exists(initial_path))
                {

                    
                    string file_exist;
                    //bool reader;
                    Console.WriteLine("File already exists! do you want to rewrite(rw), append(a) or create a new file(nf)?:");
                    do
                    {
                        file_exist = Console.ReadLine()!;
                        if (file_exist == "rw" || file_exist == "rW" || file_exist == "Rw" || file_exist == "RW")
                        {
                            Console.WriteLine("Rewriting file...");
                            using (StreamWriter rewrite = new StreamWriter(initial_path, false))
                            {
                                rewrite.WriteLine(row);
                                rewrite.WriteLine(column);

                                for (int i = 0; i < row; i++)
                                {
                                    for (int j = 0; j < column; j++)
                                    {
                                        rewrite.WriteLine(newarr[i, j]);
                                    }
                                }
                                rewrite.Close();
                            }  
                            break;
                        }
                        else if (file_exist == "a" || file_exist == "A")
                        {
                            Console.WriteLine("Appending file...");
                            using (StreamWriter app = new StreamWriter(initial_path, true))
                            {
                                app.WriteLine(row);
                                app.WriteLine(column);

                                for (int i = 0; i < row; i++)
                                {
                                    for (int j = 0; j < column; j++)
                                    {
                                        app.WriteLine(newarr[i, j]);
                                    }
                                }
                                app.Close();
                            } 
                            break;
                        }
                        else if (file_exist == "nf" || file_exist == "nF" || file_exist == "Nf" || file_exist == "NF")
                        {
                            Console.WriteLine("Creating new file...");
                            Console.Write("Enter file name: ");
                            string nfile = Console.ReadLine()!;
                            while (File.Exists(nfile))
                            {
                                Console.Write("File already exists! Enter a different file name: ");
                                nfile = Console.ReadLine()!;
                            }

                            TextWriter new_file = new StreamWriter(nfile, true);

                            new_file.WriteLine(row);
                            new_file.WriteLine(column);

                            for (int i = 0; i < row; i++)
                            {
                                for (int j = 0; j < column; j++)
                                {
                                    new_file.WriteLine(newarr[i, j]);
                                }
                            }
                            new_file.Close();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again: ");
                        }

                    } while (file_exist != "rw" || file_exist != "rW" || file_exist != "Rw" || file_exist != "RW" ||
                             file_exist != "a" || file_exist != "A" ||
                             file_exist != "nf" || file_exist != "nF" || file_exist != "Nf" || file_exist != "NF");

                }

                else
                {
                    using FileStream fs = File.Create(initial_path);
                    using var file = new StreamWriter(fs);

                    file.WriteLine(row);
                    file.WriteLine(column);

                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            file.WriteLine(newarr[i, j]);
                        }
                    }
                    file.Close();
                }
                //StreamWriter file = new StreamWriter(path);
                break;
            }
            else if (save_initial == "n" || save_initial == "N")
            {
                Console.WriteLine("no");
                break;
            }
            else
                Console.WriteLine("Invalid input, try again: ");


        } while (save_initial != "y" || save_initial != "Y" || save_initial == "n" || save_initial == "N");


    }
    //Driver Code
    public static void Main(string[] args)
        {
            Console.WriteLine("Аджей-Бой Нии Аджетей");
            Console.WriteLine("Группа 414");
            Console.WriteLine("Вариант 1");
            Console.WriteLine("Напишите программу, находящую медиану массива. То есть индекс ячейки массива, " +
                "сумма элементов слева от которой минимально отличается от суммы элементов справа.");

            string? userchoice_main;//'?' indicates that return type is nullable
            string? userchoice_sub;
            int mainmenu_option;
            int sub_option;
            //string path;
        

            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Start");
                Console.WriteLine("2 - exit");

                userchoice_main = Console.ReadLine();

                int.TryParse(userchoice_main, out mainmenu_option);

                if (mainmenu_option != 2)
                {

                    if (int.TryParse(userchoice_main, out mainmenu_option))
                    {
                        if (mainmenu_option < 1 || mainmenu_option > 3)
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        else
                        {
                        
                        int row;
                        int column;
                        int element;
                        switch (mainmenu_option)
                            {
                                case 1:
                                    //Console.WriteLine("Valid input");
                                    do
                                    {

                                        Console.WriteLine("\nSelect input method");
                                        Console.WriteLine("1 - Keyboard");
                                        Console.WriteLine("2 - file");
                                        Console.WriteLine("3 - Return to main menu");

                                        userchoice_sub = Console.ReadLine();

                                        int.TryParse(userchoice_sub, out sub_option);

                                    switch (sub_option)
                                    {
                                        case 1:
                                            //Rows
                                            Console.Write("Enter number of rows: ");
                                            var rowString = Console.ReadLine()!;
                                            int.TryParse(rowString, out row);
                                            row = inputValidation(rowString, row);

                                            //Columns
                                            Console.Write("Enter number of columns: ");
                                            var colString = Console.ReadLine()!;
                                            int.TryParse(colString, out column);
                                            column = inputValidation(colString, column);


                                            //int[] array_name = new int[array_size]; -- Defining a dynamic array
                                            int[,] newarr = new int[row, column];

                                            Console.WriteLine("Enter the elements of the array: ");
                                            for (int i = 0; i < row; i++)
                                            {
                                                for (int j = 0; j < column; j++)
                                                {
                                                    //a:

                                                    //"[" << i + 1 << "][" << j + 1 << "]: ";
                                                    
                                                    Console.Write("[{0}][{1}]: ", i + 1, j + 1);
                                                    string elString = Console.ReadLine()!;
                                                    //int.TryParse(elString, out element);
                                                    //element = inputValidation(elString, element);
                                                    bool isNumeric = int.TryParse(elString, out element);
                                                    do
                                                    {
                                                        if (isNumeric)
                                                        {
                                                            int.TryParse(elString, out element);
                                                            newarr[i, j] = getint(elString, element);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid input");
                                                            Console.Write("[{0}][{1}]: ", i + 1, j + 1);
                                                            
                                                            elString = Console.ReadLine()!;
                                                            isNumeric = int.TryParse(elString, out element);
                                                            //int.TryParse(elString, out element);
                                                            newarr[i, j] = getint(elString, element);
                                                        }
                                                    } while (!isNumeric);
                                                }
                                                Console.WriteLine(" ");
                                            }
                                            bubbleSort(newarr, row, column);
                                            //display sorted array
                                            print_array(newarr, row, column);

                                            //Save to initial data file goes here
                                            int Median = binaryMedian(newarr, row, column);
                                            save_initial(newarr, row, column);

                                            
                                            Console.WriteLine("Median is " + Median);

                                            //Save results to file
                                            save_all_res(newarr, row, column);                                         
                                              

                                                break;
                                            case 2:
                                                Console.WriteLine("File input");

                                                string file_name;
                                                Console.Write("Enter file name to read data from: ");
                                                file_name = Console.ReadLine()!;


                                                if (File.Exists(file_name))
                                                {
                                                    StreamReader dataStream = new StreamReader(file_name);

                                                    string data = dataStream.ReadLine()!;

                                                    
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("File does not exist in directory!");
                                                    Console.WriteLine("Returning to previous menu");
                                                    break;
                                                }
;
                                            case 3:
                                                Console.WriteLine("Returning to main menu...");
                                                break;
                                        }

                                    } while (sub_option != 3);
                                    break;
                                case 2:
                                    Console.WriteLine("exiting program");
                                    break;

                            }




                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }


            } while (mainmenu_option != 2);


        }

    // Function to find median in the matrix
    static int binaryMedian(int[,] arr, int r, int c)
    {
        // r and c represent the row and column size correspondingly
        int max = int.MinValue;
        int min = int.MaxValue;

        for (int i = 0; i < r; i++)
        {
            // Finding the minimum element
            if (arr[i, 0] < min)
                min = arr[i, 0];

            // Finding the maximum element
            if (arr[i, c - 1] > max)
                max = arr[i, c - 1];
        }

        int desired = (r * c + 1) / 2;
        while (min < max)
        {
            int mid = min + (max - min) / 2;
            int place = 0;
            int get = 0;

            // Find count of elements smaller than or equal to mid
            for (int i = 0; i < r; ++i)
            {
                get = Array.BinarySearch(GetRow(arr, i), mid);

                // If element is not found in the array the binarySearch() method returns (-(insertion point) - 1).
                // So once we know the insertion point we can find elements Smaller than the searched element by the following calculation
                if (get < 0)
                    get = Math.Abs(get) - 1;

                // If element is found in the array it returns the index(any index in case of duplicate). So we go to last index of element
                // which will give  the number of elements smaller than the number including the searched element.
                else
                {
                    while (get < GetRow(arr, i).GetLength(0) && arr[i, get] == mid)
                        get += 1;
                }

                place = place + get;
            }

            if (place < desired)
                min = mid + 1;
            else
                max = mid;
        }
        int count = 0;
        for(int j = 0; j < r; j++)
        {
            for(int k=0;k<c;k++)
            {
                if (arr[j,k] == min)
                {
                    Console.WriteLine("\nThe median index is:[{0}][{1}]", j+1,k+1);
                    count++;
                }
            }
        }
        if(count>1)
        { Console.WriteLine("Two indices represent the median"); }
       
        return min;
    }

    //Sort array row-wise
    public static void bubbleSort(int[,]arr, int r, int c)
    {
        int temp;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                for (int k = 0; k < c - j - 1; k++)
                {
                    
                    if (arr[i,k] > arr[i,k + 1])
                    {
                        temp = arr[i,k];
                        arr[i, k] = arr[i,k + 1];
                        arr[i,k + 1] = temp;
                        //swap(arr[i][k], arr[i][k + 1]);
                       
                    }
                }
            }
        }

    }
    public static int[] GetRow(int[,] matrix,int row)
    {
        var rowLength = matrix.GetLength(1);
        var rowVector = new int[rowLength];

        for (var i = 0; i < rowLength; i++)
            rowVector[i] = matrix[row, i];

        return rowVector;
    }
}

