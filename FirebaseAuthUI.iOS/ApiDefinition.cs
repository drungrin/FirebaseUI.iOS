using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using Firebase.Auth;

namespace Firebase.Auth.UI
{
// @interface FUIAuthBaseViewController : UIViewController
    [BaseType(typeof(UIViewController), Name="FUIAuthBaseViewController")]
    [DisableDefaultCtor]
    interface AuthUIBaseViewController
    {
        // @property (readonly, nonatomic, strong) Auth * _Nonnull auth;
        [Export("auth", ArgumentSemantic.Strong)]
        Auth Auth { get; }

        // @property (readonly, nonatomic, strong) FUIAuth * _Nonnull authUI;
        [Export("authUI", ArgumentSemantic.Strong)]
        AuthUI AuthUI { get; }

        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil authUI:(FUIAuth * _Nonnull)authUI __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:authUI:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil, AuthUI authUI);

        // -(instancetype _Nonnull)initWithAuthUI:(FUIAuth * _Nonnull)authUI;
        [Export("initWithAuthUI:")]
        IntPtr Constructor(AuthUI authUI);

        // -(void)onBack;
        [Export("onBack")]
        void OnBack();

        // -(void)cancelAuthorization;
        [Export("cancelAuthorization")]
        void CancelAuthorization();

        // +(void)showSignInAlertWithEmail:(NSString * _Nonnull)email provider:(id<FUIAuthProvider> _Nonnull)provider presentingViewController:(UIViewController * _Nonnull)presentingViewController signinHandler:(FUIAuthAlertActionHandler _Nonnull)signinHandler cancelHandler:(FUIAuthAlertActionHandler _Nonnull)cancelHandler;
        [Static]
        [Export("showSignInAlertWithEmail:provider:presentingViewController:signinHandler:cancelHandler:")]
        void ShowSignInAlertWithEmail(string email, AuthUIProvider provider, UIViewController presentingViewController, AuthUIAlertActionHandler signinHandler, AuthUIAlertActionHandler cancelHandler);

        // -(void)incrementActivity;
        [Export("incrementActivity")]
        void IncrementActivity();

        // -(void)decrementActivity;
        [Export("decrementActivity")]
        void DecrementActivity();

        // +(UIActivityIndicatorView * _Nonnull)addActivityIndicator:(UIView * _Nonnull)view;
        [Static]
        [Export("addActivityIndicator:")]
        UIActivityIndicatorView AddActivityIndicator(UIView view);
    }

// typedef void (^FUIAuthAlertActionHandler)();
    delegate void AuthUIAlertActionHandler();

// @interface FUIAccountSettingsViewController : FUIAuthBaseViewController
    [BaseType(typeof(AuthUIBaseViewController), Name="FUIAccountSettingsViewController")]
    interface AccountSettingsViewController
    {
        // @property (getter = isDeleteAccountActionDisabled, assign, nonatomic) BOOL deleteAccountActionDisabled;
        [Export("deleteAccountActionDisabled")]
        bool DeleteAccountActionDisabled
        {
            [Bind("isDeleteAccountActionDisabled")]
            get;
            set;
        }
    }

