using table;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table(8, 8);

            Console.WriteLine(table.ToString());

            Console.ReadLine();

        }
    }
}
