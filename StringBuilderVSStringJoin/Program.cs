using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Linq;
using System.Text;

namespace StringBuilderVSStringJoin
{
    public class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<StringBuilderExamples>();
        }
    }

    public class Container
    {
        public string Name { get; set; }
        public Container(string name)
        {
            this.Name = name;
        }
    }

    [MemoryDiagnoser]
    public class StringBuilderExamples
    {
        Container[] elements = new Container[] {
            new Container("a"),
            new Container("b"),
            new Container("c"),
            new Container("d"),
            new Container("e"),
            new Container("f"),
            new Container("g"),
            new Container("h"),
            new Container("i"),
            new Container("j"),
            new Container("k"),
            new Container("l"),
            new Container("m"),
            new Container("n"),
            new Container("o"),
            new Container("p"),
            new Container("q"),
            new Container("r"),
            new Container("s"),
            new Container("t"),
            new Container("u"),
            new Container("v"),
            new Container("w"),
            new Container("x"),
            new Container("y"),
            new Container("z") };

        [Benchmark]
        public string JoinStringTest()
        {
            return string.Join(" e ", elements.Select(e => e.Name));
        }

        [Benchmark]
        public string StringBuilderTest()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in elements)
            {
                sb.Append(element.Name);
                sb.Append(" e ");
            }
            if (sb.Length > 3)
                sb.Remove(sb.Length - 3, 3);
            return sb.ToString();
        }
    }
}
