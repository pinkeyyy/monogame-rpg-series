using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEngine
{
    public class Bootstrap
    {
        private string contentPath;

        public Bootstrap(string contentPath)
        {
            this.contentPath = contentPath;
            SanitizeContentPath();
        }

        private void SanitizeContentPath()
        {
            if (contentPath.LastIndexOf(@"\") != contentPath.Length - 1)
                contentPath += @"\";
        }
    }
}
