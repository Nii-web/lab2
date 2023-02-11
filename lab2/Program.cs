using System;
using System.IO;

class Program
 {
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
                                               

                                               

                                                string save;
                                                do
                                                {
                                                    Console.Write("Do you want to save results to file?(y,n): ");
                                                    save = Console.ReadLine()!;

                                                    if (save == "y" || save == "Y")
                                                    {


                                                    }
                                                    else if (save == "n" || save == "N")
                                                        break;
                                                    else
                                                        Console.WriteLine("Invalid input");
                                                } while (save != "y" || save != "Y" || save == "n" || save == "N");


                                                
                                                
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
    static int binaryMedian(int[,] m, int r, int c)
    {
        // r and c represent the row and column size correspondingly
        int max = int.MinValue;
        int min = int.MaxValue;

        for (int i = 0; i < r; i++)
        {
            // Finding the minimum element
            if (m[i, 0] < min)
                min = m[i, 0];

            // Finding the maximum element
            if (m[i, c - 1] > max)
                max = m[i, c - 1];
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
                get = Array.BinarySearch(GetRow(m, i), mid);

                // If element is not found in the array the binarySearch() method returns (-(insertion point) - 1).
                // So once we know the insertion point we can find elements Smaller than the searched element by the following calculation
                if (get < 0)
                    get = Math.Abs(get) - 1;

                // If element is found in the array it returns the index(any index in case of duplicate). So we go to last index of element
                // which will give  the number of elements smaller than the number including the searched element.
                else
                {
                    while (get < GetRow(m, i).GetLength(0) && m[i, get] == mid)
                        get += 1;
                }

                place = place + get;
            }

            if (place < desired)
                min = mid + 1;
            else
                max = mid;
        }
        return min;
    }


    public static void bubbleSort(int[,]arr, int r, int c)
    {
        int temp;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                for (int k = 0; k < c - j - 1; k++)
                {
                    
                    if (arr[i,k] < arr[i,k + 1])
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

