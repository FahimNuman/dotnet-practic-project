using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Common.Encryption
{
    /// <summary>
    /// Class SimpleCryptService crypt factory
    /// </summary>
    public class SimpleCryptService : SimpleCryptServiceBase
    {
        protected override string EncryptionKey => "FahimNuman";

        public static SimpleCryptService Factory()
        {
            return new SimpleCryptService();
        }
    }
}
