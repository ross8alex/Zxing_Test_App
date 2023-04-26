using System;
using System.Collections.Generic;
using System.Text;

namespace ZXing_Test_App.Common
{
    public class ScanbotSDKConfiguration
    {
#if DEBUG
        public const bool IS_DEBUG = true;
#else
        public const bool IS_DEBUG = false;
#endif

        public const string LICENSE_KEY = "YlJVSI+R5gIAECRRjvO/VnvmHxI5TC" +
                                          "JfJRqQC9WzzyFw2M7LOCHVpVcwGPch" +
                                          "TPwKEvEIQ8sUWtEqWppQJGqH9oGnLX" +
                                          "zG6WwDZGeIIxiznyQUYlE/Z7BfouVa" +
                                          "bh5Pks7zGLjLb5XhiPnzwr4IsSJZIe" +
                                          "1cJI/fSmsMwtyZ437w53svY50EujJL" +
                                          "lJn7dchPCMlC2uwEsEongK8KbNUpDj" +
                                          "tgNCIrdSNTlyN3rNwjGeubUhHfwpRL" +
                                          "GyJ+xRDzJaMh2tLCA9x+FE9OSKVinY" +
                                          "Mra1WQKWyFDfo0hPo+ZIRdoUCcj8I/" +
                                          "aHzrioZGGMOa6YmG+vCHwVEhSoEd4p" +
                                          "tZZCGWc4XDzg==\nU2NhbmJvdFNESw" +
                                          "pjb20ucmVsaWFibGVleHByZXNzdHJh" +
                                          "bnNwb3J0Lnp4aW5nX3Rlc3RfYXBwCj" +
                                          "E2ODExNzExOTkKODM4ODYwNwoxOQ==\n";
    }
}
