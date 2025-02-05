using System;

class Program
{
    static void Main(string[] args)
    {
       Journal journal1 = new Journal();
       int menu = 0;
       while (menu is not 5)
       {
        Console.WriteLine("1:Write a new entry: \n 2:View old journals: \n 3:Save \n 4:Load");
        menu = int.Parse(Console.ReadLine());
        if(menu==1)
        {
            journal1.AddEntry();

            

        }
            if(menu==2)
            {
                journal1.DisplayEntries();

            }
            if(menu==3)
            {
                journal1.SaveToFile();

            }
    if(menu==4)
    {
        journal1.LoadFromFile();

    }
       }
    }
}