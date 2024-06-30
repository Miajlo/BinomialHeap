using GenericBinomialHeap.Models;

namespace GenericBinomialHeap;

public class Program {
    public static void Main(string[] args) {

        BinomialHeap<int> heap = new();

        heap.Insert(1);
        heap.Insert(2);
        heap.Insert(3);
        heap.Insert(4);
        heap.Insert(5);
        heap.Insert(6);
        heap.Insert(7);
        heap.Insert(8);
        heap.PrintRootList();

        Console.WriteLine($"Min: {heap!.Min!.Data}");
        Console.WriteLine($"Size: {heap.Size}");
    }
}



