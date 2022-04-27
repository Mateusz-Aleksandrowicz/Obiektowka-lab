using System;
using ver1;

namespace Zadanie2
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public new int Counter { get; set; }


        public new void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
            }
            Console.WriteLine("...Device is off!");
        }

        public new void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
                Counter++;
            }
            Console.WriteLine("...Device is On!");
        }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off) return;

            var getDate = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            var getName = document.GetFileName();
            PrintCounter++;

            Console.WriteLine($"{getDate} Print: {getName}");
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            if (state == IDevice.State.off)
            {
                document = null;
                return;
            }
            document = new PDFDocument(filename: null);
            ScanCounter++;

            if (formatType == IDocument.FormatType.TXT)
            {
                document = new PDFDocument(filename: "TXTScan" + ScanCounter + ".txt");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
            else if (formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument(filename: "PDFScan" + ScanCounter + ".pdf");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new PDFDocument(filename: "JPGScan" + ScanCounter + ".jpg");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }   
        }

        public void Scan(out IDocument document)
        { 
            document = new PDFDocument(filename: null);

            if (state != IDevice.State.off)
            {
                return;
            }

            ScanCounter++;
            document = new PDFDocument(filename: "Scan" + ScanCounter);
            Console.WriteLine(DateTime.Now + "Scan: " + document.GetFileName());
        }

        public void ScanAndPrint()
        {
            ScanCounter++;
            PrintCounter++;
            if (state == IDevice.State.off) return;
            Scan(out IDocument document, IDocument.FormatType.JPG);
            Print(in document);
        }

    }
}