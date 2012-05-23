using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Principal;


namespace Gojo.Core.Security.Authentication
{
    /// See: http://www.codeproject.com/KB/dotnet/utilityclasses.aspx

    public class Impersonation : IDisposable
    {
        private bool _disposed;
        private WindowsImpersonationContext _impersonationContext;


        public Impersonation(BuiltinUser builtinUser)
            : this(String.Empty, "NT AUTHORITY", String.Empty, LogonType.Service, builtinUser)
        { }

        public Impersonation(String username, String domain, String password)
            : this(username, domain, password, LogonType.Interactive, BuiltinUser.None)
        { }

        ~Impersonation()
        {
            Dispose(false);
        }


        private Impersonation(String username, String domain, String password, LogonType logonType, BuiltinUser builtinUser)
        {
            switch (builtinUser)
            {
                case BuiltinUser.None:
                    if (String.IsNullOrEmpty(username))
                        return;
                    break;
                case BuiltinUser.LocalService:
                    username = "LOCAL SERVICE";
                    break;
                case BuiltinUser.NetworkService:
                    username = "NETWORK SERVICE";
                    break;
            }

            if ((domain + "\\" + username).Equals(CurrentUserName, StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            IntPtr userToken;
            var userTokenDuplication = IntPtr.Zero;

            var loggedOn = LogonUser(username, domain, password,
                logonType, LogonProvider.Default,
                out userToken);

            if (!loggedOn)
            {
                throw new Win32Exception();
            }

            try
            {
                if (DuplicateToken(userToken, 2, ref userTokenDuplication))
                {
                    WindowsIdentity identity = new WindowsIdentity(userTokenDuplication);
                    _impersonationContext = identity.Impersonate();
                }
                else
                {
                    throw new Win32Exception();
                }
            }

            finally
            {
                if (!userTokenDuplication.Equals(IntPtr.Zero))
                {
                    CloseHandle(userTokenDuplication);
                    userTokenDuplication = IntPtr.Zero;
                }

                if (!userToken.Equals(IntPtr.Zero))
                {
                    CloseHandle(userToken);
                    userToken = IntPtr.Zero;
                }
            }
        }






        public void Revert()
        {
            if (_impersonationContext == null) return;

            // Revert to previour user.
            _impersonationContext.Undo();
            _impersonationContext = null;
        }

        public static String CurrentUserName
        {
            get
            {
                return WindowsIdentity.GetCurrent().Name;
            }
        }

        public static Impersonation Impersonate(string domainName, string userName, string password)
        {
            return new Impersonation(userName, domainName, password);
        }

        public static Impersonation Impersonate(BuiltinUser user)
        {
            return new Impersonation(user);
        }

        public static Impersonation Impersonate(string user, string password)
        {
            return Impersonate(null, user, password);
        }


        

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            Revert();

            _disposed = true;
        }

        #endregion

        #region Dll Imports

        /// Closes an open object handle.
        [DllImport("kernel32.dll")]
        private static extern Boolean CloseHandle(IntPtr hObject);

        /// Attempts to log a user on to the local computer.
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool LogonUser(string username, string domain,
                                              string password, LogonType logonType,
                                              LogonProvider logonProvider,
                                              out IntPtr userToken);

        /// Creates a new access token that duplicates one already in existence.
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DuplicateToken(IntPtr token, int impersonationLevel,
            ref IntPtr duplication);

        /// The ImpersonateLoggedOnUser function lets the calling thread impersonate the 
        /// security context of a logged-on user. The user is represented by a token handle.
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool ImpersonateLoggedOnUser(IntPtr userToken);

        #endregion
    }



    public enum LogonType
    {
        Interactive = 2,
        Network = 3,
        Batch = 4,
        Service = 5,
        Unlock = 7,
        NetworkCleartText = 8,
        NewCredentials = 9,
    }

    public enum LogonProvider
    {
        Default = 0,
    }

    public enum BuiltinUser
    {
        None,
        LocalService,
        NetworkService
    }
}
