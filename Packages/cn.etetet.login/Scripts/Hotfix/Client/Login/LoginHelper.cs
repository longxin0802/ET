namespace ET.Client
{
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene root, string address, string account, string password)
        {
            root.RemoveComponent<ClientSenderComponent>();
            ClientSenderComponent clientSenderComponent = root.AddComponent<ClientSenderComponent>();
            var result = await clientSenderComponent.LoginAsync(address, account, password);
            if (result.Code == ErrorCode.ERR_Success)
            {
                root.GetComponent<PlayerComponent>().MyId = result.PlayerId;
                await EventSystem.Instance.PublishAsync(root, new LoginFinish());
            }
            return result.Code;
        }
    }
}