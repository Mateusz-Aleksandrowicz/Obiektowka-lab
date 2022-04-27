using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie2
{
    public class MultifunctionalDevice : IFax
    {
        public int Counter { get; set; }
        public int ScanCounter { get; set; }
        public int PrintCounter { get; set; }

        public int FaxCounter { get; set; }

        public List<string> faxes = new List<string>();


        protected IDevice.State state = IDevice.State.off;

        public IDevice.State GetState()
        {
            return state;
        }

        public void PowerOff()
        {
            if (state == IDevice.State.off) return;
            state = IDevice.State.off;
            Console.WriteLine("...Device is off!");
        }

        public void PowerOn()
        {
            if (state == IDevice.State.on) return;
            Counter++;
            state = IDevice.State.on;
            Console.WriteLine("Device is on...!");
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
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

        public void Print(in IDocument document)
        {
            if (state != IDevice.State.off) return;
            PrintCounter++;
            Console.WriteLine(DateTime.Now.ToString() + " Print: " + document.GetFileName());
        }

        public void ScanAndPrint()
        {

            ScanCounter++;
            PrintCounter++;
            Scan(out IDocument document, IDocument.FormatType.JPG);
            Print(in document);
        }

        public void Scan(out IDocument document)
        {
            document = new PDFDocument(filename: null);
            if (state != IDevice.State.off) return;
            ScanCounter++;
            document = new PDFDocument(filename: "Scan" + ScanCounter);
            Console.WriteLine(DateTime.Now + "Scan: " + document.GetFileName());
        }
        public void SendingFax(in IDocument document, string number)
        {
            if (state == IDevice.State.off) return;

            int.Parse(number);

            Console.WriteLine(DateTime.Now + " Fax: " + document.GetFileName() + " To : " + number);
            FaxCounter++;
        }

        public void ReceiveFax(in IDocument document)
        {
            foreach (string fax in faxes)
            {
                Console.WriteLine(fax);
            }
        }
    }
}