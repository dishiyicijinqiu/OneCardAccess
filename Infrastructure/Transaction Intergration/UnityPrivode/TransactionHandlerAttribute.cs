using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Transactions;

namespace FengSharp.OneCardAccess.Infrastructure.Services
{
    public class TransactionHandlerAttribute : HandlerAttribute
    {
        private TimeSpan _timeout;

        public TransactionScopeOption TransactionScopeOption
        { get; set; }

        public string Timeout
        {
            get
            {
                return this._timeout.ToString();
            }
            set
            {
                if (!TimeSpan.TryParse(value,out this._timeout))
                {
                    throw new FormatException("Invalid Timespan format.");
                }
            }
        }
        public TransactionHandlerAttribute()
        {

        }

        public IsolationLevel IsolationLevel
        { get; set; }

        public EnterpriseServicesInteropOption EnterpriseServicesInteropOption
        { get; private set; }
        

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            TransactionOptions transactionOptions = new TransactionOptions() { IsolationLevel = this.IsolationLevel, Timeout = this._timeout };
            return new TransactionCallHandler(this.TransactionScopeOption, transactionOptions, this.EnterpriseServicesInteropOption) { Order = this.Order };

        }
    }
}
