using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR05.Model;

namespace LR05.Controller
{
    public class VigController
    {
        private List<char> _key;
        private VigTable _vigTable;
        private List<char> _alphabet;

        public VigController(List<char> alphabet)
        {
            _alphabet = alphabet;
            _vigTable = new VigTable(_alphabet);
        }

        public string Encrypt(string sourceMessage, string key)
        {
            CheckString(sourceMessage);
            CheckString(key);
            _key = key.ToList();
            var encryptMessage = new List<char>();
            encryptMessage = sourceMessage.ToList().Select((sourceChar, index) =>
            {
                int keyIndex = index % key.Length;
                char keyChar = _key[keyIndex];
                var encryptChar = _vigTable.EncryptChar(sourceChar, keyChar);
                return encryptChar;
            }).ToList();

            return string.Join("", encryptMessage.ToArray());
        }

        public string Decrypt(string encryptMessage, string key)
        {
            CheckString(encryptMessage);
            CheckString(key);
            _key = key.ToList();
            var decryptMessage = new List<char>();
            decryptMessage = encryptMessage.ToList().Select((encryptChar, index) =>
            {
                int keyIndex = index % key.Length;
                char keyChar = _key[keyIndex];
                var decryptChar = _vigTable.DecryptChar(encryptChar, keyChar);
                return decryptChar;
            }).ToList();

            return string.Join("", decryptMessage.ToArray());
        }

        private void CheckString(string str)
        {
            if(string.IsNullOrEmpty(str) == true) throw new Exception("Пуста строка");
        }
    }
}
