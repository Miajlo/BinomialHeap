namespace GenericBinomialHeap;

public class Program {
    public static void Main(string[] args) {

        BinomialHeap<int> heap = new();

        heap.insert(1);
        heap.insert(2);
        heap.insert(3);
        heap.insert(4);
        heap.insert(5);
        heap.insert(6);
        heap.insert(7);
        heap.insert(8);
        heap.PrintRootList();

        Console.WriteLine($"Min: {heap!.Min!.Data}");
        Console.WriteLine($"Size: {heap.Size}");
    }
}



