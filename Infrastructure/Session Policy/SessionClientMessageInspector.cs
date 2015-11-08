using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace FengSharp.OneCardAccess.Infrastructure.Session_Policy
{
    internal class SessionClientMessageInspector : IClientMessageInspector
    {
        private SessionMessageHeaderInfo messageheaderinfo;
        public SessionClientMessageInspector(SessionMessageHeaderInfo messageheaderinfo)
        {
            this.messageheaderinfo = messageheaderinfo;
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var tickid = (Thread.CurrentPrincipal as AuthPrincipal).Ticket;
            if (tickid != null)
            {
                request.Headers.Add(MessageHeader.CreateHeader(this.messageheaderinfo.TicketName,
                    this.messageheaderinfo.Namespace, tickid));
            }
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            int ticketheaderindex = reply.Headers.FindHeader(messageheaderinfo.TicketName, messageheaderinfo.Namespace);
            if (ticketheaderindex > -1)
            {
                var ticketstring = reply.Headers.GetHeader<string>(messageheaderinfo.TicketName, messageheaderinfo.Namespace);
                var authPrincipal = (Thread.CurrentPrincipal as AuthPrincipal);
                authPrincipal.Ticket = ticketstring;
            }
        }
    }
}
