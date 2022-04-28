
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class MultifunctionalDevice : BaseDevice, IFax
    {
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public int FaxCounter { get; set; }

        public Printer Printer { get; set; }
        public Scanner Scanner { get; set; }

        public MultifunctionalDevice()
        {
            Printer = new Printer();
            Scanner = new Scanner();
        }

        public new void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;

            }
        }

        public new void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
            }

        }


        public void Print(in IDocument document)
        {
            if (state != IDevice.State.off) return;
            PrintCounter++;
            Console.WriteLine(DateTime.Now.ToString() + " Print: " + document.GetFileName());
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = new PDFDocument(filename: null);
            if (state == IDevice.State.off) return;
            ScanCounter++;
            if (formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument(filename: "PDFScan" + ScanCounter + ".pdf");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new PDFDocument(filename: "JPGScan" + ScanCounter + ".jpg");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
            else if (formatType == IDocument.FormatType.TXT)
            {
                document = new PDFDocument(filename: "TXTScan" + ScanCounter + ".txt");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
        }


        public void SendingFax(out IDocument document)
        {
            if (state == IDevice.State.off) { document = null; return; }

            Scan(out document);

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

            FaxCounter++;
            Console.WriteLine($"{date} Fax sent: {document.GetFileName()}");
        }

        public void ReceiveFax(in IDocument document)
        {
            if (state == IDevice.State.off) return;

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

            FaxCounter++;
            Print(in document);
            Console.WriteLine($"{date} Fax received: {document.GetFileName()}");
        }
    }
}