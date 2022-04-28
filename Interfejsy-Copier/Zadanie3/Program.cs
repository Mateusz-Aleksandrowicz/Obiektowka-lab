using System;
using ver1;

namespace Zadanie3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xerox = new Copier();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2 = new ImageDocument("bbb.JPG");
            xerox.Scan(out doc2, IDocument.FormatType.JPG);

            xerox.ScanAndPrint();
            Console.WriteLine("Xeros");
            Console.WriteLine("Counter:" + xerox.Counter);
            Console.WriteLine("PrintCounter:" + xerox.PrintCounter);
            Console.WriteLine("ScanCounter:" + xerox.ScanCounter);


            var multifunctionalDevice = new MultifunctionalDevice();
            multifunctionalDevice.PowerOn();
            IDocument doc3 = new PDFDocument("test1.pdf");
            multifunctionalDevice.Print(in doc3);

            IDocument doc4 = new ImageDocument("test2.JPG");
            multifunctionalDevice.Scan(out doc4, IDocument.FormatType.JPG);

            Console.WriteLine("Multifunctional Device");
            Console.WriteLine("Counter:" + multifunctionalDevice.Counter);
            Console.WriteLine("PrintCounter:" + multifunctionalDevice.PrintCounter);
            Console.WriteLine("ScanCounter:" + multifunctionalDevice.ScanCounter);
        }
    }
}