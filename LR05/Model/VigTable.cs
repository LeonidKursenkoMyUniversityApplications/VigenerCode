using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenerCode.Model
{
    public class VigTable
    {
        public char[][] Get { get; private set; }
        private List<char> _alphabet;

        public VigTable(List<char> alphabet)
        {
            Get = new char[alphabet.Count][];
            for (int i = 0; i < alphabet.Count; i++)
            {
                int k = i;
                Get[i] = new char[alphabet.Count];
                for (int j = 0; j < alphabet.Count; j++)
                {
                    k = k % alphabet.Count;
                    Get[i][j] = alphabet[k];
                    k++;
                }
            }
            _alphabet = alphabet.ToList();
        }

        public char EncryptChar(char sourceChar, char keyChar)
        {
            int sourceCharIndex = FindIndex(sourceChar);
            int keyCharIndex = FindIndex(keyChar);
            return Get[sourceCharIndex][keyCharIndex];
        }

        public char DecryptChar(char encryptChar, char keyChar)
        {
            int keyCharIndex = FindIndex(keyChar);
            for (int i = 0; i < Get.Length; i++)
            {
                if (Get[i][keyCharIndex] == encryptChar)
                    return _alphabet[i];
            }
            throw new Exception($"Символ '{keyChar}' відсутній в алфавіті");
        }

        private int FindIndex(char c)
        {
            int index = _alphabet.IndexOf(c);
            if (index == -1) throw new Exception($"Символ '{c}' відсутній в алфавіті");
            return index;
        }
    }
}
