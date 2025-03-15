namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_ConnectGateKeyError = ERR_WithException + PackageType.Login * 1000 + 1;
        public const int ERR_PasswordError = ERR_WithException + PackageType.Login * 1000 + 2; // 密码错误
    }
}