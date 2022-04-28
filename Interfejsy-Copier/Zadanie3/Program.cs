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

            var multifunctionalDevice = new MultifunctionalDevice();
            multifunctionalDevice.PowerOn();
            IDocument doc3 = new PDFDocument("test1.pdf");
            multifunctionalDevice.Print(in doc3);

            IDocument doc4 = new ImageDocument("test2.JPG");
            multifunctionalDevice.Scan(out doc4, IDocument.FormatType.JPG);

            multifunctionalDevice.SendingFax(out doc4);

            IDocument doc5 = new ImageDocument("sentFile.jpg");
            multifunctionalDevice.ReceiveFax(doc5);

            Console.WriteLine("Multifunctional Device");
            Console.WriteLine("Counter:" + multifunctionalDevice.Counter);
            Console.WriteLine("PrintCounter:" + multifunctionalDevice.PrintCounter);
            Console.WriteLine("ScanCounter:" + multifunctionalDevice.ScanCounter);
            Console.WriteLine("SendCounter:" + multifunctionalDevice.FaxCounter);
            Console.WriteLine("ReceiveCounter:" + multifunctionalDevice.FaxCounter);
        }
    }
}