// typedef void (^FIRAuthProviderSignInCompletionBlock)(AuthCredential * _Nullable, NSError * _Nullable, AuthResultHandler _Nullable);
    delegate void AuthUIProviderSignInCompletionBlock([NullAllowed] AuthCredential arg0, [NullAllowed] NSError arg1, [NullAllowed] AuthResultHandler arg2);


    interface AuthUIProviderProtocol
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nullable providerID;
        [Abstract]
        [NullAllowed, Export("providerID")]
        string ProviderID { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull shortName;
        [Abstract]
        [Export("shortName")]
        string ShortName { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull signInLabel;
        [Abstract]
        [Export("signInLabel")]
        string SignInLabel { get; }

        // @required @property (readonly, nonatomic, strong) UIImage * _Nonnull icon;
        [Abstract]
        [Export("icon", ArgumentSemantic.Strong)]
        UIImage Icon { get; }

        // @required @property (readonly, nonatomic, strong) UIColor * _Nonnull buttonBackgroundColor;
        [Abstract]
        [Export("buttonBackgroundColor", ArgumentSemantic.Strong)]
        UIColor ButtonBackgroundColor { get; }

        // @required @property (readonly, nonatomic, strong) UIColor * _Nonnull buttonTextColor;
        [Abstract]
        [Export("buttonTextColor", ArgumentSemantic.Strong)]
        UIColor ButtonTextColor { get; }

        // @required -(void)signInWithEmail:(NSString * _Nullable)email presentingViewController:(UIViewController * _Nullable)presentingViewController completion:(FIRAuthProviderSignInCompletionBlock _Nullable)completion __attribute__((deprecated("This is deprecated API and will be removed in a future release.Use signInWithDefaultValue:presentingViewController:completion:")));
        [Abstract]
        [Export("signInWithEmail:presentingViewController:completion:")]
        void SignInWithEmail([NullAllowed] string email, [NullAllowed] UIViewController presentingViewController, [NullAllowed] AuthUIProviderSignInCompletionBlock completion);

        // @required -(void)signInWithDefaultValue:(NSString * _Nullable)defaultValue presentingViewController:(UIViewController * _Nullable)presentingViewController completion:(FIRAuthProviderSignInCompletionBlock _Nullable)completion;
        [Abstract]
        [Export("signInWithDefaultValue:presentingViewController:completion:")]
        void SignInWithDefaultValue([NullAllowed] string defaultValue, [NullAllowed] UIViewController presentingViewController, [NullAllowed] AuthUIProviderSignInCompletionBlock completion);

        // @required -(void)signOut;
        [Abstract]
        [Export("signOut")]
        void SignOut();

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable accessToken;
        [Abstract]
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; }

        // @optional @property (readonly, copy, nonatomic) NSString * _Nullable idToken;
        [NullAllowed, Export("idToken")]
        string IdToken { get; }

        // @optional -(NSString * _Nonnull)email;
        [Export("email")]
        string Email { get; }

        // @optional -(BOOL)handleOpenURL:(NSURL * _Nonnull)URL sourceApplication:(NSString * _Nullable)sourceApplication;
        [Export("handleOpenURL:sourceApplication:")]
        bool HandleOpenURL(NSUrl URL, [NullAllowed] string sourceApplication);
    }

// @protocol FUIAuthProvider <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name="FUIAuthProvider")]
    interface AuthUIProvider : AuthUIProviderProtocol
    {

    }
// typedef void (^FUIAuthResultCallback)(User * _Nullable, NSError * _Nullable);
    delegate void AuthUIResultCallback([NullAllowed] User arg0, [NullAllowed] NSError arg1);
    
// @protocol FUIAuthDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name="FUIAuthDelegate")]
    interface AuthUIDelegate
    {
        // @optional -(void)authUI:(FUIAuth * _Nonnull)authUI didSignInWithAuthDataResult:(AuthDataResult * _Nullable)authDataResult error:(NSError * _Nullable)error;
        [Export("authUI:didSignInWithAuthDataResult:error:")]
        [EventArgs("SignedIn")]
        void DidSignInWithAuthData(AuthUI authUI, [NullAllowed] AuthDataResult authDataResult, [NullAllowed] NSError error);

        // @optional -(void)authUI:(FUIAuth * _Nonnull)authUI didFinishOperation:(FUIAccountSettingsOperationType)operation error:(NSError * _Nullable)error;
        [Export("authUI:didFinishOperation:error:")]
        [EventArgs("OperationFinished")]
        void DidFinishOperation(AuthUI authUI, AccountSettingsOperationType operation, [NullAllowed] NSError error);

        // @optional -(FUIAuthPickerViewController * _Nonnull)authPickerViewControllerForAuthUI:(FUIAuth * _Nonnull)authUI;
        [Export("authPickerViewControllerForAuthUI:")]
        [EventArgs("CreateAuthPickerViewController")]
        [NoDefaultValue]
        AuthPickerViewController OnCreateAuthPickerViewController(AuthUI authUI);

        // @optional -(FUIEmailEntryViewController * _Nonnull)emailEntryViewControllerForAuthUI:(FUIAuth * _Nonnull)authUI;
        [Export("emailEntryViewControllerForAuthUI:")]
        [EventArgs("CreateEmailEntryViewController")]
        [NoDefaultValue]
        EmailEntryViewController OnCreateEmailEntryViewController(AuthUI authUI);

        // @optional -(FUIPasswordSignInViewController * _Nonnull)passwordSignInViewControllerForAuthUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nonnull)email;
        [Export("passwordSignInViewControllerForAuthUI:email:")]
        [EventArgs("CreatePasswordSignInViewController")]
        [NoDefaultValue]
        PasswordSignInViewController OnCreatePasswordSignInViewController(AuthUI authUI, string email);

        // @optional -(FUIPasswordSignUpViewController * _Nonnull)passwordSignUpViewControllerForAuthUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nonnull)email;
        [Export("passwordSignUpViewControllerForAuthUI:email:")]
        [EventArgs("CreatePasswordSignUpViewController")]
        [NoDefaultValue]
        PasswordSignUpViewController OnCreatePasswordSignUpViewController(AuthUI authUI, string email);

        // @optional -(FUIPasswordRecoveryViewController * _Nonnull)passwordRecoveryViewControllerForAuthUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nonnull)email;
        [Export("passwordRecoveryViewControllerForAuthUI:email:")]
        [EventArgs("CreatePasswordRecoveryViewController")]
        [NoDefaultValue]
        PasswordRecoveryViewController OnCreatePasswordRecoveryViewController(AuthUI authUI, string email);

        // @optional -(FUIPasswordVerificationViewController * _Nonnull)passwordVerificationViewControllerForAuthUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nonnull)email newCredential:(AuthCredential * _Nonnull)newCredential;
        [Export("passwordVerificationViewControllerForAuthUI:email:newCredential:")]
        [EventArgs("CreatePasswordVerificationViewController")]
        [NoDefaultValue]
        PasswordVerificationViewController OnCreatePasswordVerificationViewController(AuthUI authUI, string email, AuthCredential newCredential);
    }

