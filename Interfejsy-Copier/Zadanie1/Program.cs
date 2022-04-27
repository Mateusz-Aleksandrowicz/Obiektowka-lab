using ver1;
using Zadanie1;

class Program
{
    static void Main()
    {
        var copier = new Copier();
        copier.PowerOn();

        IDocument doc1;
        copier.Scan(out doc1);
        IDocument doc2;
        copier.Scan(out doc2);

        IDocument doc3 = new ImageDocument("aaa.jpg");
        copier.Print(in doc3);

        copier.PowerOff();
        copier.Print(in doc3);
        copier.Scan(out doc1);
        copier.PowerOn();

        copier.ScanAndPrint();
        copier.ScanAndPrint();
        System.Console.WriteLine(copier.Counter);
        System.Console.WriteLine(copier.PrintCounter);
        System.Console.WriteLine(copier.ScanCounter);
    }
}