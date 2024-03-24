// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("kUW6+L5xS4FD4ZMjGH+pRK93OHoc1eH8umGN2rlmgxz6X/vShb+Y43uvUkDPh38oqbqTP9KdBNC0K4nrIYbnbWQ2pIGGbHhcNb0YYFLR6ZZO/H9cTnN4d1T4NviJc39/f3t+fRVKwMcd2HkU13ILeweCKS9rfd9cKf+IC3sLC4YNqhzDftKiibVP9DG0hrJAqsUl+ttAk7dn/eOpWrqlTNUo3X+sT09wuAksLE7+j2L1u4XgFaGxg1CWWV6PL6mPAfLKUJSbzty9SLCQ7Q2WkwVcpV0KX92v6d3tl4IK9Brk/3VDioImPmXcul4QZPWFG8HsCh7clb6WYO6v5weq3MjtZUL8f3F+Tvx/dHz8f39+5AwT5ZcQWCDYVDJQ/ov/PXx9f35/");
        private static int[] order = new int[] { 2,8,4,3,4,12,11,9,13,10,11,11,12,13,14 };
        private static int key = 126;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
