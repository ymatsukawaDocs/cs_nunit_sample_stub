using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAppForUnitTest.Model;

namespace SampleAppForUnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ILight light = new Light(true);
            IRoom room = new Room(light);
            Console.WriteLine(room.IsBrightRoom());
        }
    }
}
