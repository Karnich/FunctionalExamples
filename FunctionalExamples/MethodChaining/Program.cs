using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodChaining
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendFormattedLine(
            this StringBuilder @this,
            string format,
            params object[] args) =>
            @this.AppendFormat(format, args).AppendLine();

        public static StringBuilder AppendLineWhen(
            this StringBuilder @this,
            Func<bool> predicate,
            Func<StringBuilder, StringBuilder> fn) =>
                predicate()
                    ? fn(@this)
                    : @this;

        public static StringBuilder AppendSequence<T>(
            this StringBuilder @this,
            IEnumerable<T> seq,
            Func<StringBuilder, T, StringBuilder> fn) =>
                seq.Aggregate(@this, fn);
    }
    class Program
    {
        private static string BuildSelectBox(IDictionary<int, string> options, string id, bool includeUnknown) =>
            new StringBuilder()
                .AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)
                .AppendLineWhen(
                    () => includeUnknown,
                    sb => sb.AppendLine("\t<option>Unknown</option>"))
                .AppendSequence(
                    options,
                    (sb, opt) =>
                        sb.AppendFormattedLine("\t<option value\"{0}\">{0}</option>", opt.Key, opt.Value))
                .AppendLine("</select>")
                .ToString();
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
