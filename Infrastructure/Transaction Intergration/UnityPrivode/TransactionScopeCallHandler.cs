using Microsoft.Practices.Unity.InterceptionExtension;
using System.Transactions;

namespace FengSharp.OneCardAccess.Infrastructure.Services
{
    public class TransactionCallHandler:ICallHandler
    {
        public TransactionScopeOption TransactionScopeOption
        { get; private set; }

        public TransactionOptions TransactionOptions
        { get; private set; }

        public EnterpriseServicesInteropOption EnterpriseServicesInteropOption
        { get; private set; } 

        public TransactionCallHandler(TransactionScopeOption transactionScopeOption,TransactionOptions transactionOptions,EnterpriseServicesInteropOption enterpriseServicesInteropOption)
        {
            this.TransactionOptions = transactionOptions;
            this.TransactionScopeOption = transactionScopeOption;
            this.EnterpriseServicesInteropOption = enterpriseServicesInteropOption;
        }

        #region ICallHandler Members

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            using (TransactionScope transactionScope = new TransactionScope(this.TransactionScopeOption, this.TransactionOptions, this.EnterpriseServicesInteropOption))
            {
                IMethodReturn methodReturn = getNext()(input, getNext);
                if (methodReturn.Exception == null)
                {
                    transactionScope.Complete();
                }

                return methodReturn;
            }
        }

        public int Order
        { get; set; }

        #endregion
    }
}
