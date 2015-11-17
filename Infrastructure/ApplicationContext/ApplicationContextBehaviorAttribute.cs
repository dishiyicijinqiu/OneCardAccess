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
            clientOperation.Parent.MessageInspectors.Add(new ApplicationContextClientMessageInspector(this.IsBidirectional));
            //clientOperation.ParameterInspectors.Add(new MyParameterInspector());
            //clientOperation.FaultContractInfos.Add(new FaultContractInfo("",));
            //clientOperation.FaultContractInfos.Add(new MyFaultContractInfo(clientOperation.Action, typeof(CalculationError)));
            //operationDescription.Faults.Add(new FaultDescription(clientOperation.Action));
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.CallContextInitializers.Add(new ApplicationContextCallContextInitializer(this.IsBidirectional, this.SessionCheck));
            //dispatchOperation.Invoker = new MyOperationInvoker();
            //dispatchOperation.ParameterInspectors.Add(new MyParameterInspector());
            //dispatchOperation.FaultContractInfos.Add(new FaultContractInfo(dispatchOperation.Action, typeof(CalculationError)));
            //FaultContract
            //dispatchOperation.FaultContractInfos.Add(new FaultContract(FaultContract))
            //operationDescription.Faults.Add(new FaultDescription(dispatchOperation.Action));
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        #endregion
    }
    [System.Runtime.Serialization.DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class CalculationError
    {
        public CalculationError(string operation, string message)
        {
            if (string.IsNullOrEmpty(operation))
            {
                throw new ArgumentNullException("operation");
            }
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message");
            }
            this.Operation = operation;
            this.Message = message;
        }
        [System.Runtime.Serialization.DataMember]
        public string Operation
        { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Message
        { get; set; }
    }
    public class MyParameterInspector : IParameterInspector
    {

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            return null;
        }
    }
}
