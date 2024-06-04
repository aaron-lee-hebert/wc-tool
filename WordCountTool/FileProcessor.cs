using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCountTool {
    public class FileProcessor {
        public static long GetByteCount(string filePath) => new FileInfo(filePath).Length;
    }
}
