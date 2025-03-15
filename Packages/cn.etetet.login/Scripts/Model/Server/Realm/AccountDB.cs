// // File:AccountDB.cs
// // Author:OUDELIU
// // Mail:375550070@qq.com
// // At:2025-03-15 13:03

namespace ET.Server
{
    [ChildOf(typeof(LoginComponent))]
    public class AccountDB: Entity, IAwake<string, string>
    {
        public string Account;
        public string Password;

        public long ActiveAt;
    }
}

