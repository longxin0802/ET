// // File:AccpuntDBSystem.cs
// // Author:OUDELIU
// // Mail:375550070@qq.com
// // At:2025-03-15 14:03

namespace ET.Server
{
    [EntitySystemOf(typeof(AccountDB))]
    public static partial class AccountDBSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.AccountDB self, string account)
        {
            self.Account = account;
            self.Password = "sdfsdf3@#d";
        }
    }
}

