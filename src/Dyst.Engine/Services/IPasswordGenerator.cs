using System;

namespace Dyst.Engine.Services
{
    public interface IPasswordGenerator
    {
        string Generate(int length);
    }

    public class PasswordGenerator : IPasswordGenerator
    {
        const string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";

        public string Generate(int length)
        {
            
            char[] chars = new char[length];
            Random rd = new Random();

            for (int i = 0; i < length; i++)
            {
                chars[i] = _allowedChars[rd.Next(0, _allowedChars.Length)];
            }

            return new string(chars);

        }
    }
}
