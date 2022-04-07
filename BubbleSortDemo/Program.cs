namespace BubbleSortDemo
{
    public static class Program
    {
        public static void Main()
        {
            var numbersUnOrdered = new List<int> { 5200, -230, -55, -23, 1, 0, -1, -10, -245, -4500 };
            var numbersToGetOrdered = new List<int>(numbersUnOrdered);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Bubble Sort Demo by Behzad Seyfi  (C) 2022");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("Smaller Cell");
            Console.ResetColor();
            Console.Write(" in Dark Blue, ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("Greater Cell");
            Console.ResetColor();
            Console.Write(" in Light Blue\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n#CS_INTERNSHIP  #CSHARP  #STEP1");

            numbersToGetOrdered = BubbleSort(numbersUnOrdered, true, true, 400);
            Console.WriteLine("\n\n\n");
            Console.ResetColor();
        }
        public static List<int> BubbleSort(List<int> unOrderedList, bool animationOn = false, bool delayFlag = false, int animationStepDelay = 0)
        {

            int temp = 0;
            bool animFlag = false;
            int x0=0, y0=0, MAX_DIGITS=0, PADDINGS=0, SPACING_DIGITS=0;

            if (animationOn)
            {
                x0 = Console.CursorLeft;
                y0 = Console.CursorTop;
                MAX_DIGITS = Math.Max(Math.Abs(unOrderedList.Max()), Math.Abs(unOrderedList.Min())).ToString().Length
                   + (unOrderedList.Min() < 0 ? 1 : 0);// 1 character for minus sign
                PADDINGS = 10;
                SPACING_DIGITS = 2;
            }

            for (int endFlag = unOrderedList.Count - 1; endFlag > 0; endFlag--)
            {
                int index = 0;
                for (index = 0; index < endFlag; index++)
                {
                    animFlag = false;
                    if (unOrderedList[index] > unOrderedList[index + 1])
                    {
                        temp = unOrderedList[index];
                        unOrderedList[index] = unOrderedList[index + 1];
                        unOrderedList[index + 1] = temp;

                        animFlag = true;//For demo purposes
                    }
                    
                    //For demo purpose
                    if (animationOn)
                        animateSinglePass(index, index + 1, endFlag, unOrderedList, animFlag, MAX_DIGITS, PADDINGS, SPACING_DIGITS, x0, y0, delayFlag, animationStepDelay);
                }
            }
            return unOrderedList;
        }
        public static void animateSinglePass(int indexStart, int indexEnd, int endFlag, List<int> unOrderedList, bool animFlag, int MAX_DIGITS, int PADDINGS, int SPACING_DIGITS, int xStart = 0, int yStart = 0, bool delayFlag = false, int delayMiliSeconds = 0)
        {

            var lowBackColor = ConsoleColor.DarkBlue;
            var highBackColor = ConsoleColor.Blue;
            var compareForeColor = ConsoleColor.Yellow;
            var comparePrimitiveBackColor = ConsoleColor.White;
            var comparePrimitiveForeColor = ConsoleColor.Black;
            var defaultBackColor = ConsoleColor.Black;
            var defaultForeColor = ConsoleColor.White;
            var defualtArrowForeColor = ConsoleColor.Red;



            if (delayFlag)
                System.Threading.Thread.Sleep(delayMiliSeconds);

            //clear screen
            Console.SetCursorPosition(xStart + PADDINGS, yStart + 2);
            Console.WriteLine(new string(' ', Console.WindowWidth));//clear screen line 1
            Console.WriteLine(new string(' ', Console.WindowWidth));//clear screen line 2

            //
            //Console.SetCursorPosition(xStart + PADDINGS, yStart + 2);

            //First Pass - Drawing pre sorted
            Console.ResetColor();
            int x0 = xStart + PADDINGS;
            int y0 = yStart + 2;

            if (animFlag)//swap happened
            {

                for (int index = 0; index < unOrderedList.Count; index++)
                {
                    Console.ResetColor();
                    if (index == indexStart)
                    {
                        Console.BackgroundColor = comparePrimitiveBackColor;
                        Console.ForegroundColor = comparePrimitiveForeColor;
                        Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * (index + (animFlag ? 1 : -1) * (indexEnd - indexStart)), y0);
                    }
                    else if (index == indexEnd)
                    {
                        Console.BackgroundColor = comparePrimitiveBackColor;
                        Console.ForegroundColor = comparePrimitiveForeColor;
                        Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * (index - (animFlag ? 1 : -1) * (indexEnd - indexStart)), y0);
                    }
                    else
                    {
                        Console.BackgroundColor = defaultBackColor;
                        Console.ForegroundColor = defaultForeColor;
                        Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * index, y0);
                    }

                    Console.Write($"{{0,{-MAX_DIGITS - SPACING_DIGITS}:D}}", unOrderedList[index]);
                }
                Console.ResetColor();
            }
            else//swap not happened
            {
                Console.SetCursorPosition(xStart + PADDINGS, yStart + 2);
                for (int index = 0; index < unOrderedList.Count; index++)
                {
                    Console.ResetColor();
                    if (index == indexStart)
                    {
                        Console.BackgroundColor = comparePrimitiveBackColor;
                        Console.ForegroundColor = comparePrimitiveForeColor;
                    }
                    else if (index == indexEnd)
                    {
                        Console.BackgroundColor = comparePrimitiveBackColor;
                        Console.ForegroundColor = comparePrimitiveForeColor;
                    }
                    else
                    {
                        Console.BackgroundColor = defaultBackColor;
                        Console.ForegroundColor = defaultForeColor;
                    }
                    Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * index, y0);
                    Console.Write($"{{0,{-MAX_DIGITS - SPACING_DIGITS}:D}}", unOrderedList[index]);
                }
                Console.ResetColor();
            }

            // Draw Arrows
            Console.BackgroundColor = defaultBackColor;
            Console.ForegroundColor = defualtArrowForeColor;
            Console.SetCursorPosition(x0, yStart + 3);
            Console.WriteLine(new string(' ', Console.WindowWidth));//clear screen line 2
            Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * indexStart, yStart + 2 + 1);
            if ((indexEnd - indexStart) > 0)
                Console.Write("└" + new String('─', (MAX_DIGITS + SPACING_DIGITS) * (indexEnd - indexStart) - 1) + "┘");
            Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * (endFlag + 1) - 1, yStart + 2 + 1);
            Console.Write("║");

            //Second Pass - Draw pre sorted - colorizes based on largness
            if (delayFlag)
                System.Threading.Thread.Sleep(delayMiliSeconds);

            if (animFlag)//swap happened
            {

                for (int index = 0; index < unOrderedList.Count; index++)
                {
                    Console.ResetColor();
                    if (index == indexStart)
                    {
                        Console.BackgroundColor = lowBackColor;
                        Console.ForegroundColor = compareForeColor;
                        Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * (index + (animFlag ? 1 : -1) * (indexEnd - indexStart)), y0);
                    }
                    else if (index == indexEnd)
                    {
                        Console.BackgroundColor = highBackColor;
                        Console.ForegroundColor = compareForeColor;
                        Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * (index - (animFlag ? 1 : -1) * (indexEnd - indexStart)), y0);
                    }
                    else
                    {
                        Console.BackgroundColor = defaultBackColor;
                        Console.ForegroundColor = defaultForeColor;
                        Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * index, y0);
                    }

                    Console.Write($"{{0,{-MAX_DIGITS - SPACING_DIGITS}:D}}", unOrderedList[index]);
                }
                Console.ResetColor();
            }
            else//swap not happened
            {
                Console.SetCursorPosition(xStart + PADDINGS, yStart + 2);
                for (int index = 0; index < unOrderedList.Count; index++)
                {
                    Console.ResetColor();
                    if (index == indexStart)
                    {
                        Console.BackgroundColor = lowBackColor;
                        Console.ForegroundColor = compareForeColor;
                    }
                    else if (index == indexEnd)
                    {
                        Console.BackgroundColor = highBackColor;
                        Console.ForegroundColor = compareForeColor;
                    }
                    else
                    {
                        Console.BackgroundColor = defaultBackColor;
                        Console.ForegroundColor = defaultForeColor;
                    }
                    Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * index, y0);
                    Console.Write($"{{0,{-MAX_DIGITS - SPACING_DIGITS}:D}}", unOrderedList[index]);
                }
                Console.ResetColor();
            }


            //Third Pass - Draw post sorted - Colorizes based on largness
            if (delayFlag)
                System.Threading.Thread.Sleep(delayMiliSeconds);

            Console.SetCursorPosition(xStart + PADDINGS, yStart + 2);
            Console.ResetColor();

            for (int index = 0; index < unOrderedList.Count; index++)
            {
                Console.ResetColor();
                if (index == indexStart)
                {
                    Console.BackgroundColor = lowBackColor;
                    Console.ForegroundColor = compareForeColor;
                }
                else if (index == indexEnd)
                {
                    Console.BackgroundColor = highBackColor;
                    Console.ForegroundColor = compareForeColor;
                }
                else
                {

                    Console.BackgroundColor = defaultBackColor;
                    Console.ForegroundColor = defaultForeColor;
                }

                Console.SetCursorPosition(x0 + (MAX_DIGITS + SPACING_DIGITS) * index, y0);
                Console.Write($"{{0,{-MAX_DIGITS - SPACING_DIGITS}:D}}", unOrderedList[index]);
            }
            Console.ResetColor();


        }
    }

}