// @interface FUIAuth : NSObject <NSSecureCoding> 
    [BaseType(typeof(NSObject), 
        Name="FUIAuth", 
        Delegates=new string [] { "WeakDelegate" },
        Events=new Type [] {typeof(AuthUIDelegate)})]
    [DisableDefaultCtor]
    interface AuthUI : INSSecureCoding
    {
        // extern double FirebaseAuthUIVersionNumber;
        [Field("FirebaseAuthUIVersionNumber", "__Internal")]
        double VersionNumber { get; }

        // extern const unsigned char [] FirebaseAuthUIVersionString;
        [Field("FirebaseAuthUIVersionString", "__Internal")]
        NSString VersionString { get; }

        // +(FUIAuth * _Nullable)defaultAuthUI;
        [Static]
        [NullAllowed, Export("defaultAuthUI")]
        AuthUI DefaultInstance { get; }

        // +(FUIAuth * _Nullable)authUIWithAuth:(Auth * _Nonnull)auth;
        [Static]
        [Export("authUIWithAuth:")]
        [return: NullAllowed]
        AuthUI AuthUIWithAuth(Auth auth);

        // @property (readonly, nonatomic, weak) Auth * _Nullable auth;
        [NullAllowed, Export("auth", ArgumentSemantic.Weak)]
        Auth Auth { get; }

        // @property (copy, nonatomic) NSArray<id<FUIAuthProvider>> * _Nonnull providers;
        [Export("providers", ArgumentSemantic.Copy)]
        AuthUIProvider[] Providers { get; set; }

        // @property (getter = isSignInWithEmailHidden, assign, nonatomic) BOOL signInWithEmailHidden;
        [Export("signInWithEmailHidden")]
        bool SignInWithEmailHidden { [Bind("isSignInWithEmailHidden")] get; set; }

        // @property (assign, nonatomic) BOOL allowNewEmailAccounts;
        [Export("allowNewEmailAccounts")]
        bool AllowNewEmailAccounts { get; set; }

        // @property (assign, nonatomic) BOOL shouldHideCancelButton;
        [Export("shouldHideCancelButton")]
        bool ShouldHideCancelButton { get; set; }

        // @property (nonatomic, strong) NSBundle * _Nullable customStringsBundle;
        [NullAllowed, Export("customStringsBundle", ArgumentSemantic.Strong)]
        NSBundle CustomStringsBundle { get; set; }

        // @property (copy, nonatomic) NSURL * _Nullable TOSURL;
        [NullAllowed, Export("TOSURL", ArgumentSemantic.Copy)]
        NSUrl TOSURL { get; set; }

        // @property (getter = shouldAutoUpgradeAnonymousUsers, assign, nonatomic) BOOL autoUpgradeAnonymousUsers;
        [Export("autoUpgradeAnonymousUsers")]
        bool AutoUpgradeAnonymousUsers
        {
            [Bind("shouldAutoUpgradeAnonymousUsers")]
            get;
            set;
        }

        // @property (copy, nonatomic) NSURL * _Nullable privacyPolicyURL;
        [NullAllowed, Export("privacyPolicyURL", ArgumentSemantic.Copy)]
        NSUrl PrivacyPolicyURL { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        AuthUIDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<FUIAuthDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)handleOpenURL:(NSURL * _Nonnull)URL sourceApplication:(NSString * _Nullable)sourceApplication;
        [Export("handleOpenURL:sourceApplication:")]
        bool HandleOpenURL(NSUrl URL, [NullAllowed] string sourceApplication);

        // -(UINavigationController * _Nonnull)authViewController;
        [Export("authViewController")]
        UINavigationController AuthViewController { get; }

        // -(BOOL)signOutWithError:(NSError * _Nullable * _Nullable)error;
        [Export("signOutWithError:")]
        bool SignOutWithError([NullAllowed] out NSError error);
    }

