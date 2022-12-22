using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pastel;
using System.Drawing;

namespace Tannenbaum_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sold = false;

            while (!sold)
            {
                int height = 0;
                Console.WriteLine("How big do you want your tree? All of our trees are at least 7 meters tall!\n");

                while (height < 7)
                {

                    string answer = Console.ReadLine();

                    try
                    {
                        height = int.Parse(answer);
                        
                        if(height <= 3)
                        {
                            beMad();
                        }
                    }
                    catch
                    {
                        beMad();
                    }
                }

                drawTree(height);

                askForLeaving();

            }
        }

        private static void beMad()
        {
            Console.WriteLine("Come on. Give a reasonable answer\n");
        }

        private static void drawTree(int m)
        {

            int row = 0;
            int logLength = 1;
            int treeLength = m - logLength;
            int neededSpace = m;
            
            string logSpace = "";

            //BEGINN BAUM   
            bool allClear = false;

            if (treeLength % 3 != 0)
            {
                int count = 0;
                
                while(!allClear)
                {
                    count -= 3;

                    int cut = treeLength + count;

                    if (cut < 3)
                    {
                        logLength += cut;
                        treeLength -= cut;
                        allClear = true;
                    }
                }
            }

            for (int i = 1; i <= treeLength; i++)
            {
                string tree = "*";
                string space = "";

                for (int j = i; j < 2 * i - 1 - row; j++)
                {
                    tree = string.Format("{0}**", tree);
                }


                for(int t = 0; t < neededSpace - i * 2 + row + i * 1; t++)
                {
                    space = string.Format("{0} ", space);

                    if (i == 1 + getExtraWidth(m) + row)
                    {
                        logSpace = space;
                    }
                }

                Console.WriteLine(string.Format("{0}{1}", space, tree).Pastel("#00ef40"));

                if (i % 3 == 0)
                {
                    row += 2;
                }
            }

            // BEGINN BAUMSTAMM
            string logWidth = "#";
            logWidth = string.Format("{0}{1}{2}", logSpace, logWidth, generateLogWidth(m)).Pastel("#7b5a49");

            for (int l = 0; l < logLength; l++)
            {
                Console.WriteLine(logWidth);
            }

        }

        private static int getExtraWidth(int height)
        {
            int count = 0;
            int width = 0;
            bool beenThrough = false;

            for (int i = height; !beenThrough; i -= 10)
            {
                count++;

                if (i < 10)
                {
                    width = count - 1;
                    beenThrough = true;
                }
            }

            return width;
        }

        private static string generateLogWidth(int height)
        {
            string width = "";

            for (int j = 0; j < getExtraWidth(height); j++)
            {
                width = string.Format("{0}##", width);
            }

            return width;
        }

        private static void askForLeaving()
        {
            Console.WriteLine("Thank you! Want another? \n1: Yes\t2: No\n");
            string answer = Console.ReadLine();
            
            if (answer == "2")
            {
                Environment.Exit(0);
            }
        }

        
    }
}
