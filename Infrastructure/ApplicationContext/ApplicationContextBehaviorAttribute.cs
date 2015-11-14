using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public class ApplicationContextBehaviorAttribute : Attribute, IOperationBehavior
    {
        public bool IsBidirectional
        { get; set; }
        public bool SessionCheck
        { get; set; }
        public ApplicationContextBehaviorAttribute(bool isBidirectional = false, bool sessionCheck = true)
        {
            this.IsBidirectional = isBidirectional;
            this.SessionCheck = sessionCheck;
        }

        #region IOperationBehavior Members

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.CallContextInitializers.Add(new ApplicationContextCallContextInitializer(this.IsBidirectional, this.SessionCheck));
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        #endregion
    }
}