// @interface FUIAuthErrorUtils : NSObject
    [BaseType(typeof(NSObject), Name="FUIAuthErrorUtils")]
    interface AuthUIErrorUtils
    {
        [Field("FUIAuthErrorDomain", "__Internal")]
        NSString ErrorDomain { get; }

        // extern NSString *const _Nonnull FUIAuthErrorUserInfoProviderIDKey;
        [Field("FUIAuthErrorUserInfoProviderIDKey", "__Internal")]
        NSString ErrorUserInfoProviderIDKey { get; }

        // extern NSString *const _Nonnull FUIAuthCredentialKey;
        [Field("FUIAuthCredentialKey", "__Internal")]
        NSString CredentialKey { get; }

        // +(NSError * _Nonnull)errorWithCode:(FUIAuthErrorCode)code userInfo:(NSDictionary * _Nullable)userInfo;
        [Static]
        [Export("errorWithCode:userInfo:")]
        NSError ErrorWithCode(AuthUIErrorCode code, [NullAllowed] NSDictionary userInfo);

        // +(NSError * _Nonnull)userCancelledSignInError;
        [Static]
        [Export("userCancelledSignInError")]
        NSError UserCancelledSignInError { get; }

        // +(NSError * _Nonnull)mergeConflictErrorWithUserInfo:(NSDictionary * _Nonnull)userInfo underlyingError:(NSError * _Nullable)underlyingError;
        [Static]
        [Export("mergeConflictErrorWithUserInfo:underlyingError:")]
        NSError MergeConflictErrorWithUserInfo(NSDictionary userInfo, [NullAllowed] NSError underlyingError);

        // +(NSError * _Nonnull)providerErrorWithUnderlyingError:(NSError * _Nonnull)underlyingError providerID:(NSString * _Nonnull)providerID;
        [Static]
        [Export("providerErrorWithUnderlyingError:providerID:")]
        NSError ProviderErrorWithUnderlyingError(NSError underlyingError, string providerID);
    }

// @interface FUIAuthPickerViewController : FUIAuthBaseViewController
    [BaseType(typeof(AuthUIBaseViewController), Name="FUIAuthPickerViewController")]
    interface AuthPickerViewController
    {
    }

// @interface FUIEmailEntryViewController : FUIAuthBaseViewController
    [BaseType(typeof(AuthUIBaseViewController), Name="FUIEmailEntryViewController")]
    interface EmailEntryViewController
    {
        // -(void)onNext:(NSString * _Nonnull)emailText;
        [Export("onNext:")]
        void OnNext(string emailText);

        // -(void)didChangeEmail:(NSString * _Nonnull)emailText;
        [Export("didChangeEmail:")]
        void DidChangeEmail(string emailText);
    }

// @interface FUIPasswordRecoveryViewController : FUIAuthBaseViewController
    [BaseType(typeof(AuthUIBaseViewController), Name="FUIPasswordRecoveryViewController")]
    interface PasswordRecoveryViewController
    {
        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil authUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nullable)email __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:authUI:email:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil, AuthUI authUI, [NullAllowed] string email);

        // -(instancetype _Nonnull)initWithAuthUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nullable)email;
        [Export("initWithAuthUI:email:")]
        IntPtr Constructor(AuthUI authUI, [NullAllowed] string email);

        // -(void)didChangeEmail:(NSString * _Nonnull)email;
        [Export("didChangeEmail:")]
        void DidChangeEmail(string email);

        // -(void)recoverEmail:(NSString * _Nonnull)email;
        [Export("recoverEmail:")]
        void RecoverEmail(string email);
    }

