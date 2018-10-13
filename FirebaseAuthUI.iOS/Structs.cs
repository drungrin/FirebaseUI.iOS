using System;
using ObjCRuntime;

namespace Firebase.Auth.UI
{
    [Native]
    public enum AccountSettingsOperationType : long
    {
        Unsupported = 0,
        UpdateName,
        UpdatePassword,
        ForgotPassword,
        UpdateEmail,
        UnlinkAccount,
        SignOut,
        DeleteAccount
    }

    [Native]
    public enum AuthUIErrorCode : ulong
    {
        UserCancelledSignIn = 1,
        ProviderError = 2,
        CantFindProvider = 3,
        MergeConflict = 4
    }

}

