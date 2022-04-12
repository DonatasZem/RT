using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RT
{
    public class Application
    {
        private readonly IFunctions _functions;
        public Application(IFunctions functions)
        {
            _functions = functions;
        }

        public void Run()
        {
            Console.WriteLine("1.Clock task 2.Ext");
            do
            {
                var option = Console.ReadLine();
                var closeProgram = false;

                switch (option)
                {
                    case "1":
                        Console.WriteLine(_functions.Clock());
                        break;

                    case "2":
                        closeProgram = true;
                        break;

                    default:
                        Console.WriteLine("Option is not correct");
                        break;
                }

                if (closeProgram == true) break;

            } while (true);


        }
    }
}
