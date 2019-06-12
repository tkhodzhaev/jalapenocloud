namespace JalapenoCloud.Dal.Domain.Enums
{
    public enum DbSettingKey
    {
        Unknown = 0,

        Credits,

        UserComplaintsDailyLimit,

        SenderIdTotalComplaintsLimit,

        SmsHashTotalComplaintsLimit,

        TrialDaysLimit,

        TokenValidationUriTemplate,

        Azp,

        Audience,

        PrivateKey,

        PublicKey,

        KeySize,

        RequestEncodingEnabled,

        TestMode,

        AllRequestsLoggingMode,

        LogFolder
    }
}