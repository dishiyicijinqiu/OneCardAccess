using System;
using System.ServiceModel.Description;
using System.Transactions;

namespace FengSharp.OneCardAccess.Infrastructure.Transaction_Intergration
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionAttribute : Attribute, IOperationBehavior
    {
        private TimeSpan _timeout = new TimeSpan(0, 1, 0);
        public string Timeout
        {
            get
            {
                return this._timeout.ToString();
            }
            set
            {
                if (!TimeSpan.TryParse(value, out this._timeout))
                {
                    throw new FormatException("Invalid Timespan format.");
                }
            }
        }
        public IsolationLevel IsolationLevel { get; set; }
        public TransactionScopeOption TransactionScopeOption { get; set; }

        public EnterpriseServicesInteropOption EnterpriseServicesInteropOption { get; private set; }
        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            TransactionOptions transactionOptions = new TransactionOptions() { IsolationLevel = this.IsolationLevel, Timeout = this._timeout };
            dispatchOperation.CallContextInitializers.Add(new TransactionCallContextInitializer(this.TransactionScopeOption, transactionOptions, this.EnterpriseServicesInteropOption));
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}
