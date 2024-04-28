using AgoraIO.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using Ionic.Zlib;

namespace SoowGoodWeb.Utilities
{
    public class Utility
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int GetRandomNo(int min, int max)
        {
            Random rdm = new Random();
            return rdm.Next(min, max);
        }
        public static string GetDisplayName(Enum enumValue)
        {
            var temp = enumValue.GetType().GetMember(enumValue.ToString())
                           .First();
            if (temp.GetCustomAttribute<DisplayAttribute>() != null)
                return temp.GetCustomAttribute<DisplayAttribute>().Name;
            else
                return temp.Name;
        }

        public static int getTimestamp()
        {
            return (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }

        public static int randomInt()
        {
            return new Random().Next();
        }

        public static byte[] pack(PrivilegeMessage packableEx)
        {
            ByteBuf buffer = new ByteBuf();
            packableEx.marshal(buffer);
            return buffer.asBytes();
        }
        public static byte[] pack(IPackable packableEx)
        {
            ByteBuf buffer = new ByteBuf();
            packableEx.marshal(buffer);
            return buffer.asBytes();
        }

        public static string base64Encode(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        public static byte[] base64Decode(string data)
        {
            return Convert.FromBase64String(data);
        }

        public static bool isUUID(string uuid)
        {
            if (uuid.Length != 32)
            {
                return false;
            }

            Regex regex = new Regex("^[0-9a-fA-F]{32}$");
            return regex.IsMatch(uuid);
        }

        //public static byte[] compress(byte[] data)
        //{
        //    byte[] output;
        //    using (MemoryStream outputStream = new MemoryStream())
        //    {
        //        using (var zlibStream = new ZlibStream(outputStream, CompressionMode.Compress, CompressionLevel.Level5, true)) // or use Level6
        //        {
        //            zlibStream.Write(data, 0, data.Length);
        //        }
        //        output = outputStream.ToArray();
        //    }

        //    return output;
        //}

        //public static byte[] decompress(byte[] data)
        //{
        //    byte[] output;
        //    using (MemoryStream outputStream = new MemoryStream())
        //    {
        //        using (var zlibStream = new ZlibStream(outputStream, CompressionMode.Decompress))
        //        {
        //            zlibStream.Write(data, 0, data.Length);
        //        }
        //        output = outputStream.ToArray();
        //    }

        //    return output;
        //}
    }


}
