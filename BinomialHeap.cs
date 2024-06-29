using System.Security;

namespace GenericBinomialHeap; 
public class BinomialHeap<T> where T: IComparable, new() {
    private NodeBinomial<T>? Head;
    public NodeBinomial<T>? Min { get; private set; }
    public int Size { get; set; }

    public BinomialHeap() {
        Size = 0;
        Head = Min = null;
    }

    public BinomialHeap(T data) {
        Size = 1;
        Head = Min = new(data);
    }

    public void Insert(T value) {
        if(Head == null) {
            Min = Head = new(value);
            ++Size;
            return;
        }

        BinomialHeap<T> helper = new(value);

       HeapUnion(ref helper);
    }

   public void HeapUnion(ref BinomialHeap<T> heap2) {
        HeapMerge(ref heap2);
   }
   
    public void HeapMerge(ref BinomialHeap<T> heap2) {
        NodeBinomial<T>? h1Iter = Head, h2Iter = heap2.Head, finalRootList = null, current = null;

        while(h1Iter != null && h2Iter != null) {
            //if not initialized pick the smaller one to start the list
            if(current == null) {
               if(!Greater(h1Iter.Data, h2Iter.Data)) {
                    current = h1Iter;
                    h1Iter= h1Iter.Sibling;
                }
                else {
                    current = h2Iter;
                    h2Iter = h2Iter.Sibling;
                }
                finalRootList = current;
            }

            else if (!Greater(h1Iter.Data, h2Iter.Data)) {
                current!.Sibling = h1Iter;
                current = current.Sibling;
                h1Iter = h1Iter.Sibling;
            }
            else {
                h2Iter.Parent = null;
                current!.Sibling = h2Iter;
                current = current.Sibling;
                h2Iter = h2Iter.Sibling;

            } 
        }

        if(h1Iter != null)
            current!.Sibling = h1Iter;
        if(h2Iter != null && h2Iter.Parent == null)
            current!.Sibling = h2Iter;

        if(h2Iter != null && h2Iter.Parent != null) {
            while(h2Iter != null) {
                h2Iter.Parent = null;
                current!.Sibling = h2Iter;
                current = current.Sibling;
                h2Iter = h2Iter.Sibling;
            }
        }

        Size += heap2.Size;
        Min = Greater(Min!.Data, heap2.Min!.Data) 
            ? heap2.Min
            : Min;
        Head = finalRootList;
        heap2.Head = heap2.Min = current = null;
        heap2.Size = 0;
    }

    private bool Greater(T value1, T value2) {
        return value1.CompareTo(value2) == 1 ? true : false; 
    }

    public void PrintRootList() {
        NodeBinomial<T>? tmp = Head;

        while(tmp != null) {
            Console.Write($"{tmp.Data} ");
            tmp = tmp.Sibling;
        }

        Console.WriteLine();
    }
}
