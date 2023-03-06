using System.Reflection.PortableExecutable;
using System.IO;
using System.Drawing;

public class Binary
 {
    static void print_array(int[]newarr, int row) 
    {
        Console.WriteLine("Sorted Array");
        for (int i = 0; i < row; i++)
        {
            Console.Write("[{0}]: ", i + 1);
            Console.Write(newarr[i] + " ");
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
    static int file_inputValidation(string a, int b, StreamReader datastream)
    {
        while ((!int.TryParse(a, out b)) || b <= 0)
        {
            Console.WriteLine("File contains unsupported data type!");
            break;
        }
        return b;
    }
   
    static void save_all_res(int[]newarr, int row, int median)
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

                                for (int i = 0; i < row; i++)
                                {
                                    rewrite.WriteLine(newarr[i]);
                                }
                                rewrite.WriteLine(median);
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

                                for (int i = 0; i < row; i++)
                                {
                                    app.WriteLine(newarr[i]);
                                }
                                app.WriteLine(median);
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

                            for (int i = 0; i < row; i++)
                            {
                                new_file.WriteLine(newarr[i]);
                            }
                            new_file.WriteLine(median);
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
                    if (path == "con")
                    {
                        //work with con
                        do
                        {
                            Console.WriteLine("This file name is not allowed! Enter a different name: ");
                            path = Console.ReadLine()!;
                        } while (path == "con");

                    }
                    else
                    {
                        using FileStream fs = File.Create(path);
                        using var file = new StreamWriter(fs);
                        file.WriteLine(row);
                        for (int i = 0; i < row; i++)
                        {
                            file.WriteLine(newarr[i]);
                        }
                        file.Close();
                    }
                    
                    
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

    static void save_initial(int[]newarr, int row)
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

                                for (int i = 0; i < row; i++)
                                {
                                    rewrite.WriteLine(newarr[i]);
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
                               

                                for (int i = 0; i < row; i++)
                                {
                                    app.WriteLine(newarr[i]);
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
                            

                            for (int i = 0; i < row; i++)
                            {
                                new_file.WriteLine(newarr[i]);
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
                    bool file_ok;
                    do
                    {
                        try
                        {
                            using FileStream file_sys = File.Create(initial_path);
                            if (file_sys != null)
                                file_sys.Close();
                            file_ok = true;
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Invalid file name! Enter a different name: ");
                            initial_path = Console.ReadLine()!;
                            file_ok =  false;
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name! Enter a different name: ");
                            initial_path = Console.ReadLine()!;
                            file_ok = false;
                        }
                    } while (file_ok == false);
                    

                    using FileStream fs = File.Create(initial_path);
                    using var file = new StreamWriter(fs);

                    file.WriteLine(row);

                    for (int i = 0; i < row; i++)
                    {
                        file.WriteLine(newarr[i]);
                    }
                    /*if (initial_path == "con")
                    {
                        //work with con
                        do
                        {
                            Console.WriteLine("This file name is not allowed! Enter a different name: ");
                            initial_path = Console.ReadLine()!;
                        } while (initial_path == "con");

                    }*/
                    /* else
                     {
                         using FileStream fs = File.Create(initial_path);
                         using var file = new StreamWriter(fs);

                         file.WriteLine(row);

                         for (int i = 0; i < row; i++)
                         {
                             file.WriteLine(newarr[i]);
                         }
                     }*/
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
    public static void Main()
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
                        
                        int size;
                        //int column;
                        int element;
                        int Median = 0;
                        switch (mainmenu_option)
                            {
                                case 1:
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
                                            Console.Write("Enter number of size of array: ");
                                            var rowString = Console.ReadLine()!;
                                            int.TryParse(rowString, out size);
                                            size = inputValidation(rowString, size);


                                            //int[] array_name = new int[array_size]; -- Defining a dynamic array
                                            int[] newarr = new int[size];

                                            Console.WriteLine("Enter the elements of the array: ");
                                            for (int i = 0; i < size; i++)
                                            {
                                                Console.Write("[{0}]: ", i + 1);
                                                string elString = Console.ReadLine()!;

                                                bool isNumeric = int.TryParse(elString, out element);
                                                do
                                                {
                                                    if (isNumeric)
                                                    {
                                                        int.TryParse(elString, out element);
                                                        newarr[i] = getint(elString, element);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid input");
                                                        Console.Write("[{0}]: ", i + 1);

                                                        elString = Console.ReadLine()!;
                                                        isNumeric = int.TryParse(elString, out element);
                                                        newarr[i] = getint(elString, element);
                                                    }
                                                } while (!isNumeric);
                                                Console.WriteLine(" ");
                                            }
                                            
                                            

                                            //Save to initial data file goes here
                                            binaryMedian(newarr, size,ref Median);
                                            save_initial(newarr, size);


                                            Console.WriteLine("The median of the array has an index: [{0}] ", Median);

                                            //Save results to file
                                            save_all_res(newarr, size,Median);

                                            break;

                                        case 2:
                                            Console.WriteLine("File input");

                                            string file_name;
                                            Console.Write("Enter file name to read data from: ");
                                            file_name = Console.ReadLine()!;



                                            if (File.Exists(file_name))
                                            {
                                                //StreamReader dataStream = new StreamReader(file_name);
                                                using var filestream = File.OpenRead(file_name);
                                                    

                                                using (var dataStream = new StreamReader(file_name))
                                                {

                                                    var row_file_String = dataStream.ReadLine()!;
                                                    int.TryParse(row_file_String, out size);
                                                    size = file_inputValidation(row_file_String, size, dataStream);


                                                    string line;
                                                    int count = 0;

                                                    while((line= dataStream.ReadLine()!) != null)
                                                    {
                                                        count++;
                                                    }
                                                    filestream.Close();

                                                    File.OpenRead(file_name);
                                                    if(size != count)
                                                    {
                                                        Console.WriteLine("Number of rows and columns does not correspond with number of elements in file!");
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        line = "";
                                                        dataStream.ReadLine();

                                                        int[] filearray = new int[size];
                                                        using(TextReader reader = File.OpenText(file_name))
                                                        {
                                                            reader.ReadLine();
                                                            for(int i = 0;i<(size);i++)
                                                            {
                                                                filearray[i] = int.Parse(reader.ReadLine()!);
                                                            }
                                                        }

                                                        for (int i = 0; i < (size); i++)
                                                        {
                                                            Console.Write("[{0}]: ",i+1);
                                                            Console.WriteLine(filearray[i]);
                                                        }
                                                        binaryMedian(filearray, size, ref Median);
                                                        save_initial(filearray, size);

                                                        Console.WriteLine("The median of the array has an index: [{0}] ", Median);

                                                        //Save results to file
                                                        save_all_res(filearray, size, Median);
                                                    }
                                                }
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
                                    Console.WriteLine("Exiting program...");
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
    public static void binaryMedian(int[] arr, int size, ref int median)
    {
        int max = -1;
        int min = arr[0];
        int left_sum = 0;
        int right_sum = 0;
        for (int i = 1; i < size - 1; i++)
        {  // minimal difference	 
            left_sum = 0;
            right_sum = 0;
            for (int j = 0; j < i; j++)
                left_sum += arr[j];
            for (int k = i + 1; k < size; k++)
                right_sum += arr[k];
            if (Math.Abs(left_sum - right_sum) >= max)
                max = Math.Abs(left_sum - right_sum);
        }
        for (int i = 1; i < size - 1; i++)
        {
            left_sum = 0;
            right_sum = 0;
            for (int j = 0; j < i; j++)
                left_sum += arr[j];
            for (int k = i + 1; k < size; k++)
                right_sum += arr[k];
            if (Math.Abs(left_sum - right_sum) <= max)
                max = Math.Abs(left_sum - right_sum);
        }
       
        int count = 0;
        for (int i = 1; i < size - 1; i++)
        {
            left_sum = 0;
            right_sum = 0;
            for (int j = 0; j < i; j++)
                left_sum += arr[j];
            for (int k = i + 1; k < size; k++)
                right_sum += arr[k];
            if (Math.Abs(left_sum - right_sum) == max)
            {
                median = i+1;
                count++;
            }
            if (count > 1)
                break;
        }
    }
}

