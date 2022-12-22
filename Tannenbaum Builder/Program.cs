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
        static Random random = new Random();

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

                bool decorated = askForDecoration();
                drawTree(height, decorated);

                askForLeaving();

            }
        }

        private static void beMad()
        {
            Console.WriteLine("Come on. Give a reasonable answer\n");
        }

        private static void drawTree(int m, bool decorated)
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
                string space = "";
                string tree;

                if (decorated)
                {
                    tree = "*".Pastel(getRandColor());
                }
                else
                {
                    tree = "*".Pastel("#00ef40");
                }

                for (int j = i; j < 2 * i - 1 - row; j++)
                {
                    tree = string.Format("{0}{1}", tree, getDecoration(decorated));
                }


                for(int t = 0; t < neededSpace - i * 2 + row + i * 1; t++)
                {
                    space = string.Format("{0} ", space);

                    if (i == 1 + getExtraWidth(m) + row)
                    {
                        logSpace = space;
                    }
                }

                Console.WriteLine(string.Format("{0}{1}", space, tree));

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

        private static string getDecoration(bool decoration)
        {

            string text = "";

            if (decoration)
            {
                for(int i = 0; i < 2; i++)
                {
                    text = string.Format("{0}{1}", text, "*".Pastel(getRandColor()));
                }
            }

            else
            {
                text = "**".Pastel("#00ef40");
            }

            return text;
        }

        private static string getRandColor()
        {
            string[] colorOptions = new string[] { "#ea2e06", "#06ffff", "#a229ea", "#fb195c", "#faff2e" }; 

            int color = random.Next(0, 50);

            if (color <= 4)
            {
                return colorOptions[color];
            }

            else
            {
                return "#00ef40";
            }
        }

        private static bool askForDecoration()
        {
            Console.WriteLine("You wanna buy an undecorated or a decorated tree?\n\t1:Decorated\t2:Undecorated");
           
            if (Console.ReadLine() == "1")
            {
                return true;
            }
           
            return false;
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
            bool answered = false;

            while (!answered)
            {
                Console.WriteLine("Thank you! Want another? \n1: Yes\t2: No\n");
                string answer = Console.ReadLine();

                if (answer == "2")
                {
                    Environment.Exit(0);
                }

                else if (answer == "1")
                {
                    answered = true;
                }
            }
        }
    }
}
