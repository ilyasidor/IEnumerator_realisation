using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lol
{
    class Program
    {
        public static void Main(string[] args)
        {
            Symbols symbols = new Symbols();

            foreach (char item in symbols)
            {
                Console.WriteLine(item);
            }
        }

    }
    class Symbols
    {
        private char[] symbols = { 'a', 'b', 'c', 'd' };

        public IEnumerator GetEnumerator()
        {
            return new SymbolsEnumerator(symbols);
        }
    }
    class SymbolsEnumerator : IEnumerator
    {
        char[] symbols;
        int position = -1;
        public SymbolsEnumerator(char[] symbols)
        {
            this.symbols = symbols;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= symbols.Length)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return symbols[position];
                }
            }
        }
        public bool MoveNext()
        {
            if (position < symbols.Length - 1)
            {
                for (int i = 0; i < symbols.Length; i++)
                {
                    if ((char)symbols.GetValue(i) == 'a')
                    {
                        symbols.SetValue(null, i);
                    }
                }
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            position = -1;
        }
    }
}