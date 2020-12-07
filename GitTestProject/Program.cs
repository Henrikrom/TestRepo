using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GitTestProject
{
    class AD1
    {
        public static string[] input = System.IO.File.ReadAllLines(@"C:\Users\HenrikBjørnerudRomne\Desktop\Testrepo\AD1_Input.txt");

        public int[] tempArr = Array.ConvertAll(input, int.Parse);

        public void findSolution()
        {
            int a = 0;
            for (int i = 0; i < tempArr.Length; i++)
            {
                for (int j = a; j < tempArr.Length; j++)
                {
                    if (j < tempArr.Length -1)
                    {
                        if(tempArr[i] + tempArr[j] == 2020)
                        {
                            Console.WriteLine(tempArr[i] * tempArr[j]);
                        }
                        

                    }
                    
                }
                a += 1;
                
            }
            
        }
}

    class AD2
    {
        public static string[] input = System.IO.File.ReadAllLines(@"C:\Users\HenrikBjørnerudRomne\Desktop\Testrepo\AD2_Input.txt");       
        int pwdStart;
        
        public int getFirstNr(int line)
        {
            
            string str = string.Empty;
            for (int i = 0; i < input[line].Length; i++)
            {
                if (Char.IsDigit(input[line][i]))
                {                    
                    str += input[line][i];                    
                }
                else if (Convert.ToString(input[line][i]) == "-")
                {                    
                    break;
                }
                
            }

            return Convert.ToInt32(str);
        }

        public int getSecondNr(int line)
        {
            string str = string.Empty;
            bool dashFound = false;
            int startPoint;

            int it = 0;
            while (!dashFound)
            {
                if (Convert.ToString(input[line][it]) == "-")
                {
                    dashFound = true;
                }
                it += 1;
            }
            startPoint = it;

            for (int i = it; i < input[line].Length; i++)
            {
                if (Char.IsDigit(input[line][i]))
                {
                    str += input[line][i];
                }
                else if (Convert.ToString(input[line][i]) == " ")
                {
                    break;
                }
            }
            return Convert.ToInt32(str);
        }

        public string getChar(int line)
        {

            bool spaceFound = false;
            int pos;

            int it = 0;
            while (!spaceFound)
            {
                if (Convert.ToString(input[line][it]) == " ")
                {
                    spaceFound = true;
                }
                it += 1;
            }
            pos = it;
            pwdStart = pos + 3;

            return Convert.ToString(input[line][pos]);
        }

        public bool legalPwd(int line)
        {
            int a = getFirstNr(line);
            int b = getSecondNr(line);
            string c = getChar(line);

            int countLetter = 0;

            for (int i = pwdStart; i < input[line].Length; i++)
            {                
                if (Convert.ToString(input[line][i]) == c)
                {
                    countLetter += 1;
                }
            }

            if (countLetter >= a && countLetter <= b)
            {
                return true;
            }
            else { return false; }
        }

        public int printLegalPwds()
        {
            int countValid = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (legalPwd(i))
                {
                    countValid += 1;
                }
            }
            return countValid;
        }

        public bool legalPwd2(int line)
        {
            int a = getFirstNr(line);
            int b = getSecondNr(line);
            string c = getChar(line);            

            if (Convert.ToString(input[line][pwdStart+a-1]) == c && Convert.ToString(input[line][pwdStart + b-1]) != c)
            {
                return true;
            }
            else if (Convert.ToString(input[line][pwdStart + a-1]) != c && Convert.ToString(input[line][pwdStart + b-1]) == c)
            {
                return true;
            }
            else { return false; }
        }
         
        public int printLegalPwds2()
        {
            int countValid = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (legalPwd2(i))
                {
                    countValid += 1;
                }
            }
            return countValid;
        }

    }

    class AD3
    {
        public static string[] input = System.IO.File.ReadAllLines(@"C:\Users\HenrikBjørnerudRomne\Desktop\Testrepo\AD2_Input.txt");
    }


    class Program
    {
        
        static void Main(string[] args)
        {
            AD2 obj = new AD2();

            Console.WriteLine(obj.printLegalPwds2());
            //fefjei
        }  


    }                
}
