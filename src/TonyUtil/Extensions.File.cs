using System.IO;

namespace TonyUtil
{
    /// <summary>
    /// 系统扩展 - 文件或流相关扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 将字节流写入文件
        /// </summary>
        /// <param name="stream">字节流</param>
        /// <param name="filePath">文件绝对路径</param>
        public static void ToFile(this byte[] stream, string filePath)
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
            File.WriteAllBytes(filePath,stream);
        }
    }
}
