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
        private static void Awake(this ET.Server.AccountDB self, string account, string pawssword)
        {
            self.Account = account;
            self.Password = pawssword;
        }
        
        /// <summary>
        /// 检查密码是否正确
        /// </summary>
        /// <param name="self"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckPassword(this AccountDB self, string password)
        {
            self.ActiveAt = TimeInfo.Instance.ServerNow();
            return self.Password == password;
        }
    }
}

