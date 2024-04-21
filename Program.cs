using FileManagement.Model;

namespace FileManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DLList<char> fileList = new();
            int totalCharsCount = 0;
            char ch;
            string filePath = @"C:\tmp\tmp.txt";
            GenericNode<char>? node;
            int ord;

            try
            {
                using StreamReader reader = new(filePath);

                while ((ord = reader.Read()) != -1)
                {
                    ch = (char)ord;
                    if (Convert.ToInt32(ch) == 13 || Convert.ToInt32(ch) == 10)  // CR or LF
                    {
                        reader.Read();
                        continue;
                    }

                    node = fileList.GetPosition(ch);
                    if (node == null )
                    {
                        fileList.InsertLast(ch);
                    } else
                    {
                        fileList.IncreaseCount(node);
                    }
                    totalCharsCount++;
                }
                Console.WriteLine("Print sorted by value ascending");
                fileList.SortByValueAsc();
                fileList.Traverse(totalCharsCount);
                Console.WriteLine();
                Console.WriteLine("Print sorted by frequency descending");
                fileList.SortByCountDesc();
                fileList.Traverse(totalCharsCount);
            } catch (IOException e)
            {
                Console.Error.WriteLine(e.StackTrace);
            }
        }
    }
}