// @interface FUIPasswordSignInViewController : FUIAuthBaseViewController
    [BaseType(typeof(AuthUIBaseViewController), Name="FUIPasswordSignInViewController")]
    interface PasswordSignInViewController
    {
        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil authUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nullable)email __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:authUI:email:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil, AuthUI authUI, [NullAllowed] string email);

        // -(instancetype _Nonnull)initWithAuthUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nullable)email;
        [Export("initWithAuthUI:email:")]
        IntPtr Constructor(AuthUI authUI, [NullAllowed] string email);

        // -(void)forgotPasswordForEmail:(NSString * _Nonnull)email;
        [Export("forgotPasswordForEmail:")]
        void ForgotPasswordForEmail(string email);

        // -(void)didChangeEmail:(NSString * _Nonnull)email andPassword:(NSString * _Nonnull)password;
        [Export("didChangeEmail:andPassword:")]
        void DidChangeEmail(string email, string password);

        // -(void)signInWithDefaultValue:(NSString * _Nonnull)email andPassword:(NSString * _Nonnull)password;
        [Export("signInWithDefaultValue:andPassword:")]
        void SignInWithDefaultValue(string email, string password);
    }

    // @interface FUIPasswordSignUpViewController : FUIAuthBaseViewController
    [BaseType(typeof(AuthUIBaseViewController), Name="FUIPasswordSignUpViewController")]
    interface PasswordSignUpViewController
    {
        // @property (nonatomic, strong) FUIPrivacyAndTermsOfServiceView * _Nonnull footerView __attribute__((iboutlet));
        [Export("footerView", ArgumentSemantic.Strong)]
        PrivacyAndTermsOfServiceView FooterView { get; set; }

        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil authUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nullable)email __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:authUI:email:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil, AuthUI authUI, [NullAllowed] string email);

        // -(instancetype _Nonnull)initWithAuthUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nullable)email;
        [Export("initWithAuthUI:email:")]
        IntPtr Constructor(AuthUI authUI, [NullAllowed] string email);

        // -(void)didChangeEmail:(NSString * _Nonnull)email orPassword:(NSString * _Nonnull)password orUserName:(NSString * _Nonnull)username;
        [Export("didChangeEmail:orPassword:orUserName:")]
        void DidChangeEmail(string email, string password, string username);

        // -(void)signUpWithEmail:(NSString * _Nonnull)email andPassword:(NSString * _Nonnull)password andUsername:(NSString * _Nonnull)username;
        [Export("signUpWithEmail:andPassword:andUsername:")]
        void SignUpWithEmail(string email, string password, string username);
    }

// @interface FUIPasswordVerificationViewController : FUIAuthBaseViewController
    [BaseType(typeof(AuthUIBaseViewController), Name="FUIPasswordVerificationViewController")]
    interface PasswordVerificationViewController
    {
        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil authUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nullable)email newCredential:(AuthCredential * _Nonnull)newCredential __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:authUI:email:newCredential:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil, AuthUI authUI, [NullAllowed] string email, AuthCredential newCredential);

        // -(instancetype _Nonnull)initWithAuthUI:(FUIAuth * _Nonnull)authUI email:(NSString * _Nullable)email newCredential:(AuthCredential * _Nonnull)newCredential;
        [Export("initWithAuthUI:email:newCredential:")]
        IntPtr Constructor(AuthUI authUI, [NullAllowed] string email, AuthCredential newCredential);

        // -(void)forgotPassword;
        [Export("forgotPassword")]
        void ForgotPassword();

        // -(void)didChangePassword:(NSString * _Nonnull)password;
        [Export("didChangePassword:")]
        void DidChangePassword(string password);

        // -(void)verifyPassword:(NSString * _Nonnull)password;
        [Export("verifyPassword:")]
        void VerifyPassword(string password);
    }

// @interface FUIPrivacyAndTermsOfServiceView : UITextView
    [BaseType (typeof(UITextView), Name="FUIPrivacyAndTermsOfServiceView")]
    interface PrivacyAndTermsOfServiceView
    {
        // -(void)useFullMessage;
        [Export ("useFullMessage")]
        void UseFullMessage ();

        // -(void)useFooterMessage;
        [Export ("useFooterMessage")]
        void UseFooterMessage ();

        // @property (nonatomic, strong) FUIAuth * _Nullable authUI;
        [NullAllowed, Export ("authUI", ArgumentSemantic.Strong)]
        AuthUI AuthUI { get; set; }
    }

    // @interface FUIPhoneAuth
    [BaseType(typeof(AuthUIProvider), Name="FUIPhoneAuth")]
    interface PhoneAuthUI : AuthUIProviderProtocol
    {
        // -(instancetype)initWithAuthUI:(id)authUI;
        [Export ("initWithAuthUI:")]
        IntPtr Constructor (AuthUI authUI);

        // -(instancetype)initWithAuthUI:(id)authUI whitelistedCountries:(id)countries;
        [Export ("initWithAuthUI:whitelistedCountries:")]
        IntPtr Constructor (AuthUI authUI, NSSet<NSString> countries);

        // -(void)signInWithPresentingViewController:(id)presentingViewController phoneNumber:(id)phoneNumber;
        [Export ("signInWithPresentingViewController:phoneNumber:")]
        void SignIn(UIViewController presentingViewController, string phoneNumber);
    }
}