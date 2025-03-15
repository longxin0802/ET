using System;
using System.Net;


namespace ET.Server
{
	[MessageSessionHandler(SceneType.Realm)]
	public class C2R_LoginHandler : MessageSessionHandler<C2R_Login, R2C_Login>
	{
		protected override async ETTask Run(Session session, C2R_Login request, R2C_Login response)
		{
			// 账号密码校验
			var loginComponent = session.Fiber().Root.GetComponent<LoginComponent>();
			var accountDB = await loginComponent.GetAccount(request.Account, request.Password);
			if (accountDB.CheckPassword(request.Password))
			{
				// 校验通过后分配一个区服
				await Login(session, request, response);
			}
			else
			{
				response.Error = ErrorCode.ERR_PasswordError;
			}

			CloseSession(session).NoContext();
		}

		private async ETTask<R2C_Login> Login(Session session, C2R_Login request, R2C_Login response)
		{
			// 这里一般会有创角，选择区服，demo就不做这个操作了，直接放在3区
			const int UserZone = 3; 
			// 随机分配一个Gate
			StartSceneConfig config = RealmGateAddressHelper.GetGate(UserZone, request.Account);
			Log.Debug($"gate address: {config}");
			// 向gate请求一个key,客户端可以拿着这个key连接gate
			R2G_GetLoginKey r2GGetLoginKey = R2G_GetLoginKey.Create();
			r2GGetLoginKey.Account = request.Account;
			G2R_GetLoginKey g2RGetLoginKey = (G2R_GetLoginKey) await session.Fiber().Root.GetComponent<MessageSender>().Call(
				config.ActorId, r2GGetLoginKey);

			response.Address = config.InnerIPPort.ToString();
			response.Key = g2RGetLoginKey.Key;
			response.GateId = g2RGetLoginKey.GateId;
			return response;
		}

		private async ETTask CloseSession(Session session)
		{
			await session.Root().GetComponent<TimerComponent>().WaitAsync(1000);
			session.Dispose();
		}
	}
}
