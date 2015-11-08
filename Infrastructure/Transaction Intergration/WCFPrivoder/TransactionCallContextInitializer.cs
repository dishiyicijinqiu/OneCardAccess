using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Transactions;

namespace FengSharp.OneCardAccess.Infrastructure.Transaction_Intergration
{
    public class TransactionCallContextInitializer : ICallContextInitializer
    {
        public TransactionScopeOption TransactionScopeOption { get; private set; }
        public TransactionOptions TransactionOptions { get; private set; }
        public EnterpriseServicesInteropOption EnterpriseServicesInteropOption { get; private set; }

        public TransactionCallContextInitializer(
            TransactionScopeOption transactionScopeOption,
            TransactionOptions transactionOptions,
            EnterpriseServicesInteropOption enterpriseServicesInteropOption)
        {
            this.TransactionScopeOption = transactionScopeOption;
            this.TransactionOptions = transactionOptions;
            this.EnterpriseServicesInteropOption = enterpriseServicesInteropOption;
        }

        public void AfterInvoke(object correlationState)
        {

        }

        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message)
        {
            TransactionScope transactionScope = new TransactionScope(this.TransactionScopeOption, this.TransactionOptions, this.EnterpriseServicesInteropOption);
            OperationContext.Current.Extensions.Add(new TransactionOperationContext(transactionScope));
            return null;
        }
        public class TransactionOperationContext : IExtension<OperationContext>
        {
            TransactionScope transactionScope;
            public TransactionOperationContext(TransactionScope _transactionScope)
            {
                transactionScope = _transactionScope;
            }
            public void Attach(OperationContext owner)
            {
                owner.OperationCompleted += owner_OperationCompleted;
                
            }

            void owner_OperationCompleted(object sender, EventArgs e)
            {

            }

            public void Detach(OperationContext owner)
            {
                throw new NotImplementedException();
            }
        }
    }
}
