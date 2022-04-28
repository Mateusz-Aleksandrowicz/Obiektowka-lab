using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Copier : BaseDevice
    {
        public new int Counter { get; private set; }
        public int PrintCounter { get => printer.Counter; }
        public int ScanCounter { get => scanner.Counter; }

        public Scanner scanner = new Scanner();
        public Printer printer = new Printer();


        public void PowerOff(IDevice device)
        {
            device.PowerOff();
        }
        public new void PowerOff()
        {
            PowerOff(printer);
            PowerOff(scanner);
        }

        public void PowerOn(IDevice device)
        {

            if (device.GetState() == IDevice.State.off) Counter++;
            device.PowerOn();
        }
        public new void PowerOn()
        {
            if (GetState(scanner) == IDevice.State.off) Counter++;
            if (GetState(printer) == IDevice.State.off) Counter++;
            PowerOn(scanner);
            PowerOn(printer);
        }

        public IDevice.State GetState(IDevice device)
        {
            return device.GetState();
        }
        public new IDevice.State GetState()
        {
            if (GetState(printer) == IDevice.State.on && GetState(scanner) == IDevice.State.on)
            {
                return IDevice.State.on;
            }
            else
            {
                return IDevice.State.off;
            }
        }


        public void Print(in IDocument document)
        {
            printer.Print(in document);
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            scanner.Scan(out document, formatType);
        }

        public void ScanAndPrint()
        {
            IDocument document;
            Scan(out document);
            Print(in document);
        }
    }
}
