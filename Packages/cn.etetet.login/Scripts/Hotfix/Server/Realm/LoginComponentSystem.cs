// // File:LoginComponentSystem.cs
// // Author:OUDELIU
// // Mail:375550070@qq.com
// // At:2025-03-15 14:03

namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.LoginComponent))]
    [FriendOfAttribute(typeof(ET.Server.AccountDB))]
    public static class LoginComponentSystem
    {
        public static async ETTask<AccountDB> GetAccount(this LoginComponent self, string account, string password)
        {
            var dbComponent = self.GetDBComponent();
            var accountDB = await dbComponent.QueryOne<AccountDB>(db => db.Account == account);
            if (accountDB == null)
            {
                accountDB = self.AddChild<AccountDB, string, string>(account, password);
                await dbComponent.Save(accountDB);
            }
            return accountDB;
        }

        private static DBComponent GetDBComponent(this LoginComponent self)
        {
            return self.Root().GetComponent<DBManagerComponent>().GetZoneDB(1000);
        }
    }
}