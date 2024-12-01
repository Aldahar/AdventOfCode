using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    public class TenthDayOfChristmas
    {
        List<string> Lines = new();
        public TenthDayOfChristmas(List<string> lines)
        {
            Lines = lines;
        }
        public double FindEndpoint()
        {
            LoopElement startElement = new();
            var startLine = Lines.First(row => row.Contains("S"));
            startElement.Y = Lines.IndexOf(startLine);
            startElement.X = startLine.IndexOf('S');
            startElement.Current = 'S';
            startElement.PreviousElement = new();

            var koop = FindLoop(startElement);

            var count = 0;
            var nextIteration = koop;
            while(nextIteration.NextElement.Current != 'S')
            {
                count++;
                nextIteration = nextIteration.NextElement;

            }

            var a = Math.Ceiling(0d+ count / 2.0);
            return Math.Ceiling(0d+count/2.0);

        }


        

        private  LoopElement FindLoop(LoopElement element)
        {
            if (!element.checkNextElement(element.PreviousElement) && element.Current != 'S' && element.PreviousElement.Current != 'S')
            {
                return new();
            }
            if(element.Current == 'S') //First Element check every direction
            {
                if (element.PreviousElement.PreviousElement == null)
                {
                    if (element.X > 0)
                    {
                        element.NextElement = FindLoop(new LoopElement(element.X - 1, element.Y, Lines[element.Y][element.X - 1], element));
                        if(element.LastInChain.Current == 'S')
                        {
                            return element;
                        }
                    }
                    if (element.X < Lines[0].Length)
                    {
                        element.NextElement = FindLoop(new LoopElement(element.X + 1, element.Y, Lines[element.Y][element.X + 1], element));
                        if (element.LastInChain.Current == 'S')
                        {
                            return element;
                        }
                    }
                    if (element.Y > 0)
                    {
                        element.NextElement = FindLoop(new LoopElement(element.X, element.Y - 1, Lines[element.Y - 1][element.X], element));
                        if (element.LastInChain.Current == 'S')
                        {
                            return element;
                        }
                    }
                    if (element.Y < Lines.Count())
                    {
                        element.NextElement = FindLoop(new LoopElement(element.X, element.Y + 1, Lines[element.Y + 1][element.X], element));
                        if (element.LastInChain.Current == 'S')
                        {
                            return element;
                        }
                    }
                }
                else
                {
                    return element;
                }

               
            }
            else
            {
                try
                {


                    switch (element.Current)
                    {
                        case '|':
                            if (element.PreviousElement.Y < element.Y)
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X, element.Y + 1, Lines[element.Y + 1][element.X], element));
                            }
                            else
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X, element.Y - 1, Lines[element.Y - 1][element.X], element));
                            }
                            break;



                        case '-':
                            if (element.PreviousElement.X < element.X)
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X + 1, element.Y, Lines[element.Y][element.X + 1], element));
                            }
                            else
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X - 1, element.Y, Lines[element.Y][element.X - 1], element));
                            }
                            break;

                        case 'L':
                            if (element.PreviousElement.X != element.X)
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X, element.Y - 1, Lines[element.Y - 1][element.X], element));
                            }
                            else
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X + 1, element.Y, Lines[element.Y][element.X + 1], element));
                            }
                            break;

                        case 'J':
                            if (element.PreviousElement.X != element.X)
                            {
                                var newX = element.X;
                                var newY = element.Y - 1;
                                var cha = Lines[element.Y - 1][element.X];

                                element.NextElement = FindLoop(new LoopElement(element.X, element.Y - 1, Lines[element.Y - 1][element.X], element));
                            }
                            else
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X - 1, element.Y, Lines[element.Y][element.X - 1], element));
                            }
                            break;
                        case '7':
                            if (element.PreviousElement.X != element.X)
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X, element.Y + 1, Lines[element.Y + 1][element.X], element));
                            }
                            else
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X - 1, element.Y, Lines[element.Y][element.X - 1], element));
                            }
                            break;
                        case 'F':
                            if (element.PreviousElement.X != element.X)
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X, element.Y + 1, Lines[element.Y + 1][element.X], element));
                            }
                            else
                            {
                                element.NextElement = FindLoop(new LoopElement(element.X + 1, element.Y, Lines[element.Y][element.X + 1], element));
                            }
                            break;
                        default:

                            break;


                    }
                }
                catch
                {
                    return new();
                }
            }


            return  element;
        }


        







    }
    public class LoopElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        public char Current {  get; set; }

        public LoopElement LastInChain { get {
                var last = this;
                while (last.NextElement.NextElement != null)
                {
                    last = last.NextElement;
                }
                return last;
            
            } set { } }

        public LoopElement PreviousElement { get; set; }
        public LoopElement NextElement { get; set; }

        public LoopElement() { }

        public LoopElement(int x, int y, char current, LoopElement prev)
        {
            X = x;
            Y = y;
            Current = current;
            PreviousElement = prev;
        }

        public bool checkNextElement(LoopElement prevElement)
        {
            if(prevElement.Current == 'S')
            {
                if(prevElement.X > this.X)
                {
                    switch (this.Current)
                    {
                        case '|':
                        case 'J':
                        case '7':
                            return false;
                        default: return true;
                    }
                }
                else if (prevElement.X < this.X)
                {
                    switch (this.Current)
                    {
                        case 'L':
                        case '|':
                        case 'F':
                            return false;
                        default: return true;
                    }
                }
                else if(prevElement.Y > this.Y)
                {
                    switch (this.Current)
                    {
                        case 'J':
                        case 'L':
                        case '-':
                            return false;
                        default: return true;
                    }
                }
                else if (prevElement.Y < this.Y)
                {
                    switch (this.Current)
                    {
                        case '7':
                        case 'F':
                        case '-':
                            return false;
                        default: return true;
                    }
                }
            }

            switch (Current) {
                case '|':
                    switch (prevElement.Current) {
                    case '-':
                            return false;
                        case '.':
                            return false;
                            default:
                            return true;      
                    }
                case '-':
                    switch (prevElement.Current)
                    {
                        case '|':
                            return false;
                        case '.':
                            return false;
                        default: return true;
                    }
                case 'L':
                    switch (prevElement.Current)
                    {
                        case 'L':
                            return false;
                        case '.':
                            return false;
                        default: return true;
                    }
                case 'J':
                    switch (prevElement.Current)
                    {
                        case 'J':
                            return false;
                        case '.':
                            return false;
                        default: return true;
                    }
                case '7':
                    switch (prevElement.Current)
                    {
                        case '7':
                            return false;
                        case '.':
                            return false;
                        default: return true;
                    }
                case 'F':
                    switch (prevElement.Current)
                    {
                        case 'F':
                            return false;
                        case '.':
                            return false;
                        default: return true;
                    }
                case '.':
                    return false;
                case 'S':
                    switch (prevElement.Current)
                    {
                        case '.':
                            return false;
                        default: return true;
                    }

                    default: return false;



            }

        }

    }

}
