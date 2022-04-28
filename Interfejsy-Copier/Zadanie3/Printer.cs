
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        public int Counter { get; set; }
        public IDevice.State state = IDevice.State.off;

        public IDevice.State GetState()
        {
            return state;
        }


        public void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
            }
        }

        public void PowerOn()
        {

            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
            }
        }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off) return;

            var getDate = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            var getName = document.GetFileName();

            Counter++;
            Console.WriteLine($"{getDate} Print: {getName}");
        }
    }
}