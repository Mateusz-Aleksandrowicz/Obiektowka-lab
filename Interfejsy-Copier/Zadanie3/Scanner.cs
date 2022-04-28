using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Scanner : IScanner
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
            Counter++;
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            if (state == IDevice.State.off)
            {
                document = null;
                return;
            }
            document = new PDFDocument(filename: null);
            Counter++;

            if (formatType == IDocument.FormatType.TXT)
            {
                document = new PDFDocument(filename: "TXTScan" + Counter + ".txt");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
            else if (formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument(filename: "PDFScan" + Counter + ".pdf");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new PDFDocument(filename: "JPGScan" + Counter + ".jpg");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
        }
    }
}